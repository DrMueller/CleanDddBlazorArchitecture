using System.Linq.Expressions;
using Mmu.CleanBlazor.Domain.Areas.Common.Models;

namespace Mmu.CleanBlazor.Domain.Infrastructure.Data.Repositories
{
    public interface IAggregateSpecification<TAg>
        where TAg : IAggregateRoot
    {
        public Expression<Func<TAg, bool>> Filter { get; }
    }
}