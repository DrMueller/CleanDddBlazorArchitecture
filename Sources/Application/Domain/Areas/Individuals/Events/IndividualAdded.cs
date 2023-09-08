using Mmu.CleanBlazor.Domain.Areas.Common.DomainEvents;
using Mmu.CleanBlazor.Domain.Areas.Individuals.Models;

namespace Mmu.CleanBlazor.Domain.Areas.Individuals.Events
{
    public class IndividualAdded : DomainEventBase
    {
        public Individual Individual { get; }

        // Passing the whole reference makes sure the ID is filled after the uow Commit
        public IndividualAdded(Individual individual)
        {
            Individual = individual;
        }
    }
}