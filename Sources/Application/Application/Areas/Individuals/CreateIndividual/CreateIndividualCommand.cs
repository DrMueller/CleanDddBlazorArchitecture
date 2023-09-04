using Mmu.CleanBlazor.Application.Infrastructure.Mediation.Models;
using Mmu.CleanBlazor.Common.LanguageExtensions.Invariance;

namespace Mmu.CleanBlazor.Application.Areas.Individuals.CreateIndividual;

public class CreateIndividualCommand : ICommand<CreateIndividualResultDto>
{
    public CreateIndividualCommand(CreateIndividualRequestDto requestDto)
    {
        Guard.ObjectNotNull(() => requestDto);

        RequestDto = requestDto;
    }

    public CreateIndividualRequestDto RequestDto { get; }
}