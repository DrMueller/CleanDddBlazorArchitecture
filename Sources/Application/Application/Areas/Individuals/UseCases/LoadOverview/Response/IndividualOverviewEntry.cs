using JetBrains.Annotations;

namespace Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.LoadOverview.Response
{
    [PublicAPI]
    public class IndividualOverviewEntry
    {
        public const string GenderFemale = "Female";
        public const string GenderMale = "Male";

        public DateTime BirthDate { get; set; }

        public string FirstName { get; set; }

        public string GenderDescription { get; set; }

        public long IndividualId { get; set; }

        public string LastName { get; set; }

        public double Length { get; set; }
    }
}