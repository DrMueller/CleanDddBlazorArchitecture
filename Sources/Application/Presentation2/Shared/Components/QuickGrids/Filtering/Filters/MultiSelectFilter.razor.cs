using Microsoft.AspNetCore.Components;
using Mmu.CleanBlazor.Presentation2.Shared.Components.SelectElements.MultiSelection;

namespace Mmu.CleanBlazor.Presentation2.Shared.Components.QuickGrids.Filtering.Filters
{
    public partial class MultiSelectFilter
    {
        [Parameter]
        [EditorRequired]
        public required IEnumerable<ItemWithIdAndNameViewModel> Items { get; set; }

        [Parameter]
        [EditorRequired]
        public required List<int> SelectedIds { get; set; }

        private IReadOnlyCollection<ItemWithIdAndNameViewModel> DistinctItems => Items
            .OrderBy(f => f.Name)
            .DistinctBy(f => f.Id)
            .ToList();

        [Parameter]
        public EventCallback<List<int>> SelectedIdsChanged { get; set; }

        private Task HandleValueChangedAsync(List<int> arg)
        {
            SelectedIds = arg;
            return SelectedIdsChanged.InvokeAsync(arg);
        }

        private async Task ClearAsync()
        {
            await HandleValueChangedAsync(new List<int>());
        }
    }
}