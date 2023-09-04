using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.CleanBlazor.Domain.Areas.Common.DomainEvents;

namespace Mmu.CleanBlazor.Domain.Areas.Individuals.Events
{
    public class IndividualAdded : DomainEventBase
    {
        public long IndividualId { get; }

        public IndividualAdded(long individualId)
        {
            IndividualId = individualId;
        }
    }
}
