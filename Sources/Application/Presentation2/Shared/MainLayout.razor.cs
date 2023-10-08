namespace Mmu.CleanBlazor.Presentation2.Shared
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