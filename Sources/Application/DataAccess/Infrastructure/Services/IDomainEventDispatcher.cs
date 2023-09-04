using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Contexts;

namespace Mmu.CleanBlazor.DataAccess.Infrastructure.Services;

public interface IDomainEventDispatcher
{
    Task DispatchEventsAsync(IAppDbContext dbContext);
}