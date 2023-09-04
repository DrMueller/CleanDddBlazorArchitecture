using JetBrains.Annotations;
using Lamar;

namespace Mmu.CleanBlazor.Common
{
    [UsedImplicitly]
    public class RegistryCollection : ServiceRegistry
    {
        public RegistryCollection()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<RegistryCollection>();
                    scanner.WithDefaultConventions();
                });
        }
    }
}