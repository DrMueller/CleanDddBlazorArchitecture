using Mmu.CleanBlazor.Common.Settings.Provisioning.Services;

namespace DatabaseBuddy.Infrastructure.Settings
{
    public class ContainerizedDbConnectionStringProvider : IConnectionStringProvider
    {
        public string ConnectionString { get; private set; } = string.Empty;

        public void SetConnectionString(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException("Connection string cannot be null or whitespace.", nameof(connectionString));
            }

            ConnectionString = connectionString;
        }
    }
}