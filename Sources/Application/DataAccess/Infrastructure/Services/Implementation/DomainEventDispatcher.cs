using MediatR;
using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Contexts;
using Mmu.CleanBlazor.DataAccess.Infrastructure.Services.Servants;

namespace Mmu.CleanBlazor.DataAccess.Infrastructure.Services.Implementation;

public class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IDomainEventAccessor _domainEventAccessor;
    private readonly IMediator _mediator;

    public DomainEventDispatcher(
        IDomainEventAccessor domainEventAccessor,
        IMediator mediator)
    {
        _domainEventAccessor = domainEventAccessor;
        _mediator = mediator;
    }

    public async Task DispatchEventsAsync(IAppDbContext dbContext)
    {
        var events = _domainEventAccessor.GetDomainEvents(dbContext);

        foreach (var ev in events) await _mediator.Publish(ev);

        _domainEventAccessor.ClearAllDomainEvents(dbContext);
    }
}