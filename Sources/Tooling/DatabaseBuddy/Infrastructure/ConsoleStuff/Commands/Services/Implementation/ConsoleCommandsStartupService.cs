using DatabaseBuddy.Infrastructure.ConsoleStuff.Commands.Services.Servants;

namespace DatabaseBuddy.Infrastructure.ConsoleStuff.Commands.Services.Implementation
{
    internal class ConsoleCommandsStartupService(IConsoleCommandsContainer container) : IConsoleCommandsStartupService
    {
        public void Start()
        {
            var commandsTask = container.ShowCommands();
            Task.WaitAll(commandsTask);
        }
    }
}