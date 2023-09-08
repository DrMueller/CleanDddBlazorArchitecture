using System.Linq.Expressions;
using Mmu.CleanBlazor.Domain.Areas.Common.Models;
using Mmu.CleanBlazor.Domain.Infrastructure.Data.Repositories;

namespace Mmu.CleanBlazor.Domain.Areas.Common.Specifications
{
    public class LoadAggregateByIdSpec<T> : IAggregateSpecification<T>
        where T : AggregateRoot
    {
        private readonly long _id;

        public Expression<Func<T, bool>> Filter => t => t.Id == _id;

        public LoadAggregateByIdSpec(long id)
        {
            _id = id;
        }
    }
}