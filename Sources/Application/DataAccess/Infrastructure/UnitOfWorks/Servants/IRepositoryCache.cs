using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Contexts;
using Mmu.CleanBlazor.Domain.Infrastructure.Data.Repositories;

namespace Mmu.CleanBlazor.DataAccess.Infrastructure.UnitOfWorks.Servants
{
    public interface IRepositoryCache
    {
        TRepo GetRepository<TRepo>(IAppDbContext dbContext)
            where TRepo : IRepository;
    }
}