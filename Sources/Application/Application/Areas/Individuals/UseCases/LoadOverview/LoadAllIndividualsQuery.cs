using Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.LoadOverview.Response;
using Mmu.CleanBlazor.Application.Infrastructure.Mediation.Models;

namespace Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.LoadOverview
{
    public class LoadAllIndividualsQuery : IQuery<IReadOnlyCollection<IndividualOverviewEntry>>
    {
    }
}