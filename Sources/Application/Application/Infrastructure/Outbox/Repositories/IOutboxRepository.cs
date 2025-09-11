using Mmu.CleanBlazor.Application.Infrastructure.Outbox.Models;
using Mmu.CleanBlazor.Domain.Areas.Individuals.Models;
using Mmu.CleanBlazor.Domain.Infrastructure.Data.Repositories;

namespace Mmu.CleanBlazor.Application.Infrastructure.Outbox.Repositories
{
    public interface IOutboxRepository : IRepository
    {
        Task<IReadOnlyCollection<OutboxMessage>> LoadUnsentMessagesAsync();
    }
}