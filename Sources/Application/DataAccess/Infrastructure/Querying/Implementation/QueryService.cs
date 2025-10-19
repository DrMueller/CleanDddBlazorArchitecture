using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Contexts;
using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Factories;
using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Factories.Implementation;
using Mmu.CleanBlazor.Domain.Areas.Common.Models;
using Mmu.CleanBlazor.Domain.Infrastructure.Data.Querying;
using System.Diagnostics;

namespace Mmu.CleanBlazor.DataAccess.Infrastructure.Querying.Implementation
{
    [UsedImplicitly]
    public class QueryService : IQueryService
    {
        private readonly IAppDbContextFactory _appDbContextFactory;

        public QueryService(IAppDbContextFactory appDbContextFactory)
        {
            _appDbContextFactory = appDbContextFactory;
        }
        public async Task<bool> AnyAsync<TResult>(IQuerySpecification<TResult> spec)
        {
            return await PrepareQuery(spec).AnyAsync();
        }

        public Task<int> CountAsync<TResult>(IQuerySpecification<TResult> spec)
        {
            return PrepareQuery(spec).CountAsync();
        }

        public async Task<IReadOnlyCollection<TResult>> QueryAsync<TResult>(IQuerySpecification<TResult> spec)
        {
            var qry = PrepareQuery(spec);
            var sql = qry.ToQueryString();

            Debug.WriteLine(sql);
            return await qry.ToListAsync();
        }

        public async Task<TResult> QuerySingleAsync<TResult>(IQuerySpecification<TResult> spec)
        {
            return await PrepareQuery(spec).SingleAsync();
        }

        public async Task<TResult?> QuerySingleOrDefaultAsync<TResult>(IQuerySpecification<TResult> spec)
        {
            return await PrepareQuery(spec).SingleOrDefaultAsync();
        }

        private IQueryable<TResult> PrepareQuery<TResult>(IQuerySpecification<TResult> spec)
        {
            var appDbContext = _appDbContextFactory.Create();
            var query = spec.Apply(appDbContext);

            return query;
        }
    }
}