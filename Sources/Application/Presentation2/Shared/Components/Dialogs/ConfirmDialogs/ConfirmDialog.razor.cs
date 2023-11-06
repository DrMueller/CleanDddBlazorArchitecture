using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Mmu.CleanBlazor.Presentation2.Shared.Components.Dialogs.ConfirmDialogs
{
    public partial class ConfirmDialog
    {
        private IJSObjectReference? _module;
        private TaskCompletionSource<ConfirmationDialogResult>? _taskCompletionSource;

        [Parameter]
        required public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Title { get; set; } = string.Empty;

        [Inject]
        private IJSRuntime? JsRuntime { get; set; }

        public async Task<ConfirmationDialogResult> ShowAsync()
        {
            await OpenAsync();
            _taskCompletionSource = new TaskCompletionSource<ConfirmationDialogResult>();
            var task = _taskCompletionSource.Task;

            return await task;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await AssureJavascriptModuleAsync();
            }
        }

        private async Task AssureJavascriptModuleAsync()
        {
            _module ??= await JsRuntime!.InvokeAsync<IJSObjectReference>("import", "./Shared/Components/Dialogs/ConfirmDialogs/ConfirmDialog.razor.js");
        }

        private void CloseDialog(bool confirmed)
        {
            _taskCompletionSource!.SetResult(new ConfirmationDialogResult(confirmed));
        }

        private async Task OpenAsync()
        {
            await _module!.InvokeVoidAsync("showDialog");
        }
    }
}