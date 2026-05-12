using Mmu.CleanBlazor.Common.LanguageExtensions.Invariance;

namespace DatabaseBuddy.Infrastructure.DockerStuff.Configurations.Ports
{
    public class ContainerPortProcotol
    {
        public static ContainerPortProcotol Tcp => new ContainerPortProcotol("tcp");
        public static ContainerPortProcotol Udp => new ContainerPortProcotol("udp");
        public string Name { get; }

        private ContainerPortProcotol(string name)
        {
            Guard.StringNotNullOrEmpty(() => name);

            Name = name;
        }
    }
}