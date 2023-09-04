using MediatR;
using Mmu.CleanBlazor.Domain.Infrastructure.Data.Querying;

namespace Mmu.CleanBlazor.Application.Areas.Individuals.LoadAllIndividuals
{
    public class LoadAllIndividualsQueryHandler : IRequestHandler<LoadAllIndividualsQuery, IReadOnlyCollection<IndividualResultDto>>
    {
        private readonly IQueryService _queryService;

        public LoadAllIndividualsQueryHandler(IQueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task<IReadOnlyCollection<IndividualResultDto>> Handle(LoadAllIndividualsQuery request, CancellationToken cancellationToken)
        {
            var dtos = await _queryService.QueryAsync(new LoadAllIndividualsSpec());

            return dtos;
        }
    }
}