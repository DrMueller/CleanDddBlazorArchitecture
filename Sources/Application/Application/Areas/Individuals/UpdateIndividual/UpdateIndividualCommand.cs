using Mmu.CleanBlazor.Application.Infrastructure.Mediation.Models;
using Mmu.CleanBlazor.Common.LanguageExtensions.Invariance;

namespace Mmu.CleanBlazor.Application.Areas.Individuals.UpdateIndividual
{
    public class UpdateIndividualCommand : ICommand
    {
        public UpdateIndividualCommand(IndividualToUpdateDto dto)
        {
            Guard.ObjectNotNull(() => dto);

            Dto = dto;
        }

        public IndividualToUpdateDto Dto { get; }
    }
}