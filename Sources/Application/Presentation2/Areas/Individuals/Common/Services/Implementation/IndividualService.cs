using AutoMapper;
using Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.LoadIndividual;
using Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.UpsertIndividual;
using Mmu.CleanBlazor.Application.Infrastructure.Mediation.Services;
using Mmu.CleanBlazor.Presentation2.Areas.Individuals.Edit;

namespace Mmu.CleanBlazor.Presentation2.Areas.Individuals.Common.Services.Implementation;

public class IndividualService : IIndividualService
{
    private readonly IMapper _mapper;
    private readonly IMediationService _mediator;

    public IndividualService(
        IMediationService mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IndividualVm> LoadAsync(long id)
    {
        if (id == 0)
        {
            return new IndividualVm();
        }

        var individual = await _mediator.SendAsync(new LoadIndividualQuery(id));
        var vm = _mapper.Map<IndividualVm>(individual);

        return vm;
    }

    public async Task SaveAsync(IndividualVm individual)
    {
        var ind = _mapper.Map<IndividualToUpsert>(individual);
        await _mediator.SendAsync(new UpsertIndividualCommand(ind));
    }
}