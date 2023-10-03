using Microsoft.EntityFrameworkCore;
using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Contexts;
using Mmu.CleanBlazor.Domain.Areas.Common.Models;
using Mmu.CleanBlazor.Domain.Infrastructure.Data.Repositories;

namespace Mmu.CleanBlazor.DataAccess.Infrastructure.Repositories.Base;

public abstract class RepositoryBase<T> : IRepositoryBase
    where T : AggregateRoot
{
    private IAppDbContext _dbContext = null!;

    public virtual async Task DeleteAsync(long id)
    {
        var loadedEntity = await Query().SingleOrDefaultAsync(f => f.Id == id);

        if (loadedEntity is null)
        {
            return;
        }

        Delete(loadedEntity);
    }

    public async Task InsertAsync(T entity)
    {
        await DbSet().AddAsync(entity);
    }

    public async Task<T> LoadSingleAsync(IAggregateSpecification<T> spec)
    {
        return await Query().SingleAsync(spec.Filter);
    }

    protected void Delete(T entity)
    {
        DbSet().Remove(entity);
    }

    protected IQueryable<T> Query()
    {
        return DbSet().AsQueryable();
    }

    private IDbSetProxy<T> DbSet()
    {
        return _dbContext.DbSet<T>();
    }

    void IRepositoryBase.Initialize(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}