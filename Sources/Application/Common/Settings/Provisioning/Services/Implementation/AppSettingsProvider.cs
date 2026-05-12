using Microsoft.Extensions.Options;
using Mmu.CleanBlazor.Common.Settings.Provisioning.Models;

namespace Mmu.CleanBlazor.Common.Settings.Provisioning.Services.Implementation
{
    public class AppSettingsProvider(IOptions<AppSettings> settings) : IAppSettingsProvider, IConnectionStringProvider
    {
        public AppSettings Settings => settings.Value;

        public string ConnectionString => settings.Value.ConnectionString;
    }
}