using Microsoft.AspNetCore.Components;

namespace Mmu.CleanBlazor.Presentation2.Shared.Components.QuickGrids
{
    public partial class PageSizeChooser
    {
        [Parameter]
        [EditorRequired]
        public required int ItemsPerPage { get; set; }

        [Parameter]
        public EventCallback<int> ItemsPerPageChanged { get; set; }

        private async Task HandleValueChangedAsync(int arg)
        {
            ItemsPerPage = arg;
            await ItemsPerPageChanged.InvokeAsync(arg);
        }
    }
}