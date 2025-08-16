using Mmu.CleanBlazor.Application.Infrastructure.Outbox.Models;
using Mmu.CleanBlazor.Application.Infrastructure.Outbox.Repositories;
using Mmu.CleanBlazor.DataAccess.Infrastructure.Repositories.Base;
using Mmu.CleanBlazor.Domain.Areas.Individuals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
