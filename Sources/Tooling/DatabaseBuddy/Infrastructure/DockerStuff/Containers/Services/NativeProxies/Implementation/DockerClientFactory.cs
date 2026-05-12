using DatabaseBuddy.Infrastructure.DockerStuff.Containers.Services.NativeProxies;
using Docker.DotNet;

namespace DatabaseBuddy.Infrastructure.DockerStuff.Containers.Services.NativeProxies.Implementation
{
    internal class DockerClientFactory : IDockerClientFactory
    {
        public DockerClient Create()
        {
            var clientConfig = new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine"));
            return clientConfig.CreateClient();
        }
    }
}