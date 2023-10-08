namespace Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.LoadIndividual.Response
{
    public class IndividualDetailsEntry
    {
        public DateTime BirthDate { get; init; }

        public string FirstName { get; init; }

        public long IndividualId { get; init; }

        public string LastName { get; init; }

        public double Length { get; init; }
    }
}