using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Mmu.CleanBlazor.Common.Logging;

namespace Mmu.CleanBlazor.Presentation.Shared
{
    public class AppErrorBoundary : ErrorBoundary
    {
        [Inject]
        required public ILoggingService LoggingService { get; set; }

        protected override Task OnErrorAsync(Exception exception)
        {
            LoggingService.LogException(exception);

            return base.OnErrorAsync(exception);
        }
    }
}