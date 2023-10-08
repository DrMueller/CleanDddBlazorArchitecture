namespace Mmu.CleanBlazor.Presentation2.Areas.Individuals.Overview;

public class IndividualOverviewEntryVm
{
    required public DateTime BirthDate { get; init; }
    required public string FirstName { get; init; }
    required public string GenderDescription { get; init; }
    required public long IndividualId { get; init; }
    required public string LastName { get; init; }
    required public double Length { get; init; }
}