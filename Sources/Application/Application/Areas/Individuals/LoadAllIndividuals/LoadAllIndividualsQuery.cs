using Mmu.CleanBlazor.Application.Infrastructure.Mediation.Models;

namespace Mmu.CleanBlazor.Application.Areas.Individuals.LoadAllIndividuals
{
    public class LoadAllIndividualsQuery : IQuery<IReadOnlyCollection<IndividualResultDto>>
    {
    }
}