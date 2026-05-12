using DatabaseBuddy.DataSeedings;
using DatabaseBuddy.DataSeedings.Implementation;
using DatabaseBuddy.Infrastructure.ConsoleStuff.Commands.Models;
using DatabaseBuddy.Infrastructure.ConsoleStuff.Commands.Services;
using DatabaseBuddy.Infrastructure.ConsoleStuff.Commands.Services.Implementation;
using DatabaseBuddy.Infrastructure.ConsoleStuff.Commands.Services.Servants;
using DatabaseBuddy.Infrastructure.ConsoleStuff.Commands.Services.Servants.Implementation;
using DatabaseBuddy.Infrastructure.ConsoleStuff.ExceptionHandling.Services;
using DatabaseBuddy.Infrastructure.ConsoleStuff.ExceptionHandling.Services.Implementation;
using DatabaseBuddy.Infrastructure.ConsoleStuff.ExecutionContext.Services;
using DatabaseBuddy.Infrastructure.ConsoleStuff.ExecutionContext.Services.Implementation;
using DatabaseBuddy.Infrastructure.DockerStuff.Services;
using DatabaseBuddy.Infrastructure.DockerStuff.Services.Implementation;
using DatabaseBuddy.Infrastructure.DockerStuff.Services.NativeProxies;
using DatabaseBuddy.Infrastructure.DockerStuff.Services.NativeProxies.Implementation;
using DatabaseBuddy.Infrastructure.Settings;
using Lamar;
using Mmu.CleanBlazor.Common.Settings.Provisioning.Services;

namespace DatabaseBuddy.Infrastructure
{
    public class ServiceRegistryCollection : ServiceRegistry
    {
        public ServiceRegistryCollection()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType<ServiceRegistryCollection>();
                scanner.AddAllTypesOf<IConsoleCommand>();
            });

            RegisterDbSeeders();
            RegisterDockerStuff();
            RegisterConsoleStuff();

            For<IConnectionStringProvider>().Use<ContainerizedDbConnectionStringProvider>().Singleton();
        }

        private void RegisterConsoleStuff()
        {
            For<IConsoleCommandsContainer>().Use<ConsoleCommandsContainer>().Singleton();
            For<IConsoleActionHandler>().Use<ConsoleActionHandler>().Singleton();
            For<IExceptionHandler>().Use<ExceptionHandler>().Singleton();
            For<IConsoleCommandsStartupService>().Use<ConsoleCommandsStartupService>().Singleton();
        }

        private void RegisterDbSeeders()
        {
            For<IBaseDataDbSeeder>().Use<BaseDataDbSeeder>().Scoped();
        }

        private void RegisterDockerStuff()
        {
            For<IContainerManager>().Use<ContainerManager>().Scoped();
            For<IDockerClientFactory>().Use<DockerClientFactory>().Singleton();
        }
    }
}