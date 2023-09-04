using Mmu.CleanBlazor.Domain.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Mmu.CleanBlazor.Domain.Areas.Common.Models;

namespace Mmu.CleanBlazor.Domain.Areas.Common.Specifications
{
    public class LoadAggregateByIdSpec<T> : IAggregateSpecification<T>
        where T : AggregateRoot
    {
        private readonly long _id;

        public LoadAggregateByIdSpec(long id)
        {
            _id = id;
        }

        public Expression<Func<T, bool>> Filter => t => t.Id == _id;
    }
}
