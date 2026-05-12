using Docker.DotNet;

namespace DatabaseBuddy.Infrastructure.DockerStuff.Containers.Services.NativeProxies
{
    internal interface IDockerClientFactory
    {
        DockerClient Create();
    }
}