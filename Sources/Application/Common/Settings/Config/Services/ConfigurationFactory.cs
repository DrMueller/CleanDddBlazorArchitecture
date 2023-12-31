using Microsoft.Extensions.Configuration;
using Mmu.CleanBlazor.Common.Settings.Provisioning.Models;

namespace Mmu.CleanBlazor.Common.Settings.Config.Services
{
    public static class ConfigurationFactory
    {
        public static IConfiguration Create()
        {
            var configBuilder = new ConfigurationBuilder();
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            configBuilder
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", true, false);

            if (environment == "Development")
            {
                configBuilder.AddUserSecrets<AppSettings>();
            }

            return configBuilder.Build();
        }
    }
}