using System;
using System.Threading.Tasks;

namespace DatabaseBuddy.Infrastructure.ConsoleStuff.ExecutionContext.Services
{
    public interface IConsoleActionHandler
    {
        void HandleAction(Action callback);

        Task HandleAsyncAction(Func<Task> callback);
    }
}