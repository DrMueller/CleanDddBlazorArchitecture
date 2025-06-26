using JetBrains.Annotations;
using Mmu.CleanBlazor.Domain.Areas.Individuals.Models;

namespace Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.LoadOverview.Response
{
    [PublicAPI]
    public class IndividualOverviewEntry
    {
        public const string GenderFemale = "Female";
        public const string GenderMale = "Male";

        public DateTime BirthDate { get; init; }

        public string FirstName { get; init; }

        public string GenderDescription { get; init; }

        public long IndividualId { get; init; }

        public string LastName { get; init; }

        public double Length { get; init; }

        public static IndividualOverviewEntry Map(Individual individual)
        {
            return new IndividualOverviewEntry
            {
                BirthDate = individual.BirthDate,
                FirstName = individual.FirstName,
                GenderDescription = individual.Gender == Gender.Female
                    ? GenderFemale
                    : GenderMale,
                IndividualId = individual.Id,
                LastName = individual.LastName,
                Length = individual.Length
            };
        }
    }
}