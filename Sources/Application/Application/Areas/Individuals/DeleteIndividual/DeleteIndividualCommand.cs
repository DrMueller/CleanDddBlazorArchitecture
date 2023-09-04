using Mmu.CleanBlazor.Application.Infrastructure.Mediation.Models;
using Mmu.CleanBlazor.Common.LanguageExtensions.Invariance;

namespace Mmu.CleanBlazor.Application.Areas.Individuals.DeleteIndividual
{
    public class DeleteIndividualCommand : ICommand
    {
        public DeleteIndividualCommand(long individualId)
        {
            Guard.ValueNotDefault(() => individualId);

            IndividualId = individualId;
        }

        public long IndividualId { get; }
    }
}