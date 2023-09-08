using Mmu.CleanBlazor.Presentation.Areas.Individuals.Edit;

namespace Mmu.CleanBlazor.Presentation.Areas.Individuals.Common.Services
{
    public interface IIndividualService
    {
        Task<IndividualVm> LoadAsync(long id);
        Task SaveAsync(IndividualVm individual);
    }
}