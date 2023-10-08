using Microsoft.AspNetCore.Components;

namespace Mmu.CleanBlazor.Presentation2.Shared.Components.LoadingIndication
{
    public partial class LoadingIndicator
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public bool IsLoading { get; set; }
    }
}