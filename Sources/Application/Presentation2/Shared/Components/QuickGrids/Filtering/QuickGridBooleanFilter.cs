namespace Mmu.CleanBlazor.Presentation2.Shared.Components.QuickGrids.Filtering
{
    public class QuickGridBooleanFilter : QuickGridFilter<bool?>
    {
        public bool? Value { get; set; }
        protected override bool IsFilterSet => Value.HasValue;

        public override void ClearFilter()
        {
            Value = null;
        }

        public override bool ApplyFilter(bool? value)
        {
            if (!IsFilterSet)
            {
                return true;
            }

            return value == Value;
        }
    }
}
