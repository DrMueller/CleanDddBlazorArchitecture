using Mmu.CleanBlazor.Domain.Areas.Individuals.Models;

namespace Mmu.CleanBlazor.Application.Areas.Individuals.CreateIndividual
{
    public class CreateIndividualRequestDto
    {
        public DateTime BirthDate { get; set; }

        public string FirstName { get; set; }

        public Gender Gender { get; set; }

        public string LastName { get; set; }
    }
}