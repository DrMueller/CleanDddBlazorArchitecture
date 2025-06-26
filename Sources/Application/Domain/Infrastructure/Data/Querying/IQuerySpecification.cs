using System.Linq;
using System.Linq.Expressions;
using Mmu.CleanBlazor.Domain.Areas.Common.Models;

namespace Mmu.CleanBlazor.Domain.Infrastructure.Data.Querying
{
    public interface IQuerySpecification<out TResult>
    {
        IQueryable<TResult> Apply(IQueryBase queryBase);
    }
}