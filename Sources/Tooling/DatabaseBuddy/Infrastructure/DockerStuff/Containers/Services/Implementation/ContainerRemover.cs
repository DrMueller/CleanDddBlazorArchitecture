using DatabaseBuddy.Infrastructure.DockerStuff.Containers.Services;
using DatabaseBuddy.Infrastructure.DockerStuff.Containers.Services.NativeProxies;
using Docker.DotNet.Models;

namespace DatabaseBuddy.Infrastructure.DockerStuff.Containers.Services.Implementation
{
    internal class ContainerRemover : IContainerRemover
    {
        private readonly IDockerClientFactory _clientFactory;

        public ContainerRemover(IDockerClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task RemoveAsync(string containerName)
        {
            containerName = $"/{containerName}";

            using (var client = _clientFactory.Create())
            {
                var containers = await client.Containers.ListContainersAsync(
                    new ContainersListParameters
                    {
                        All = true
                    });

                var container = containers.FirstOrDefault(c => c.Names.Any(n => n.Equals(containerName,
                    StringComparison.OrdinalIgnoreCase)));

                if (container == null)
                {
                    return;
                }

                await RemoveContainerAsync(container.ID);
            }
        }

        public async Task RemoveContainerAsync(string containerId)
        {
            if (string.IsNullOrEmpty(containerId))
            {
                return;
            }

            using (var client = _clientFactory.Create())
            {
                await client.Containers.KillContainerAsync(containerId, new ContainerKillParameters());
                await client.Containers.RemoveContainerAsync(containerId, new ContainerRemoveParameters { Force = true });
            }
        }
    }
}