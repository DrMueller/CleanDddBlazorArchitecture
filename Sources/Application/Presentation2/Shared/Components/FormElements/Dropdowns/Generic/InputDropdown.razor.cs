using Microsoft.AspNetCore.Components;

namespace Mmu.CleanBlazor.Presentation2.Shared.Components.FormElements.Dropdowns.Generic
{
    public partial class InputDropdown
    {
        [Parameter]
        public string ButtonText { get; set; }

        [Parameter]
        public string DropdownId { get; set; }

        [Parameter]
        public List<DropdownItem> Items { get; set; }

        [Parameter]
        public EventCallback<DropdownItem> OnSelectionChanged { get; set; }

        private async Task SelectItemAsync(DropdownItem item)
        {
            await OnSelectionChanged.InvokeAsync(item);
        }
    }
}