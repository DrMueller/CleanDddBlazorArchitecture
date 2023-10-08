using Mmu.CleanBlazor.Presentation2.Areas.Individuals.Edit;

namespace Mmu.CleanBlazor.Presentation2.Areas.Individuals.Common.Services
{
    public interface IIndividualService
    {
        Task<IndividualVm> LoadAsync(long id);
        Task SaveAsync(IndividualVm individual);
    }
}