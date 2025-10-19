using Microsoft.AspNetCore.Components;

namespace Mmu.CleanBlazor.Presentation2.Shared.Components.QuickGrids.Filtering.Filters
{
    public partial class DateRangeFilter
    {
        [Parameter]
        [EditorRequired]
        public DateTime? From { get; set; }

        [Parameter]
        [EditorRequired]
        public DateTime? To { get; set; }

        [Parameter]
        public EventCallback<DateTime?> FromChanged { get; set; }

        [Parameter]
        public EventCallback<DateTime?> ToChanged { get; set; }

        private async Task ClearAsync()
        {
            await HandleFromChangedAsync(null);
            await HandleToChangedAsync(null);
        }

        private async Task HandleFromChangedAsync(DateTime? arg)
        {
            From = arg;
            await FromChanged.InvokeAsync(arg);
        }

        private async Task HandleToChangedAsync(DateTime? arg)
        {
            To = arg;
            await ToChanged.InvokeAsync(arg);
        }
    }
}