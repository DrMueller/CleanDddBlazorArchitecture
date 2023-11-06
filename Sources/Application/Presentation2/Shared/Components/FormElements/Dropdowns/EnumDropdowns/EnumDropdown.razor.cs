using Microsoft.AspNetCore.Components;

namespace Mmu.CleanBlazor.Presentation2.Shared.Components.FormElements.Dropdowns.EnumDropdowns
{
    public partial class EnumDropdown<TItem> : ComponentBase
        where TItem : struct, Enum
    {
        public Array EnumValues
        {
            get
            {
                var result = Enum.GetValues(typeof(TItem));

                return result;
            }
        }

        [Parameter]
        public TItem Value { get; set; }

        [Parameter]
        public EventCallback<TItem> ValueChanged { get; set; }

        private async Task OnValueChangedAsync(ChangeEventArgs args)
        {
            Value = Enum.Parse<TItem>(args.Value!.ToString()!);
            await ValueChanged.InvokeAsync(Value);
        }
    }
}