using DatabaseBuddy.DataSeedings;
using DatabaseBuddy.Infrastructure.ConsoleStuff.Commands.Models;
using DatabaseBuddy.Infrastructure.DockerStuff.Services;

namespace DatabaseBuddy.ConsoleCommands.AddBaseData
{
    public class AddBaseDataConsoleCommand(
        IBaseDataDbSeeder baseDataDbSeeder,
        IContainerManager containerManager)
        : IConsoleCommand
    {
        public string Description => "Add base data";
        public ConsoleKey Key => ConsoleKey.F2;

        public async Task ExecuteAsync()
        {
            await containerManager.AssureStartedAsync();

            await baseDataDbSeeder.SeedAsync();
        }
    }
}