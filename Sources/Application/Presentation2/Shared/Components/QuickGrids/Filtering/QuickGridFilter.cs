using JetBrains.Annotations;

namespace Mmu.CleanBlazor.Presentation2.Shared.Components.QuickGrids.Filtering
{
    [PublicAPI("Next PR")]
    public abstract class QuickGridFilter<T>
    {
        public string CssClass => IsFilterSet ? "filtered" : string.Empty;

        protected abstract bool IsFilterSet { get; }

        public abstract void ClearFilter();

        public abstract bool ApplyFilter(T? value);
    }

    public static class QuickGridFilter
    {
        public static QuickGridStringFilter CreateForString()
        {
            return new QuickGridStringFilter();
        }

        public static QuickGridDateRangeFilter CreateForDateRange()
        {
            return new QuickGridDateRangeFilter();
        }

        public static QuickGridBooleanFilter CreateForBoolean()
        {
            return new QuickGridBooleanFilter();
        }

        public static QuickgridListFilter<T> CreateForList<T>()
        {
            return new QuickgridListFilter<T>();
        }

        public static QuickgridMultiListFilter<T> CreateForMultiList<T>()
        {
            return new QuickgridMultiListFilter<T>();
        }
    }
}