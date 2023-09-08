using Mmu.CleanBlazor.Common.LanguageExtensions.Invariance;
using Mmu.CleanBlazor.Domain.Areas.Common.Models;

namespace Mmu.CleanBlazor.Domain.Areas.Individuals.Models;

public class Organisation : AggregateRoot
{
    public string Name { get; }

    public Organisation(string name)
    {
        Guard.StringNotNullOrEmpty(() => name);
        Name = name;
    }
}