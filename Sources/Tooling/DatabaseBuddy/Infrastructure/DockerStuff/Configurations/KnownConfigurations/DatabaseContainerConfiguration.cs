using DatabaseBuddy.Infrastructure.DockerStuff.Configurations.Ports;
using Microsoft.Data.SqlClient;

namespace DatabaseBuddy.Infrastructure.DockerStuff.Configurations.KnownConfigurations
{
    public abstract class DatabaseContainerConfiguration(int hostPort, string containerName) : IContainerConfiguration
    {
        private const int ContainerPort = 1433;
        private const string SaPassword = "sTronkpassword54322!";

        public string ContainerName { get; } = containerName;

        public IReadOnlyCollection<EnvironmentVariable> EnvironmentVariables { get; } = new List<EnvironmentVariable>
        {
            new EnvironmentVariable("ACCEPT_EULA", "Y"),
            new EnvironmentVariable("SA_PASSWORD", SaPassword),
            new EnvironmentVariable("MSSQL_PID", "Express")
        };

        public abstract ImageIdentifier ImageIdentifier { get; }

        public PortConfiguration PortConfiguration => new PortConfiguration(
            new PortBinding(
                new ContainerPort(ContainerPort, ContainerPortProcotol.Tcp),
                new HostPort(hostPort, "127.0.0.1")));

        public string CreateConnectionString()
        {
            var host = PortConfiguration.Bindings.Single().HostPorts.Single().CompleteHost;

            var connectionString = $"Server={host};Database=Master;User Id=SA;Password={SaPassword};TrustServerCertificate=True";
            return connectionString;
        }
    }
}