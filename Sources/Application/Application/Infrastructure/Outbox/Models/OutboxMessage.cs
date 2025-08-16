using Mmu.CleanBlazor.Domain.Areas.Common.Models;

namespace Mmu.CleanBlazor.Application.Infrastructure.Outbox.Models
{
    public class OutboxMessage : AggregateRoot
    {
        public string? Error { get; private set; }
        public Guid EventId { get; }
        public DateTime EventOccurredOn { get; }
        public string EventType { get; }
        public string Payload { get; }
        public DateTime? ProcessedOnUtc { get; private set; }

        public OutboxMessage(
            Guid eventId, string eventType, string payload, DateTime eventOccurredOn)
        {
            EventId = eventId;
            EventType = eventType;
            Payload = payload;
            EventOccurredOn = eventOccurredOn;
        }

        public void MarkAsFailed(string error)
        {
            Error = error;
            ProcessedOnUtc = DateTime.UtcNow;
        }

        public void MarkAsProcessed()
        {
            ProcessedOnUtc = DateTime.UtcNow;
        }
    }
}