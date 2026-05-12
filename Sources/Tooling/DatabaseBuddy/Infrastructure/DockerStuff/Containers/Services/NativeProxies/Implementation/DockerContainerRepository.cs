using Docker.DotNet.Models;
using Mmu.CleanBlazor.Common.LanguageExtensions.Types.Maybes;

namespace DatabaseBuddy.Infrastructure.DockerStuff.Containers.Services.NativeProxies.Implementation
{
    internal class DockerContainerRepository(IDockerClientFactory clientFactory) : IDockerContainerRepository
    {
        public async Task<Maybe<ContainerListResponse>> FindByNameAsync(string containerName)
        {
            using var client = clientFactory.Create();

            var containers = await client.Containers.ListContainersAsync(new ContainersListParameters { All = true });
            var existingContainer = containers.SingleOrDefault(f => f.Names.Contains("/" + containerName));

            return Maybe.CreateFromNullable(existingContainer);
        }
    }
}