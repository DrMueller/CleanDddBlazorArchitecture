using System.Diagnostics.CodeAnalysis;

namespace Mmu.CleanBlazor.Domain.Infrastructure.Data.Repositories
{
    [SuppressMessage("Design", "CA1040:Avoid empty interfaces", Justification = "Marker interface for easier generic handling")]
    public interface IRepository
    {
    }
}