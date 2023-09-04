using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Mmu.CleanBlazor.Common.LanguageExtensions.Types.Maybes;
using Mmu.CleanBlazor.Domain.Areas.Common.Models;

namespace Mmu.CleanBlazor.Domain.Infrastructure.Data.Repositories
{
    [SuppressMessage("Design", "CA1040:Avoid empty interfaces", Justification = "Marker interface for easier generic handling")]
    public interface IRepository
    {
    }
}