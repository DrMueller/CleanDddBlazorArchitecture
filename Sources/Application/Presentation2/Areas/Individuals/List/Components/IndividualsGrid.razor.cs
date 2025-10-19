using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;
using Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.LoadOverview.Response;
using Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.SearchIndividuals;
using Mmu.CleanBlazor.Application.Infrastructure.Mediation.Services;
using Mmu.CleanBlazor.Common.Querying.Request;
using Mmu.CleanBlazor.Presentation2.Shared;
using Mmu.CleanBlazor.Presentation2.Shared.Components.QuickGrids.Filtering;

namespace Mmu.CleanBlazor.Presentation2.Areas.Individuals.List.Components
{
    public partial class IndividualsGrid
    {
        [Inject]
        public required IMediationService Mediator { get; set; }

        private QuickGridStringFilter FirstNameFilter { get; } = QuickGridFilter.CreateForString();
        private QuickGridStringFilter LastNameFilter { get; } = QuickGridFilter.CreateForString();

        private PaginationState Pagination { get; } = new() { ItemsPerPage = 100 };

        private async ValueTask<GridItemsProviderResult<IndividualOverviewEntry>> GetItemsAsync(GridItemsProviderRequest<IndividualOverviewEntry> request)
        {
            var page = new QuerySpecificationPage(Pagination.CurrentPageIndex, Pagination.ItemsPerPage);

            var sortProps = request.GetSortByProperties()
                .Select(f => QuerySorting.Create<IndividualOverviewEntry>(f.PropertyName, f.Direction.Map()))
                .ToList();

            var query = new SearchIndividualsQuery(
                page,
                sortProps,
                FirstNameFilter.Value,
                LastNameFilter.Value);

            var result = await Mediator.SendAsync(query);

            var gridResult = new GridItemsProviderResult<IndividualOverviewEntry>
            {
                Items = result.Items.ToList(),
                TotalItemCount = result.TotalCount
            };

            return gridResult;
        }
    }
}