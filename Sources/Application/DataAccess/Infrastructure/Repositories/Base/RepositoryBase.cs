using Microsoft.EntityFrameworkCore;
using Mmu.CleanBlazor.Common.LanguageExtensions.Types.Maybes;
using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Contexts;
using Mmu.CleanBlazor.Domain.Areas.Common.Models;
using Mmu.CleanBlazor.Domain.Infrastructure.Data.Repositories;

namespace Mmu.CleanBlazor.DataAccess.Infrastructure.Repositories.Base;

public abstract class RepositoryBase<T> : IRepositoryBase
    where T: AggregateRoot
{
    private IAppDbContext _dbContext;

    void IRepositoryBase.Initialize(IAppDbContext dbContext)
    {
        _dbContext = _dbContext;
    }

    private IDbSetProxy<T> DbSet()
    {
        return _dbContext.DbSet<T>();
    }

    private IQueryable<T> Query()
    {
        return DbSet().AsNoTracking();
    }

    public async Task DeleteAsync(long id)
    {
        var loadedEntity = await Query().SingleOrDefaultAsync(f => f.Id == id);

        if (loadedEntity is null) return;

        DbSet().Remove(loadedEntity);
    }

    public async Task InsertAsync(T entity)
    {
        await DbSet().AddAsync(entity);
    }

    public async Task<IReadOnlyCollection<T>> LoadCollectionAsync(IAggregateSpecification<T> spec)
    {
        var list = await Query().Where(spec.Filter).ToListAsync();

        return list;
    }

    public async Task<T> LoadSingleAsync(IAggregateSpecification<T> spec)
    {
        return await Query().SingleAsync(spec.Filter);
    }
}