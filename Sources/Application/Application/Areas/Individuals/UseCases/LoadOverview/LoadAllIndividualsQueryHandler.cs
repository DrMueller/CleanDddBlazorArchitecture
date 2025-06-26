using MediatR;
using Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.LoadIndividual;
using Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.LoadOverview.Response;
using Mmu.CleanBlazor.Common.Extensions;
using Mmu.CleanBlazor.Domain.Areas.Individuals.Specifications;
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
            return await _queryService
                .QueryAsync(new IndividualSpec())
                .SelectListAsync(IndividualOverviewEntry.Map);
        }
    }
}