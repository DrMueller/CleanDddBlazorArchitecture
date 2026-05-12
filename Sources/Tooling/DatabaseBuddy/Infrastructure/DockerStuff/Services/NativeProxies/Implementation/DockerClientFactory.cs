using DatabaseBuddy.Infrastructure.DockerStuff.Services.NativeProxies;
using Docker.DotNet;

namespace DatabaseBuddy.Infrastructure.DockerStuff.Services.NativeProxies.Implementation
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