using Microsoft.AspNetCore.Components;
using Mmu.CleanBlazor.Presentation2.Areas.Individuals.Common.Models;
using Mmu.CleanBlazor.Presentation2.Areas.Individuals.Common.Services;
using Mmu.CleanBlazor.Presentation2.Areas.Individuals.Edit;

namespace Mmu.CleanBlazor.Presentation2.Areas.Individuals.List.Components
{
    public partial class IndividualsListPage
    {
        [Inject]
        public required IIndividualService IndividualService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var random = new Random();

            var indVm = new IndividualVm
            {
                BirthDate = DateTime.Now.AddYears(random.Next(100)),
                FirstName = "John " + random.Next(10),
                LastName = "Doe " + random.Next(100),
                Gender = GenderVm.Male,
                Length = 180
            };

            await IndividualService.SaveAsync(indVm);
        }
    }
}