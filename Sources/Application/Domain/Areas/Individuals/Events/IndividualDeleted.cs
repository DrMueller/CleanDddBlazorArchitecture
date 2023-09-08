using Mmu.CleanBlazor.Domain.Areas.Common.DomainEvents;

namespace Mmu.CleanBlazor.Domain.Areas.Individuals.Events
{
    public class IndividualDeleted : DomainEventBase
    {
        public long IndividualId { get; }

        public IndividualDeleted(long individualId)
        {
            IndividualId = individualId;
        }
    }
}