namespace Mmu.CleanBlazor.Common.Querying.Response
{
    public record PagedResult<T>(IReadOnlyCollection<T> Items, int TotalCount);
}