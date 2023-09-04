using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Contexts;

namespace Mmu.CleanBlazor.DataAccess.Infrastructure.Repositories.Base
{
    internal interface IRepositoryBase
    {
        internal void Initialize(IAppDbContext dbContext);
    }
}