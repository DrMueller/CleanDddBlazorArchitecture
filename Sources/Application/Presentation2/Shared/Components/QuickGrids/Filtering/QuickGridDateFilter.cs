namespace Mmu.CleanBlazor.Presentation2.Shared.Components.QuickGrids.Filtering
{
    public class QuickGridDateFilter : QuickGridFilter<DateTime?>
    {
        public DateTime? Value { get; set; }

        protected override bool IsFilterSet => Value != null;

        public override void ClearFilter()
        {
            Value = null;
        }

        public override bool ApplyFilter(DateTime? value)
        {
            if (!IsFilterSet)
            {
                return true;
            }

            if (value == null)
            {
                return false;
            }

            return Value!.Value.Date == value.Value.Date;
        }
    }
}