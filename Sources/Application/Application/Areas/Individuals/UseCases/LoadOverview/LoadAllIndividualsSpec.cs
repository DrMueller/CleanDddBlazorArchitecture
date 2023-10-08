using System.Linq.Expressions;
using Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.LoadOverview.Response;
using Mmu.CleanBlazor.Domain.Areas.Individuals.Models;
using Mmu.CleanBlazor.Domain.Infrastructure.Data.Querying;

namespace Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.LoadOverview
{
    internal class LoadAllIndividualsSpec : IQuerySpecification<Individual, IndividualOverviewEntry>
    {
        public Expression<Func<Individual, IndividualOverviewEntry>> Selector
        {
            get
            {
                return ind => new IndividualOverviewEntry
                {
                    BirthDate = ind.BirthDate,
                    FirstName = ind.FirstName,
                    GenderDescription = ind.Gender == Gender.Male ? IndividualOverviewEntry.GenderMale : IndividualOverviewEntry.GenderFemale,
                    LastName = ind.LastName,
                    IndividualId = ind.Id,
                    Length = ind.Length
                };
            }
        }

        public IQueryable<Individual> Apply(IQueryable<Individual> qry)
        {
            return qry.OrderBy(f => f.FirstName);
        }
    }
}