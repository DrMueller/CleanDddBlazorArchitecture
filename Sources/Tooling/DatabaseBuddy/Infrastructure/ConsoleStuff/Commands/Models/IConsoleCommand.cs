namespace DatabaseBuddy.Infrastructure.ConsoleStuff.Commands.Models
{
    public interface IConsoleCommand
    {
        string Description { get; }
        ConsoleKey Key { get; }

        Task ExecuteAsync();
    }
}