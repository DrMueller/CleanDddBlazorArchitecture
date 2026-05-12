using DatabaseBuddy.Infrastructure.DockerStuff.Configurations;
using Docker.DotNet.Models;

namespace DatabaseBuddy.Infrastructure.DockerStuff.Containers.Services.NativeProxies
{
    internal interface IDockerApiAdapter
    {
        IList<string> AdaptEnvironmentVariables(IReadOnlyCollection<EnvironmentVariable> variables);
        IDictionary<string, EmptyStruct> AdaptExposedPorts(IReadOnlyCollection<Configurations.Ports.PortBinding> ports);
        IDictionary<string, IList<PortBinding>> AdaptPortBindings(IReadOnlyCollection<Configurations.Ports.PortBinding> ports);
    }
}