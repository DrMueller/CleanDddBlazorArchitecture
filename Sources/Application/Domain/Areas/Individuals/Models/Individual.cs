using Mmu.CleanBlazor.Domain.Areas.Common.Models;

namespace Mmu.CleanBlazor.Domain.Areas.Individuals.Models;

public class Individual : AggregateRoot
{
    public DateTime BirthDate { get; set; }

    public string FirstName { get; set; }

    public Gender Gender { get; set; }

    public string LastName { get; set; }
}