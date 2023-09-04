using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Contexts;

namespace Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Factories
{
    public interface IAppDbContextFactory
    {
        IAppDbContext Create();
    }
}