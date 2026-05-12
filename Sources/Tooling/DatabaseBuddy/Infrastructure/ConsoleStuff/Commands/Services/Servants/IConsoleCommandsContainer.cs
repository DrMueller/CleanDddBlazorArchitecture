using System.Threading.Tasks;

namespace DatabaseBuddy.Infrastructure.ConsoleStuff.Commands.Services.Servants
{
    public interface IConsoleCommandsContainer
    {
        Task ShowCommands();
    }
}