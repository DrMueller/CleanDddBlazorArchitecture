using Docker.DotNet;

namespace DatabaseBuddy.Infrastructure.DockerStuff.Services.NativeProxies
{
    internal interface IDockerClientFactory
    {
        DockerClient Create();
    }
}