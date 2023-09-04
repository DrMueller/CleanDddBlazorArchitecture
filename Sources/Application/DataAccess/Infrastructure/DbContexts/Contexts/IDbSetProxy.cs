using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Contexts
{
    public interface IDbSetProxy<TEntity>
        where TEntity : class
    {
        Task<EntityEntry<TEntity>> AddAsync(TEntity entity);

        IQueryable<TEntity> AsNoTracking();

        IQueryable<TEntity> AsQueryable();

        void Remove(TEntity entity);
    }
}