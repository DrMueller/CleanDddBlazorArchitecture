using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Mmu.CleanBlazor.Common.Settings.Provisioning.Models;
using System.Reflection;

namespace Mmu.CleanBlazor.Common.Settings.Config.Services
{
    public static class ConfigurationFactory
    {
        public static IConfiguration Create()
        {
            var path = Path.GetDirectoryName(typeof(ConfigurationFactory).Assembly.Location);

            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(path!)
                .AddJsonFile("appsettings.json", false, true);

            var isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

            if (isDevelopment)
            {
                configBuilder.AddUserSecrets(typeof(ConfigurationFactory).Assembly);
            }

            return configBuilder.Build();
        }
    }
}