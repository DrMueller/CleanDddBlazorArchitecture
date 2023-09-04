using System.Linq.Expressions;
using Mmu.CleanBlazor.Domain.Areas.Individuals.Models;
using Mmu.CleanBlazor.Domain.Infrastructure.Data.Repositories;

namespace Mmu.CleanBlazor.Application.Areas.Individuals.UpdateIndividual
{
    public class LoadIndividualByIdSpec : IAggregateSpecification<Individual>
    {
        private readonly long _individualId;

        public LoadIndividualByIdSpec(long individualId)
        {
            _individualId = individualId;
        }

        public Expression<Func<Individual, bool>> Filter => ind => ind.Id == _individualId;
    }
}