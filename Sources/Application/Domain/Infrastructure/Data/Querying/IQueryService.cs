using Mmu.CleanBlazor.Domain.Areas.Common.Models;

namespace Mmu.CleanBlazor.Domain.Infrastructure.Data.Querying
{
    public interface IQueryService
    {
        Task<IReadOnlyCollection<TResult>> QueryAsync<TResult>(IQuerySpecification<TResult> spec);
        Task<bool> AnyAsync<TResult>(IQuerySpecification<TResult> spec);
        Task<TResult> QuerySingleAsync<TResult>(IQuerySpecification<TResult> spec);
        Task<TResult?> QuerySingleOrDefaultAsync<TResult>(IQuerySpecification<TResult> spec);
    }
}