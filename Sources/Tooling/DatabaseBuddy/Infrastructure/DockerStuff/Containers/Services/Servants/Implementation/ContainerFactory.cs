using DatabaseBuddy.Infrastructure.DockerStuff.Configurations;
using DatabaseBuddy.Infrastructure.DockerStuff.Containers.Models;
using DatabaseBuddy.Infrastructure.DockerStuff.Containers.Services.NativeProxies;
using Docker.DotNet;
using Docker.DotNet.Models;
using Mmu.CleanBlazor.Common.LanguageExtensions.Types.Eithers;
using Mmu.CleanBlazor.Common.LanguageExtensions.Types.Maybes;

namespace DatabaseBuddy.Infrastructure.DockerStuff.Containers.Services.Servants.Implementation
{
    internal class ContainerFactory : IContainerFactory
    {
        private readonly IDockerApiAdapter _apiAdapter;
        private readonly IDockerClientFactory _clientFactory;
        private readonly IDockerContainerRepository _containerRepo;

        public ContainerFactory(
            IDockerClientFactory clientFactory,
            IDockerApiAdapter apiAdapter,
            IDockerContainerRepository containerRepo)
        {
            _clientFactory = clientFactory;
            _apiAdapter = apiAdapter;
            _containerRepo = containerRepo;
        }

        public async Task<Either<ContainerErrors, CreatedContainer>> CreateIfNotExistingAsync(IContainerConfiguration containerConfig)
        {
            var existingRepo = await _containerRepo.FindByNameAsync(containerConfig.ContainerName);

            var containerResult = await existingRepo
                .Map(f => Task.FromResult<Either<ContainerErrors, CreatedContainer>>(new CreatedContainer(f.ID)))
                .Reduce(() => CreateImageAndContainerAsync(containerConfig));

            return containerResult;
        }

        private static async Task CreateImageAsync(IDockerClient client, IContainerConfiguration image)
        {
            await client.Images.CreateImageAsync(
                new ImagesCreateParameters { FromImage = image.ImageIdentifier.Name, Tag = image.ImageIdentifier.Tag },
                new AuthConfig(),
                new Progress<JSONMessage>());
        }

        private async Task<CreateContainerResponse> CreateContainerAsync(
            IDockerClient client,
            IContainerConfiguration containerConfig)
        {
            var hostConfig = CreateHostConfig(containerConfig);

            return await client.Containers.CreateContainerAsync(
                new CreateContainerParameters
                {
                    Image = containerConfig.ImageIdentifier.CompleteIdentifier,
                    Name = containerConfig.ContainerName,
                    Tty = false,
                    HostConfig = hostConfig,
                    Env = _apiAdapter.AdaptEnvironmentVariables(containerConfig.EnvironmentVariables),
                    ExposedPorts = _apiAdapter.AdaptExposedPorts(containerConfig.PortConfiguration.Bindings)
                });
        }

        private HostConfig CreateHostConfig(IContainerConfiguration containerConfig)
        {
            return new HostConfig
            {
                PortBindings = _apiAdapter.AdaptPortBindings(containerConfig.PortConfiguration.Bindings)
            };
        }

        private async Task<Either<ContainerErrors, CreatedContainer>> CreateImageAndContainerAsync(IContainerConfiguration containerConfig)
        {
            using var client = _clientFactory.Create();
            await CreateImageAsync(client, containerConfig);

            var createContainerResponse = await CreateContainerAsync(client, containerConfig);

            if (createContainerResponse.Warnings.Any())
            {
                return new ContainerErrors(createContainerResponse.Warnings.ToArray());
            }

            return new CreatedContainer(createContainerResponse.ID);
        }
    }
}