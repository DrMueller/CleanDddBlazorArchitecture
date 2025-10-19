using MediatR;
using Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.LoadOverview.Response;
using Mmu.CleanBlazor.Application.Infrastructure.Mediation.Models;
using Mmu.CleanBlazor.Common.LanguageExtensions;
using Mmu.CleanBlazor.Common.LanguageExtensions.Types.Maybes.Implementation;
using Mmu.CleanBlazor.Common.Querying.Request;
using Mmu.CleanBlazor.Common.Querying.Response;
using Mmu.CleanBlazor.Domain.Areas.Individuals.Models;
using Mmu.CleanBlazor.Domain.Areas.Individuals.Specifications;
using Mmu.CleanBlazor.Domain.Infrastructure.Data.Querying;

namespace Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.SearchIndividuals
{
    public record SearchIndividualsQuery(
        QuerySpecificationPage Page,
        IReadOnlyCollection<QuerySorting<IndividualOverviewEntry>> Sortings,
        string? FirstNameFilter,
        string? LastNameFilter) : IQuery<PagedResult<IndividualOverviewEntry>>;

    public class SearchIndividualsQueryHandler : IRequestHandler<SearchIndividualsQuery, PagedResult<IndividualOverviewEntry>>
    {
        private readonly IQueryService _queryService;

        public SearchIndividualsQueryHandler(IQueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task<PagedResult<IndividualOverviewEntry>> Handle(SearchIndividualsQuery request, CancellationToken cancellationToken)
        {
            var sortings = request.Sortings
                .Select(s => ToDomainSorting(s.SortDescriptor.GetPropertyName(), s.Direction))
                .ToList();

            var spec = new IndividualSearchSpec(
                request.FirstNameFilter,
                request.LastNameFilter,
                request.Page,
                sortings);

            var result = await _queryService.QueryAsync(spec);

            var totalCnt = await _queryService
                .CountAsync(new IndividualSearchSpec(
                    request.FirstNameFilter,
                    request.LastNameFilter,
                    None.Value,
                    []));

            var items = result.Select(f => new IndividualOverviewEntry
            {
                BirthDate = f.BirthDate,
                FirstName = f.FirstName,
                GenderDescription = f.Gender.ToString(),
                IndividualId = f.Id,
                LastName = f.LastName,
                Length = f.Length
            }).ToList();

            return new PagedResult<IndividualOverviewEntry>(items, totalCnt);
        }

        private static QuerySorting<Individual> ToDomainSorting(string key, QuerySortDirection dir)
        {
            return key switch
            {
                nameof(IndividualOverviewEntry.IndividualId) => new QuerySorting<Individual>(i => i.Id, dir),
                nameof(IndividualOverviewEntry.LastName) => new QuerySorting<Individual>(i => i.LastName, dir),
                nameof(IndividualOverviewEntry.FirstName) => new QuerySorting<Individual>(i => i.FirstName, dir),
                nameof(IndividualOverviewEntry.BirthDate) => new QuerySorting<Individual>(i => i.BirthDate, dir),
                _ => throw new NotSupportedException($"Unknown sort key '{key}'.")
            };
        }
    }
}