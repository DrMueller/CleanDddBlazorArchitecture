using Mmu.CleanBlazor.Common.LanguageExtensions.Invariance;

namespace DatabaseBuddy.Infrastructure.DockerStuff.Configurations.Ports
{
    public class PortConfiguration
    {
        public IReadOnlyCollection<PortBinding> Bindings { get; }

        public PortConfiguration(params PortBinding[] bindings)
        {
            Guard.ObjectNotNull(() => bindings);

            Bindings = bindings;
        }
    }
}