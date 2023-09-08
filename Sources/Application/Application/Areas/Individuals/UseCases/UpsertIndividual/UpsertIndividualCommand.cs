using Mmu.CleanBlazor.Application.Infrastructure.Mediation.Models;

namespace Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.UpsertIndividual
{
    public class UpsertIndividualCommand : ICommand
    {
        public IndividualToUpsert Individual { get; }

        public UpsertIndividualCommand(IndividualToUpsert individual)
        {
            Individual = individual;
        }
    }
}