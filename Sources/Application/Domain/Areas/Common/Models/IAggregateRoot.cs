using System.Diagnostics.CodeAnalysis;

namespace Mmu.CleanBlazor.Domain.Areas.Common.Models
{
    [SuppressMessage("Design", "CA1040:Avoid empty interfaces", Justification = "Marker interface")]
    public interface IAggregateRoot
    {
    }
}