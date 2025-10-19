using Microsoft.AspNetCore.Components.QuickGrid;
using Mmu.CleanBlazor.Common.Querying.Request;

namespace Mmu.CleanBlazor.Presentation2.Shared
{
    public static class QuickGridExtensions
    {
        public static QuerySortDirection Map(this SortDirection sortDirection)
        {
            return sortDirection == SortDirection.Descending ? QuerySortDirection.Descending : QuerySortDirection.Ascending;
        }
    }
}