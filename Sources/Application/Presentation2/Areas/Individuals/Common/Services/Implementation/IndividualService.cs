using Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.LoadIndividual;
using Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.UpsertIndividual;
using Mmu.CleanBlazor.Application.Infrastructure.Mediation.Services;
using Mmu.CleanBlazor.Presentation2.Areas.Individuals.Edit;

namespace Mmu.CleanBlazor.Presentation2.Areas.Individuals.Common.Services.Implementation;

public class IndividualService : IIndividualService
{
    private readonly IMediationService _mediator;

    public IndividualService(
        IMediationService mediator)
    {
        _mediator = mediator;
    }

    public async Task<IndividualVm> LoadAsync(long id)
    {
        if (id == 0)
        {
            return new IndividualVm();
        }

        var individual = await _mediator.SendAsync(new LoadIndividualQuery(id));

        return new IndividualVm
        {
            BirthDate = individual.BirthDate,
            FirstName = individual.FirstName,
            LastName = individual.LastName,
            IndividualId = individual.IndividualId,
            Length = individual.Length
        };
    }

    public async Task SaveAsync(IndividualVm individual)
    {
        var ind = new IndividualToUpsert
        {
            BirthDate = individual.BirthDate,
            FirstName = individual.FirstName,
            LastName = individual.LastName,
            IndividualId = individual.IndividualId,
            Length = individual.Length
        };

        await _mediator.SendAsync(new UpsertIndividualCommand(ind));
    }
}