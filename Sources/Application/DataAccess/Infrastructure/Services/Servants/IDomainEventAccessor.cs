using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Contexts;
using Mmu.CleanBlazor.Domain.Areas.Common.DomainEvents;

namespace Mmu.CleanBlazor.DataAccess.Infrastructure.Services.Servants;

public interface IDomainEventAccessor
{
    void ClearAllDomainEvents(IAppDbContext appContext);

    IReadOnlyCollection<IDomainEvent> GetDomainEvents(IAppDbContext appContext);
}