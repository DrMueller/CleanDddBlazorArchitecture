namespace Mmu.CleanBlazor.Presentation2.Shared.Components.QuickGrids.Filtering
{
    public class QuickGridStringFilter : QuickGridFilter<string>
    {
        public string? Value { get; set; }
        protected override bool IsFilterSet => !string.IsNullOrEmpty(Value);

        public override void ClearFilter()
        {
            Value = null;
        }

        public override bool ApplyFilter(string? value)
        {
            if (!IsFilterSet)
            {
                return true;
            }

            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            return value.Contains(Value!, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}