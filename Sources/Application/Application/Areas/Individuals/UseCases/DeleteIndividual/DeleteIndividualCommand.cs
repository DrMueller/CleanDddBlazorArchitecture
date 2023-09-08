using Mmu.CleanBlazor.Application.Infrastructure.Mediation.Models;
using Mmu.CleanBlazor.Common.LanguageExtensions.Invariance;

namespace Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.DeleteIndividual
{
    public class DeleteIndividualCommand : ICommand
    {
        public long IndividualId { get; }

        public DeleteIndividualCommand(long individualId)
        {
            Guard.ValueNotDefault(() => individualId);

            IndividualId = individualId;
        }
    }
}