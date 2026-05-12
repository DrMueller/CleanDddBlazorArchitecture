using DatabaseBuddy.Infrastructure.DockerStuff.Configurations;
using DatabaseBuddy.Infrastructure.DockerStuff.Configurations.Ports;
using DatabaseBuddy.Infrastructure.DockerStuff.Containers.Services.NativeProxies;
using Docker.DotNet.Models;
using PortBinding = DatabaseBuddy.Infrastructure.DockerStuff.Configurations.Ports.PortBinding;

namespace DatabaseBuddy.Infrastructure.DockerStuff.Containers.Services.NativeProxies.Implementation
{
    internal class DockerApiAdapter : IDockerApiAdapter
    {
        public IList<string> AdaptEnvironmentVariables(IReadOnlyCollection<EnvironmentVariable> variables)
        {
            return variables
                .Select(f => $"{f.Key}={f.Value}")
                .ToList();
        }

        public IDictionary<string, EmptyStruct> AdaptExposedPorts(IReadOnlyCollection<PortBinding> ports)
        {
            var result = ports.ToDictionary(f => f.ContainerPort.CompleteIdentifier, f => default(EmptyStruct));

            return result;
        }

        public IDictionary<string, IList<Docker.DotNet.Models.PortBinding>> AdaptPortBindings(IReadOnlyCollection<PortBinding> ports)
        {
            var result = ports.ToDictionary(
                f => f.ContainerPort.CompleteIdentifier,
                f => AdaptPortBindings(f.HostPorts));

            return result;
        }

        private static IList<Docker.DotNet.Models.PortBinding> AdaptPortBindings(IReadOnlyCollection<HostPort> hostPorts)
        {
            var result = hostPorts.Select(hp => new Docker.DotNet.Models.PortBinding
            {
                HostIP = hp.HostIp,
                HostPort = hp.PortNumber.ToString()
            }).ToList();

            return result;
        }
    }
}