using MediatR;
using Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.LoadIndividual.Response;
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
        throw new Exception("Tra");
        var inds = await _queryService.QueryAsync(new LoadIndividualDetailsSpec(request.IndividualId));

        return inds.Single();
    }
}