using AutoMapper;
using JetBrains.Annotations;
using Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.LoadIndividual.Response;
using Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.LoadOverview.Response;
using Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.UpsertIndividual;
using Mmu.CleanBlazor.Presentation2.Areas.Individuals.Edit;
using Mmu.CleanBlazor.Presentation2.Areas.Individuals.Overview;

namespace Mmu.CleanBlazor.Presentation2.Areas.Individuals
{
    [UsedImplicitly]
    public class IndividualProfile : Profile
    {
        public IndividualProfile()
        {
            CreateMap<IndividualOverviewEntry, IndividualOverviewEntryVm>();
            CreateMap<IndividualDetailsEntry, IndividualVm>();
            CreateMap<IndividualVm, IndividualToUpsert>();
        }
    }
}