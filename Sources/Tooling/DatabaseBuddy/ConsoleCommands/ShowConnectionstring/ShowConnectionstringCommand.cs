using DatabaseBuddy.Infrastructure;
using DatabaseBuddy.Infrastructure.ConsoleStuff.Commands.Models;
using DatabaseBuddy.Infrastructure.DockerStuff.Configurations.KnownConfigurations;
using Spectre.Console;

namespace DatabaseBuddy.ConsoleCommands.ShowConnectionstring
{
    public class ShowConnectionstringCommand : IConsoleCommand
    {
        public string Description { get; } = "Show connectionstring";
        public ConsoleKey Key { get; } = ConsoleKey.F3;

        public async Task ExecuteAsync()
        {
            var config = new SqlServer2022Latest(1337, Constants.ContainerName);
            var connectionstring = config.CreateConnectionString();

            AnsiConsole.MarkupLine($"[white]{connectionstring}[/]");
        }
    }
}