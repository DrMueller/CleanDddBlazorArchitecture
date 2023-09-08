using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Contexts;
using Mmu.CleanBlazor.Domain.Areas.Common.DomainEvents;
using Mmu.CleanBlazor.Domain.Areas.Common.Models;

namespace Mmu.CleanBlazor.DataAccess.Infrastructure.Services.Servants.Implementation;

public class DomainEventAccessor : IDomainEventAccessor
{
    public void ClearAllDomainEvents(IAppDbContext appContext)
    {
        var domainEntities = appContext.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity.DomainEvents.Any()).ToList();

        domainEntities
            .ForEach(entity => entity.Entity.ClearDomainEvents());
    }

    public IReadOnlyCollection<IDomainEvent> GetDomainEvents(IAppDbContext appContext)
    {
        var domainEntities = appContext.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity.DomainEvents?.Any() ?? false).ToList();

        return domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();
    }
}