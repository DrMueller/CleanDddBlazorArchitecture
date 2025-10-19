using Microsoft.AspNetCore.Components;

namespace Mmu.CleanBlazor.Presentation2.Shared.Components.QuickGrids.Filtering.Filters
{
    public partial class BooleanFilter
    {
        private const string NullValue = "null";

        [Parameter]
        [EditorRequired]
        public bool? Value { get; set; }

        [Parameter]
        public EventCallback<bool?> ValueChanged { get; set; }

        private string ValueString
        {
            get => Value?.ToString().ToLower() ?? NullValue;
            set
            {
                Value = value switch
                {
                    "true" => true,
                    "false" => false,
                    _ => null
                };
            }
        }

        private async Task SetValueStringAsync(string value)
        {
            ValueString = value;
            await ValueChanged.InvokeAsync(Value);
        }
    }
}