using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Mmu.CleanBlazor.Presentation2.Infrastructure.JavaScript.Services;

namespace Mmu.CleanBlazor.Presentation2.Shared.Components.QuickGrids
{
    public sealed partial class QuickGridRowClick
    {
        private IJSObjectReference? _module;

        [Parameter]
        [EditorRequired]
        public required string TableHtmlID { get; set; }

        [Parameter]
        [EditorRequired]
        public required string IdFieldClass { get; set; }

        [Parameter]
        [EditorRequired]
        public required EventCallback<string> OnRowClicked { get; set; }

        private DotNetObjectReference<QuickGridRowClick>? Instance { get; set; }

        [Inject]
        private IJavaScriptLocator JsLocator { get; set; } = null!;

        [Inject]
        private IJSRuntime? JsRuntime { get; set; }

        [JSInvokable]
        public async Task HandleRowClickedAsync(string rowId)
        {
            await OnRowClicked.InvokeAsync(rowId);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await AssureJavascriptModuleAsync();
                await _module!.InvokeVoidAsync("initialize", Instance, TableHtmlID, IdFieldClass);
            }
        }

        private async Task AssureJavascriptModuleAsync()
        {
            var jsFilePath = await JsLocator.LocateJsFilePathAsync<QuickGridRowClick>();
            _module ??= await JsRuntime!.InvokeAsync<IJSObjectReference>("import", jsFilePath);
            Instance ??= DotNetObjectReference.Create(this);
        }
    }
}