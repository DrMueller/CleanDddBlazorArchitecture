using Microsoft.AspNetCore.Components;

namespace Mmu.CleanBlazor.Presentation2.Infrastructure.JavaScript.Services
{
    public interface IJavaScriptLocator
    {
        Task<string> LocateJsFilePathAsync<T>()
            where T : ComponentBase;
    }
}