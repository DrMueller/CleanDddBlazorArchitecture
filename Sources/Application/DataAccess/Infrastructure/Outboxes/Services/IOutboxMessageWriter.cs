using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.CleanBlazor.DataAccess.Infrastructure.Outboxes.Services
{
    public interface IOutboxMessageWriter
    {
        Task AddMessagesAsync(IAppDbContext dbContext);
    }
}
