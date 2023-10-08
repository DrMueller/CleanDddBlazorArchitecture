using Microsoft.AspNetCore.Components;
using Mmu.CleanBlazor.Presentation2.Shared.Components.FormElements.Dropdowns.Generic;

namespace Mmu.CleanBlazor.Presentation2.Shared.Components.FormElements.Dropdowns.EnumDropdowns
{
    public partial class EnumDropdown<TItem> : ComponentBase
        where TItem : struct, Enum
    {
        [Parameter]
        public string ButtonText { get; set; }

        public List<DropdownItem> Items { get; set; }

        [Parameter]
        public TItem Value { get; set; }

        [Parameter]
        public EventCallback<TItem> ValueChanged { get; set; }

        protected override void OnParametersSet()
        {
            var val = Enum.GetValues(typeof(TItem));
            Items = val.Cast<TItem>().Select(f => new DropdownItem { Text = f.ToString(), Value = ((int)(object)f).ToString() }).ToList();
        }

        private async Task OnSelectionChangedAsync(DropdownItem item)
        {
            Value = Enum.Parse<TItem>(item.Value);
            await ValueChanged.InvokeAsync(Value);
        }
    }
}