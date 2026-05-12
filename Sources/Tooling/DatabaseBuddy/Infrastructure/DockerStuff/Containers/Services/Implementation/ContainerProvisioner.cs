using DatabaseBuddy.Infrastructure.DockerStuff.Configurations;
using DatabaseBuddy.Infrastructure.DockerStuff.Configurations.KnownConfigurations;
using DatabaseBuddy.Infrastructure.DockerStuff.Containers.Services.Servants;
using DatabaseBuddy.Infrastructure.Settings;
using Microsoft.Data.SqlClient;
using Mmu.CleanBlazor.Common.LanguageExtensions.Types.Eithers;
using Mmu.CleanBlazor.Common.Settings.Provisioning.Services;

namespace DatabaseBuddy.Infrastructure.DockerStuff.Containers.Services.Implementation
{
    internal class ContainerProvisioner : IContainerProvisioner
    {
        private readonly IConnectionStringProvider _connectionStringProvider;
        private readonly IContainerFactory _containerFactory;
        private readonly IContainerStarter _containerStarter;

        public ContainerProvisioner(
            IContainerFactory containerFactory,
            IContainerStarter containerStarter,
            IConnectionStringProvider connectionStringProvider)
        {
            _containerFactory = containerFactory;
            _containerStarter = containerStarter;
            _connectionStringProvider = connectionStringProvider;
        }

        public async Task AssureStartedAsync()
        {
            var containerConfig = new SqlServer2022Latest(1337, Constants.ContainerName);

            await InitializeContainerAsync(containerConfig);
        }

        private async Task InitializeContainerAsync(IContainerConfiguration containerConfig)
        {
            var creationResult = await _containerFactory.CreateIfNotExistingAsync(containerConfig);
            var createdContainer = creationResult.ReduceRight(errors => throw new Exception(string.Join(", ", errors)));

            var startResult = await _containerStarter.StartContainerAsync(createdContainer.Id);
            startResult.ReduceRight(errors => throw new Exception(string.Join(", ", errors)));

            await WaitForSqlServerAsync(containerConfig);

            var connectionstring = containerConfig.CreateConnectionString();
            var prov = (ContainerizedDbConnectionStringProvider)_connectionStringProvider;
            prov.SetConnectionString(connectionstring);
        }

        private async Task WaitForSqlServerAsync(IContainerConfiguration containerConfig)
        {
            var start = DateTime.UtcNow;
            var timeout = TimeSpan.FromMinutes(1);

            while (DateTime.UtcNow - start < timeout)
            {
                try
                {
                    await using var connection =
                        new SqlConnection(containerConfig.CreateConnectionString());

                    await connection.OpenAsync();

                    return;
                }
                catch
                {
                    await Task.Delay(2000);
                }
            }

            throw new TimeoutException(
                "SQL Server did not become ready.");
        }
    }
}