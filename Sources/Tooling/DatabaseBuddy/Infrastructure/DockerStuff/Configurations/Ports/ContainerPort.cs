using Mmu.CleanBlazor.Common.LanguageExtensions.Invariance;

namespace DatabaseBuddy.Infrastructure.DockerStuff.Configurations.Ports
{
    public class ContainerPort
    {
        public string CompleteIdentifier => $"{PortNumber}/{Protocol.Name}";

        public int PortNumber { get; }
        public ContainerPortProcotol Protocol { get; }

        public ContainerPort(int portNumber, ContainerPortProcotol protocol)
        {
            Guard.That(() => portNumber > 0, "Port Number not set.");

            PortNumber = portNumber;
            Protocol = protocol;
        }
    }
}