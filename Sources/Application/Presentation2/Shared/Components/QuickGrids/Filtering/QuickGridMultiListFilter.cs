using Mmu.CleanBlazor.Presentation2.Infrastructure;

namespace Mmu.CleanBlazor.Presentation2.Shared.Components.QuickGrids.Filtering
{
    public class QuickgridMultiListFilter<T> : QuickGridFilter<IEnumerable<T>>
    {
        public List<T> Values { get; set; } = new();

        protected override bool IsFilterSet => Values.Any();

        public override void ClearFilter()
        {
            Values.Clear();
        }

        public override bool ApplyFilter(IEnumerable<T>? value)
        {
            if (!IsFilterSet || value == null)
            {
                return true;
            }

            return Values.ContainsAny(value);
        }
    }
}