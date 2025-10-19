using Microsoft.AspNetCore.Components.QuickGrid;

namespace Mmu.CleanBlazor.Presentation2.Shared.Components.QuickGrids
{
    public partial class AppPaginator : Paginator
    {
        private bool CanGoBack => State.CurrentPageIndex > 0;
        private bool CanGoForwards => State.CurrentPageIndex < State.LastPageIndex;

        private Task GoFirstAsync()
        {
            return GoToPageAsync(0);
        }

        private Task GoPreviousAsync()
        {
            return GoToPageAsync(State.CurrentPageIndex - 1);
        }

        private Task GoNextAsync()
        {
            return GoToPageAsync(State.CurrentPageIndex + 1);
        }

        private Task GoLastAsync()
        {
            return GoToPageAsync(State.LastPageIndex.GetValueOrDefault(0));
        }

        private Task GoToPageAsync(int pageIndex)
        {
            return State.SetCurrentPageIndexAsync(pageIndex);
        }
    }
}