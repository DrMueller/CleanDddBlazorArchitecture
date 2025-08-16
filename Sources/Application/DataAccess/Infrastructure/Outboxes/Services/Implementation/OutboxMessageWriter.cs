using System.Text.Json;
using Mmu.CleanBlazor.Application.Infrastructure.Outbox.Models;
using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Contexts;
using Mmu.CleanBlazor.DataAccess.Infrastructure.Services.Servants;

namespace Mmu.CleanBlazor.DataAccess.Infrastructure.Outboxes.Services.Implementation
{
    public class OutboxMessageWriter : IOutboxMessageWriter
    {
        private readonly IDomainEventAccessor _domainEventAccesor;

        public OutboxMessageWriter(
            IDomainEventAccessor domainEventAccesor)
        {
            _domainEventAccesor = domainEventAccesor;
        }

        public async Task AddMessagesAsync(IAppDbContext dbContext)
        {
            var outboxMessage = dbContext.DbSet<OutboxMessage>();
            var domainEvents = _domainEventAccesor.GetDomainEvents(dbContext);

            foreach (var domainEvent in domainEvents)
            {
                var msg = new OutboxMessage(
                    domainEvent.Id,
                    domainEvent.GetType().FullName!,
                    JsonSerializer.Serialize(domainEvent),
                    domainEvent.OccurredOn);

                await outboxMessage.AddAsync(msg);
            }
        }
    }
}