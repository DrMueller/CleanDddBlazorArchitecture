using Lamar;
using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Factories;
using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Factories.Implementation;
using Mmu.CleanBlazor.DataAccess.Infrastructure.UnitOfWorks.Implementation;
using Mmu.CleanBlazor.DataAccess.Infrastructure.UnitOfWorks.Servants;
using Mmu.CleanBlazor.DataAccess.Infrastructure.UnitOfWorks.Servants.Implementation;
using Mmu.CleanBlazor.Domain.Infrastructure.Data.UnitOfWorks;

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

        For<IUnitOfWork>().Use<UnitOfWork>().Transient();
        For<IUnitOfWorkFactory>().Use<UnitOfWorkFactory>().Scoped();
        For<IAppDbContextFactory>().Use<AppDbContextFactory>().Singleton();
        For<IDbContextOptionsFactory>().Use<DbContextOptionsFactory>().Singleton();
        For<IRepositoryCache>().Use<RepositoryCache>().Transient();
    }
}