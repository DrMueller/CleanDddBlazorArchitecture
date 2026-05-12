using Mmu.CleanBlazor.Common.LanguageExtensions.Invariance;

namespace DatabaseBuddy.Infrastructure.DockerStuff.Configurations.Ports
{
    public class PortBinding
    {
        public ContainerPort ContainerPort { get; }
        public IReadOnlyCollection<HostPort> HostPorts { get; }

        public PortBinding(ContainerPort containerPort, params HostPort[] hostPorts)
        {
            Guard.ObjectNotNull(() => containerPort);
            Guard.ObjectNotNull(() => hostPorts);

            ContainerPort = containerPort;
            HostPorts = hostPorts;
        }
    }
}