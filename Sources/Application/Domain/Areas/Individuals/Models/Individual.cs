using Mmu.CleanBlazor.Domain.Areas.Common.Models;
using Mmu.CleanBlazor.Domain.Areas.Individuals.Events;

namespace Mmu.CleanBlazor.Domain.Areas.Individuals.Models;

public class Individual : AggregateRoot
{
    public DateTime BirthDate { get; set; }

    public string FirstName { get; set; }

    public Gender Gender { get; }

    public string LastName { get; set; }

    // User for EF Core
    private Individual(string firstName, string lastName, Gender gender, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        BirthDate = birthDate;
    }

    public static Individual CreateNew(string firstName, string lastName, Gender gender, DateTime birthDate)
    {
        var ind = new Individual(firstName, lastName, gender, birthDate);
        ind.AddDomainEvent(new IndividualAdded(ind));

        return ind;
    }

    public void MarkAsDeleted()
    {
        AddDomainEvent(new IndividualDeleted(Id));
    }
}