using JetBrains.Annotations;
using Lamar;
using Mmu.CleanBlazor.Common.Settings.Provisioning.Services;
using Mmu.CleanBlazor.Common.Settings.Provisioning.Services.Implementation;

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

            For<IConnectionStringProvider>().Use<AppSettingsProvider>().Singleton();
        }
    }
}