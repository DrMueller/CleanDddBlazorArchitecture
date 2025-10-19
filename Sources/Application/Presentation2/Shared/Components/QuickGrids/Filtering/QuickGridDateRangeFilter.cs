namespace Mmu.CleanBlazor.Presentation2.Shared.Components.QuickGrids.Filtering
{
    public class QuickGridDateRangeFilter : QuickGridFilter<DateTime>
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        protected override bool IsFilterSet => From.HasValue || To.HasValue;

        public override void ClearFilter()
        {
            From = null;
            To = null;
        }

        public override bool ApplyFilter(DateTime value)
        {
            if (!IsFilterSet)
            {
                return true;
            }

            if (From.HasValue && value.Date < From.Value.Date)
            {
                return false;
            }

            if (To.HasValue && value.Date > To.Value.Date)
            {
                return false;
            }

            return true;
        }
    }
}