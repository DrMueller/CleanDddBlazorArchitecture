using Lamar;

namespace Mmu.CleanBlazor.Presentation;

public class RegistryCollection : ServiceRegistry
{
    public RegistryCollection()
    {
        Scan(scanner =>
        {
            scanner.AssemblyContainingType<RegistryCollection>();
            scanner.WithDefaultConventions();
        });

        this.AddAutoMapper(typeof(RegistryCollection));
    }
}