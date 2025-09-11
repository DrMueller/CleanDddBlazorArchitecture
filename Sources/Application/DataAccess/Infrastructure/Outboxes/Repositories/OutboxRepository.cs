using Microsoft.EntityFrameworkCore;
using Mmu.CleanBlazor.Application.Infrastructure.Outbox.Models;
using Mmu.CleanBlazor.Application.Infrastructure.Outbox.Repositories;
using Mmu.CleanBlazor.DataAccess.Infrastructure.Repositories.Base;

namespace Mmu.CleanBlazor.DataAccess.Infrastructure.Outboxes.Repositories
{
    public class OutboxRepository : RepositoryBase<OutboxMessage>, IOutboxRepository
    {
        public async Task<IReadOnlyCollection<OutboxMessage>> LoadUnsentMessagesAsync()
        {
            return await Query()
                .Where(f => f.ProcessedOnUtc == null)
                .ToListAsync();
        }
    }
}