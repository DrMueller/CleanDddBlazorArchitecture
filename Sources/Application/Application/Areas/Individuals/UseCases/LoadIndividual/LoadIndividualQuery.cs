using Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.LoadIndividual.Response;
using Mmu.CleanBlazor.Application.Infrastructure.Mediation.Models;

namespace Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.LoadIndividual;

public class LoadIndividualQuery : IQuery<IndividualDetailsEntry>
{
    public long IndividualId { get; }

    public LoadIndividualQuery(long individualId)
    {
        IndividualId = individualId;
    }
}