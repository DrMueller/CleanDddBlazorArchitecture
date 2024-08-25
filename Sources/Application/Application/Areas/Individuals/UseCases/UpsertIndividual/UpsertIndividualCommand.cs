using Mmu.CleanBlazor.Application.Infrastructure.Mediation.Models;

namespace Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.UpsertIndividual
{
    public record UpsertIndividualCommand(IndividualToUpsert Individual) : ICommand;
}