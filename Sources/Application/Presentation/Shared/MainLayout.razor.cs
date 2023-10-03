using System.Diagnostics;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Mmu.CleanBlazor.Common.Logging;

namespace Mmu.CleanBlazor.Presentation.Shared
{
    public partial class MainLayout
    {
        public AppErrorBoundary? ErrorBoundary { get; set; }

        protected override void OnParametersSet()
        {
            ErrorBoundary?.Recover();
        }
    }
}
