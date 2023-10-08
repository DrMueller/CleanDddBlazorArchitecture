using AutoMapper;
using Microsoft.AspNetCore.Components;
using Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.DeleteIndividual;
using Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.LoadOverview;
using Mmu.CleanBlazor.Application.Infrastructure.Mediation.Services;

namespace Mmu.CleanBlazor.Presentation2.Areas.Individuals.Overview
{
    public partial class IndividualsOverview
    {
        public string InfoMessage { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public IMediationService Mediator { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ICollection<IndividualOverviewEntryVm>? OverviewEntries { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            var data = await Mediator.SendAsync(new LoadAllIndividualsQuery());
            OverviewEntries = Mapper.Map<List<IndividualOverviewEntryVm>>(data);
        }

        private async Task DeleteIndividual(long individualId)
        {
            await Mediator.SendAsync(new DeleteIndividualCommand(individualId));
            var item = OverviewEntries.Single(f => f.IndividualId == individualId);
            OverviewEntries.Remove(item);
            InfoMessage = "Individual deleted";
        }

        private void NavigateToCreate()
        {
            NavigationManager.NavigateTo("/individuals/0");
        }

        private void OnDoubleClick(long individualId)
        {
            NavigationManager.NavigateTo($"/individuals/{individualId}");
        }
    }
}