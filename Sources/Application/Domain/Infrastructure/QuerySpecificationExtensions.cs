using Mmu.CleanBlazor.Common.LanguageExtensions.Types.Maybes;
using Mmu.CleanBlazor.Common.Querying.Request;

namespace Mmu.CleanBlazor.Domain.Infrastructure
{
    public static class QuerySpecificationExtensions
    {
        public static IQueryable<T> ApplyPaging<T>(
            this Maybe<QuerySpecificationPage> page,
            IQueryable<T> query)
        {
            return page.Map(p =>
            {
                var skip = p.PageNumber * p.PageSize;

                return query.Skip(skip).Take(p.PageSize);
            }).Reduce(() => query);
        }

        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, IReadOnlyCollection<QuerySorting<T>> sorts)
        {
            if (!sorts.Any())
            {
                return query;
            }

            var firstSorting = sorts.ElementAt(0);

            var orderedQuery = firstSorting.Direction == QuerySortDirection.Ascending
                ? query.OrderBy(firstSorting.SortDescriptor)
                : query.OrderByDescending(firstSorting.SortDescriptor);

            foreach (var sort in sorts.Skip(1))
            {
                orderedQuery = sort.Direction == QuerySortDirection.Ascending
                    ? orderedQuery.ThenBy(sort.SortDescriptor)
                    : orderedQuery.ThenByDescending(sort.SortDescriptor);
            }

            return orderedQuery;
        }
    }
}