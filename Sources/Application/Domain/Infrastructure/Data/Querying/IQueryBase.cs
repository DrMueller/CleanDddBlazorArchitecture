namespace Mmu.CleanBlazor.Domain.Infrastructure.Data.Querying
{
    public interface IQueryBase
    {
        IQueryable<T> Query<T>()
            where T : class;
    }
}