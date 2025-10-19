namespace Mmu.CleanBlazor.Presentation2.Shared.Components.QuickGrids.Filtering
{
    public class QuickgridListFilter<T> : QuickGridFilter<T>
    {
        public List<T> Values { get; set; } = new();

        protected override bool IsFilterSet => Values.Any();

        public override void ClearFilter()
        {
            Values.Clear();
        }

        public override bool ApplyFilter(T? value)
        {
            if (!IsFilterSet || value == null)
            {
                return true;
            }

            return Values.Contains(value);
        }
    }
}