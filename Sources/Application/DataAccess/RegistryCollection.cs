using Lamar;

namespace Mmu.CleanBlazor.DataAccess;

public class RegistryCollection : ServiceRegistry
{
    public RegistryCollection()
    {
        Scan(scanner =>
        {
            scanner.AssemblyContainingType<RegistryCollection>();
            scanner.WithDefaultConventions();
        });
    }
}