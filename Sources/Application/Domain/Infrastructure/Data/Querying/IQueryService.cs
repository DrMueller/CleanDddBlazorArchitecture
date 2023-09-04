using Mmu.CleanBlazor.Domain.Areas.Common.Models;

namespace Mmu.CleanBlazor.Domain.Infrastructure.Data.Querying
{
    public interface IQueryService
    {
        Task<IReadOnlyCollection<TResult>> QueryAsync<T, TResult>(IQuerySpecification<T, TResult> spec)
            where T : Entity;

        Task<IReadOnlyCollection<T>> QueryAsync<T>(IQuerySpecification<T> spec)
            where T : Entity;
    }
}