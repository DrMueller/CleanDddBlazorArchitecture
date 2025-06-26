using Mmu.CleanBlazor.Common.LanguageExtensions.Types.Maybes;
using Mmu.CleanBlazor.Common.LanguageExtensions.Types.Maybes.Implementation;
using Mmu.CleanBlazor.Domain.Areas.Individuals.Models;
using Mmu.CleanBlazor.Domain.Infrastructure.Data.Querying;

namespace Mmu.CleanBlazor.Domain.Areas.Individuals.Specifications;

public class IndividualSpec : IQuerySpecification<Individual>
{
    private readonly Maybe<long> _individualId = None.Value;

    public IndividualSpec()
    {
    }

    public IndividualSpec(long individualId)
    {
        _individualId = individualId;
    }

    public IQueryable<Individual> Apply(IQueryBase queryBase)
    {
        var indQuery = queryBase.Query<Individual>();

        _individualId.WhenSome(indId => indQuery = indQuery.Where(f => f.Id == indId));

        return indQuery;
    }
}