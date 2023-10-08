using Microsoft.AspNetCore.Components;
using Mmu.CleanBlazor.Presentation2.Areas.Individuals.Common.Services;

namespace Mmu.CleanBlazor.Presentation2.Areas.Individuals.Edit;

public partial class Individual
{
    public string HeaderDescription
    {
        get
        {
            if (Id == 0)
            {
                return "New Individual";
            }

            return "Update Individual";
        }
    }

    [Parameter]
    public long Id { get; set; }

    [Inject]
    public IIndividualService IndividualService { get; set; }

    public IndividualVm? IndividualVm { get; private set; }

    public bool IsLoading => IndividualVm == null;

    [Inject]
    private NavigationManager NavigationManager { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        //await Task.Run(() => Thread.Sleep(3000));
        IndividualVm = await IndividualService.LoadAsync(Id);
    }

    private void GotoOverview()
    {
        NavigationManager.NavigateTo("/individuals");
    }

    private async Task HandleValidSubmitAsync()
    {
        await IndividualService.SaveAsync(IndividualVm);
        GotoOverview();
    }
}