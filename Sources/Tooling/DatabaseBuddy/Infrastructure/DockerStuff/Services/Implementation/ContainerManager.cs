using DatabaseBuddy.Infrastructure.DockerStuff.Services;
using DatabaseBuddy.Infrastructure.DockerStuff.Services.NativeProxies;
using DatabaseBuddy.Infrastructure.Settings;
using Docker.DotNet.Models;
using Mmu.CleanBlazor.Common.Settings.Provisioning.Services;
using Testcontainers.MsSql;

namespace DatabaseBuddy.Infrastructure.DockerStuff.Services.Implementation
{
    internal class ContainerManager : IContainerManager
    {
        private const string ContainerName = "PersistentSqlContainer";
        private const string SqlServerImage = "mcr.microsoft.com/mssql/server:2022-latest";
        private readonly IDockerClientFactory _clientFactory;

        private readonly IConnectionStringProvider _connectionStringProvider;

        public ContainerManager(
            IConnectionStringProvider connectionStringProvider,
            IDockerClientFactory clientFactory)
        {
            _connectionStringProvider = connectionStringProvider;
            _clientFactory = clientFactory;
        }

        public async Task AssureStartedAsync()
        {
            var sqlContainer = new MsSqlBuilder(SqlServerImage)
                .WithName(ContainerName)
                .WithReuse(true)
                .Build();

            await sqlContainer.StartAsync();
            var connectionstring = sqlContainer.GetConnectionString();

            SetConnectionstring(connectionstring);
        }

        public async Task RemoveAsync()
        {
            var containerName = $"/{ContainerName}";

            using var client = _clientFactory.Create();

            var containers = await client.Containers.ListContainersAsync(
                new ContainersListParameters
                {
                    All = true
                });

            var container = containers.FirstOrDefault(c => c.Names.Any(n => n.Equals(containerName,
                StringComparison.OrdinalIgnoreCase)));

            if (container == null)
            {
                return;
            }

            await client.Containers.KillContainerAsync(container.ID, new ContainerKillParameters());
            await client.Containers.RemoveContainerAsync(container.ID, new ContainerRemoveParameters { Force = true });
        }

        private void SetConnectionstring(string connectionstring)
        {
            var prov = (ContainerizedDbConnectionStringProvider)_connectionStringProvider;
            prov.SetConnectionString(connectionstring);
        }
    }
}