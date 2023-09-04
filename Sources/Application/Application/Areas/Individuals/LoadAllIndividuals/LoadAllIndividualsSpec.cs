using System.Linq.Expressions;
using Mmu.CleanBlazor.Domain.Areas.Individuals.Models;
using Mmu.CleanBlazor.Domain.Infrastructure.Data.Querying;

namespace Mmu.CleanBlazor.Application.Areas.Individuals.LoadAllIndividuals
{
    internal class LoadAllIndividualsSpec : IQuerySpecification<Individual, IndividualResultDto>
    {
        public Expression<Func<Individual, IndividualResultDto>> Selector
        {
            get
            {
                return ind => new IndividualResultDto
                {
                    BirthDate = ind.BirthDate,
                    FirstName = ind.FirstName,
                    GenderDescription = ind.Gender == Gender.Male ? IndividualResultDto.GenderMale : IndividualResultDto.GenderFemale,
                    LastName = ind.LastName,
                    IndividualId = ind.Id
                };
            }
        }

        public IQueryable<Individual> Apply(IQueryable<Individual> qry)
        {
            return qry.OrderBy(f => f.FirstName);
        }
    }
}