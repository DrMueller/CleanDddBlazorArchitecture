using Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.LoadOverview.Response;

namespace Mmu.CleanBlazor.Presentation2.Areas.Individuals.Overview;

public class IndividualOverviewEntryVm
{
    public required DateTime BirthDate { get; init; }
    public required string FirstName { get; init; }
    public required string GenderDescription { get; init; }
    public required long IndividualId { get; init; }
    public required string LastName { get; init; }
    public required double Length { get; init; }

    public static IndividualOverviewEntryVm MapFromEntry(IndividualOverviewEntry entry)
    {
        return new IndividualOverviewEntryVm
        {
            BirthDate = entry.BirthDate,
            FirstName = entry.FirstName,
            GenderDescription = entry.GenderDescription,
            IndividualId = entry.IndividualId,
            LastName = entry.LastName,
            Length = entry.Length
        };
    }
}