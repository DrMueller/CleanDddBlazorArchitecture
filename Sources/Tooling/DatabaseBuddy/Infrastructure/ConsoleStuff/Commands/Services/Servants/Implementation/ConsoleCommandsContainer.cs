using DatabaseBuddy.Infrastructure.ConsoleStuff.Commands.Models;
using DatabaseBuddy.Infrastructure.ConsoleStuff.ExecutionContext.Services;
using Spectre.Console;

namespace DatabaseBuddy.Infrastructure.ConsoleStuff.Commands.Services.Servants.Implementation
{
    internal class ConsoleCommandsContainer : IConsoleCommandsContainer
    {
        private readonly IConsoleActionHandler _consoleActionHandler;
        private readonly IReadOnlyCollection<IConsoleCommand> _consoleCommands;

        public ConsoleCommandsContainer(IEnumerable<IConsoleCommand> consoleCommands, IConsoleActionHandler consoleActionHandler)
        {
            _consoleActionHandler = consoleActionHandler;
            _consoleCommands = consoleCommands.OrderBy(c => c.Key).ToList();
        }

        public async Task ShowCommands()
        {
            await ListenForInputs();
        }

        private void DisplayCommands()
        {
            AnsiConsole.WriteLine(new string('-', 57));

            foreach (var command in _consoleCommands)
            {
                AnsiConsole.MarkupLine($"[green]{command.Key}[/] - [white]{command.Description}[/]");
            }
        }

        // ReSharper disable once FunctionRecursiveOnAllPaths
        private async Task ListenForInputs()
        {
            await _consoleActionHandler.HandleAsyncAction(async () =>
            {
                DisplayCommands();
                Console.WriteLine();

                var keyInfo = Console.ReadKey(true);

                var command = _consoleCommands.FirstOrDefault(f => f.Key == keyInfo.Key);
                if (command == null)
                {
                    AnsiConsole.WriteLine($"No Command for {keyInfo.Key} found!");
                    await ListenForInputs();
                }

                var executingInfo = $"{DateTime.Now.ToLongTimeString()}: Executing {keyInfo.Key}..";
                await AnsiConsole.Status()
                    .Spinner(Spinner.Known.Circle)
                    .StartAsync(executingInfo, async _ => await command!.ExecuteAsync());

                AnsiConsole.WriteLine($"{DateTime.Now.ToLongTimeString()}: Execution of {keyInfo.Key} finished.");
                AnsiConsole.WriteLine();
                AnsiConsole.WriteLine();
            });

            await ListenForInputs();
        }
    }
}