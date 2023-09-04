using Mmu.CleanBlazor.Application.Infrastructure.Mediation.Models;

namespace Mmu.CleanBlazor.Application.Infrastructure.Mediation.Services
{
    public interface IMediationService
    {
        Task<T> SendAsync<T>(ICommand<T> command);

        Task SendAsync(ICommand command);

        Task<T> SendAsync<T>(IQuery<T> query);
    }
}