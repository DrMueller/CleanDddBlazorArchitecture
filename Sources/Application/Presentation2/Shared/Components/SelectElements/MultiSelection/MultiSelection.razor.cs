using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Mmu.CleanBlazor.Presentation2.Shared.Components.SelectElements.MultiSelection
{
    public partial class MultiSelection<TItem, TValue> : InputBase<List<TValue>>
    {
        private bool _dropdownVisible;

        [Parameter]
        [EditorRequired]
        public required IEnumerable<TItem> Options { get; set; }

        [Parameter]
        [EditorRequired]
        public required Func<TItem, TValue> IdSelector { get; set; }

        [Parameter]
        [EditorRequired]
        public required Func<TItem, string> TextSelector { get; set; }

        [Parameter]
        public string ElementId { get; set; } = Guid.NewGuid().ToString();

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public string DataTestId { get; set; } = string.Empty;

        private IReadOnlyCollection<TValue> SelectedValues => Value ?? [];

        private IReadOnlyCollection<string> SelectedLabels => Options
            .Where(o => SelectedValues.Contains(IdSelector(o)))
            .Select(TextSelector)
            .ToList();

        private void ToggleDropdown()
        {
            _dropdownVisible = !_dropdownVisible;
        }

        private async Task ToggleSelectionAsync(TValue value)
        {
            var list = Value?.ToList() ?? [];

            if (list.Contains(value))
            {
                list.Remove(value);
            }
            else
            {
                list.Add(value);
            }

            Value = list;
            await ValueChanged.InvokeAsync(Value);
            EditContext.NotifyFieldChanged(FieldIdentifier);
        }

        protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out List<TValue> result, [NotNullWhen(false)] out string? validationErrorMessage)
        {
            result = new List<TValue>();
            validationErrorMessage = "";
            return true;
        }
    }
}