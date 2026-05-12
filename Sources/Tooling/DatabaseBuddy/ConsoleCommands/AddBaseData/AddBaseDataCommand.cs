using DatabaseBuddy.DataSeedings;
using DatabaseBuddy.Infrastructure.ConsoleStuff.Commands.Models;
using DatabaseBuddy.Infrastructure.DockerStuff.Containers.Services;

namespace DatabaseBuddy.ConsoleCommands.AddBaseData
{
    public class AddBaseDataCommand(
        IBaseDataDbSeeder baseDataDbSeeder,
        IContainerProvisioner containerProvisioner)
        : IConsoleCommand
    {
        public string Description => "Add base data";
        public ConsoleKey Key => ConsoleKey.F2;

        public async Task ExecuteAsync()
        {
            await containerProvisioner.AssureStartedAsync();

            await baseDataDbSeeder.SeedAsync();
        }
    }
}