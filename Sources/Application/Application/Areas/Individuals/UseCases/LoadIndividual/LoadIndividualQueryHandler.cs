using MediatR;
using Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.LoadIndividual.Response;
using Mmu.CleanBlazor.Common.Extensions;
using Mmu.CleanBlazor.Domain.Areas.Individuals.Specifications;
using Mmu.CleanBlazor.Domain.Infrastructure.Data.Querying;

namespace Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.LoadIndividual;

public class LoadIndividualQueryHandler : IRequestHandler<LoadIndividualQuery, IndividualDetailsEntry>
{
    private readonly IQueryService _queryService;

    public LoadIndividualQueryHandler(IQueryService queryService)
    {
        _queryService = queryService;
    }

    public async Task<IndividualDetailsEntry> Handle(LoadIndividualQuery request, CancellationToken cancellationToken)
    {
        return await _queryService
            .QuerySingleAsync(new IndividualSpec(request.IndividualId))
            .MapAsync(IndividualDetailsEntry.Map);
    }
}