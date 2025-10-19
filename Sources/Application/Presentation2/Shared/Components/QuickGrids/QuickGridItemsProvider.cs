using Microsoft.AspNetCore.Components.QuickGrid;

namespace Mmu.CleanBlazor.Presentation2.Shared.Components.QuickGrids
{
    // There is no way to get the sorted and paged items with Quickgrid if we don't use a custom items provider.
    // Therefore, we use the base implementation, if the sorted and pages collection is required
    public static class QuickGridItemsProvider
    {
        public static ValueTask<GridItemsProviderResult<T>> ApplyAsync<T>(
            GridItemsProviderRequest<T> request,
            IQueryable<T> filteredItems)
        {
            var query = filteredItems;
            query = request.ApplySorting(query);
            query = query.Skip(request.StartIndex);
            if (request.Count.HasValue)
            {
                query = query.Take(request.Count.Value);
            }

            var items = query.ToList();
            var result = new GridItemsProviderResult<T>
            {
                Items = items,
                TotalItemCount = filteredItems.Count()
            };

            return ValueTask.FromResult(result);
        }
    }
}