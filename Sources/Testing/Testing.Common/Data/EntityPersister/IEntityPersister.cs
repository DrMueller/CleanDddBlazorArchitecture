using Mmu.CleanBlazor.Domain.Areas.Common.Models;

namespace Mmu.CleanBlazor.Presentation2.Testing.Common.Data.EntityPersister
{
    public interface IEntityPersister
    {
        Task InsertAsync<T>(IEnumerable<T> entities);

        Task PersistAsync(params object[] entities);

        Task PersistAsync<T>(IEnumerable<T> aggregateRoots)
            where T : AggregateRoot;
    }
}