using Mmu.CleanBlazor.Domain.Areas.Individuals.Models;

namespace Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.LoadIndividual.Response
{
    public class IndividualDetailsEntry
    {
        public DateTime BirthDate { get; init; }

        public string FirstName { get; init; }

        public long IndividualId { get; init; }

        public string LastName { get; init; }

        public double Length { get; init; }

        public static IndividualDetailsEntry Map(Individual individual)
        {
            return new IndividualDetailsEntry
            {
                BirthDate = individual.BirthDate,
                FirstName = individual.FirstName,
                IndividualId = individual.Id,
                LastName = individual.LastName,
                Length = individual.Length
            };
        }
    }
}