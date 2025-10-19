using System.Linq.Expressions;

namespace Mmu.CleanBlazor.Common.Querying.Request
{
    public enum QuerySortDirection
    {
        Ascending,
        Descending
    }

    public record QuerySorting<T>(Expression<Func<T, object>> SortDescriptor, QuerySortDirection Direction);

    public static class QuerySorting
    {
        public static QuerySorting<T> Create<T>(string propertyName, QuerySortDirection direction)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.PropertyOrField(parameter, propertyName);

            var body = property.Type.IsValueType
                ? Expression.Convert(property, typeof(object))
                : (Expression)property;

            var expr = Expression.Lambda<Func<T, object>>(body, parameter);

            return new QuerySorting<T>(expr, direction);
        }
    }
}