using Mmu.CleanBlazor.Domain.Areas.Common.Models;
using Mmu.CleanBlazor.Domain.Areas.Individuals.Events;

namespace Mmu.CleanBlazor.Domain.Areas.Individuals.Models;

public class Individual : AggregateRoot
{
    public DateTime BirthDate { get; set; }

    public string FirstName { get; set; }

    public Gender Gender { get; }

    public string LastName { get; set; }
    public double Length { get; set; }

    // User for EF Core
    private Individual(string firstName, string lastName, Gender gender, DateTime birthDate, double length)
    {
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        BirthDate = birthDate;
        Length = length;
    }

    public static Individual CreateNew(string firstName, string lastName, Gender gender, DateTime birthDate, double length)
    {
        var ind = new Individual(firstName, lastName, gender, birthDate, length);
        ind.AddDomainEvent(new IndividualAdded(ind));

        return ind;
    }

    public void MarkAsDeleted()
    {
        AddDomainEvent(new IndividualDeleted(Id));
    }
}