using MediatR;
using Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.LoadOverview.Response;
using Mmu.CleanBlazor.Domain.Infrastructure.Data.Querying;

namespace Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.LoadOverview
{
    public class LoadAllIndividualsQueryHandler : IRequestHandler<LoadAllIndividualsQuery, IReadOnlyCollection<IndividualOverviewEntry>>
    {
        private readonly IQueryService _queryService;

        public LoadAllIndividualsQueryHandler(IQueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task<IReadOnlyCollection<IndividualOverviewEntry>> Handle(LoadAllIndividualsQuery request, CancellationToken cancellationToken)
        {
            var dtos = await _queryService.QueryAsync(new LoadAllIndividualsSpec());

            return dtos;
        }
    }
}