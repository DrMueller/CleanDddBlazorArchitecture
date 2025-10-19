using Microsoft.AspNetCore.Components;

namespace Mmu.CleanBlazor.Presentation2.Shared.Components.QuickGrids.Filtering
{
    public partial class ClearFilterButton
    {
        [Parameter]
        [EditorRequired]
        public EventCallback OnClearRequested { get; set; }
    }
}
