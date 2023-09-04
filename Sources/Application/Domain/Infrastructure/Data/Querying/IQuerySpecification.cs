using System.Linq.Expressions;
using Mmu.CleanBlazor.Domain.Areas.Common.Models;

namespace Mmu.CleanBlazor.Domain.Infrastructure.Data.Querying
{
    public interface IQuerySpecification<T, TResult> : IQuerySpecification<T>
        where T : Entity
    {
        Expression<Func<T, TResult>> Selector { get; }
    }

    public interface IQuerySpecification<T>
        where T : Entity
    {
        IQueryable<T> Apply(IQueryable<T> qry);
    }
}