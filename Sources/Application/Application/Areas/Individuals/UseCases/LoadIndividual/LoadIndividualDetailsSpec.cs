using System.Linq.Expressions;
using Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.LoadIndividual.Response;
using Mmu.CleanBlazor.Domain.Areas.Individuals.Models;
using Mmu.CleanBlazor.Domain.Infrastructure.Data.Querying;

namespace Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.LoadIndividual;

public class LoadIndividualDetailsSpec : IQuerySpecification<Individual, IndividualDetailsEntry>
{
    private readonly long _individualId;

    public Expression<Func<Individual, IndividualDetailsEntry>> Selector => ind => new IndividualDetailsEntry
    {
        BirthDate = ind.BirthDate,
        FirstName = ind.FirstName,
        LastName = ind.LastName,
        IndividualId = ind.Id,
        Length = ind.Length
    };

    public LoadIndividualDetailsSpec(long individualId)
    {
        _individualId = individualId;
    }

    public IQueryable<Individual> Apply(IQueryable<Individual> qry)
    {
        return qry.Where(f => f.Id == _individualId);
    }
}