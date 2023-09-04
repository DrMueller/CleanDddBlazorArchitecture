using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Contexts;
using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Factories;
using Mmu.CleanBlazor.Domain.Areas.Common.Models;
using Mmu.CleanBlazor.Domain.Infrastructure.Data.Querying;

namespace Mmu.CleanBlazor.DataAccess.Infrastructure.Querying.Implementation
{
    [UsedImplicitly]
    public class QueryService : IQueryService
    {
        private readonly IAppDbContext _appDbContext;

        public QueryService(IAppDbContextFactory appDbContextFactory)
        {
            _appDbContext = appDbContextFactory.Create();
        }

        public async Task<IReadOnlyCollection<TResult>> QueryAsync<T, TResult>(IQuerySpecification<T, TResult> spec)
            where T : Entity
        {
            var dbSet = _appDbContext.DbSet<T>().AsNoTracking();

            var query = spec.Apply(dbSet);

            var selectSet = query.Select(spec.Selector);
            var result = await selectSet.ToListAsync();

            return result;
        }

        public async Task<IReadOnlyCollection<T>> QueryAsync<T>(IQuerySpecification<T> spec)
            where T : Entity
        {
            var dbSet = _appDbContext.DbSet<T>().AsNoTracking();
            var query = spec.Apply(dbSet);

            var result = await query.ToListAsync();

            return result;
        }
    }
}