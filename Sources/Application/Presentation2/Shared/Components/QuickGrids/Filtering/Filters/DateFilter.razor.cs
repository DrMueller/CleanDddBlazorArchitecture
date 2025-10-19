using Microsoft.AspNetCore.Components;

namespace Mmu.CleanBlazor.Presentation2.Shared.Components.QuickGrids.Filtering.Filters
{
    public partial class DateFilter
    {
        [Parameter]
        [EditorRequired]
        public DateTime? Value { get; set; }

        [Parameter]
        public EventCallback<DateTime?> ValueChanged { get; set; }

        private async Task HandleDateChangedAsync(DateTime? arg)
        {
            Value = arg;
            await ValueChanged.InvokeAsync(arg);
        }

        private async Task ClearAsync()
        {
            await HandleDateChangedAsync(null);
        }
    }
}
