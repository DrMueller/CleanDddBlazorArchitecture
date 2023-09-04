using Mmu.CleanBlazor.Common.Settings.Provisioning.Models;

namespace Mmu.CleanBlazor.Common.Settings.Provisioning.Services
{
    public interface IAppSettingsProvider
    {
        AppSettings Settings { get; }
    }
}