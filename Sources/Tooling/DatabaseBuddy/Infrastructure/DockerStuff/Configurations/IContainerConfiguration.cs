using DatabaseBuddy.Infrastructure.DockerStuff.Configurations.Ports;

namespace DatabaseBuddy.Infrastructure.DockerStuff.Configurations
{
    public interface IContainerConfiguration
    {
        string CreateConnectionString();
        string ContainerName { get; }
        IReadOnlyCollection<EnvironmentVariable> EnvironmentVariables { get; }
        ImageIdentifier ImageIdentifier { get; }
        PortConfiguration PortConfiguration { get; }
    }
}