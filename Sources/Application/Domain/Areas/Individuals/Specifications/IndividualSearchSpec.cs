using Mmu.CleanBlazor.Common.LanguageExtensions.Types.Maybes;
using Mmu.CleanBlazor.Common.Querying.Request;
using Mmu.CleanBlazor.Domain.Areas.Individuals.Models;
using Mmu.CleanBlazor.Domain.Infrastructure;
using Mmu.CleanBlazor.Domain.Infrastructure.Data.Querying;

namespace Mmu.CleanBlazor.Domain.Areas.Individuals.Specifications
{
    public class IndividualSearchSpec : IQuerySpecification<Individual>
    {
        private readonly string? _firstNameFilter;
        private readonly string? _lastNameFilter;
        private readonly Maybe<QuerySpecificationPage> _page;
        private readonly IReadOnlyCollection<QuerySorting<Individual>> _sortings;

        public IndividualSearchSpec(
            string? firstNameFilter,
            string? lastNameFilter,
            Maybe<QuerySpecificationPage> page,
            IReadOnlyCollection<QuerySorting<Individual>> sortings)
        {
            _firstNameFilter = firstNameFilter;
            _lastNameFilter = lastNameFilter;
            _page = page;
            _sortings = sortings;
        }

        public IQueryable<Individual> Apply(IQueryBase queryBase)
        {
            var indQuery = queryBase.Query<Individual>();

            if (!string.IsNullOrEmpty(_firstNameFilter))
            {
                indQuery = indQuery.Where(f => f.FirstName.Contains(_firstNameFilter));
            }

            if (!string.IsNullOrEmpty(_lastNameFilter))
            {
                indQuery = indQuery.Where(f => f.LastName.Contains(_lastNameFilter));
            }

            indQuery = indQuery.ApplySorting(_sortings);
            indQuery = _page.ApplyPaging(indQuery);

            return indQuery;
        }
    }
}