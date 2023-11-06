namespace Mmu.CleanBlazor.Presentation2.Shared.Components.Dialogs.ConfirmDialogs
{
    public class ConfirmationDialogResult
    {
        public bool Confirmed { get; }

        public ConfirmationDialogResult(bool confirmed)
        {
            Confirmed = confirmed;
        }
    }
}