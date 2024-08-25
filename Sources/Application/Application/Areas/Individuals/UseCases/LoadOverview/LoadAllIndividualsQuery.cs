using Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.LoadOverview.Response;
using Mmu.CleanBlazor.Application.Infrastructure.Mediation.Models;

namespace Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.LoadOverview
{
    public record LoadAllIndividualsQuery : IQuery<IReadOnlyCollection<IndividualOverviewEntry>>
    {
    }
}