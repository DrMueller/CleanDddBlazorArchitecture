using Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.LoadOverview.Response;
using Mmu.CleanBlazor.Common.LanguageExtensions.Types.Maybes;
using Mmu.CleanBlazor.Common.Querying.Request;

namespace Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.SearchIndividuals
{
    public class IndividualSearchEntry
    {
        public required Maybe<QuerySpecificationPage> Page { get; init; }
        public string? SearchTerm { get; init; }
        public List<QuerySorting<IndividualOverviewEntry>> Sorts { get; init; } = new();
    }
}