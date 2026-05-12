using System.Diagnostics.CodeAnalysis;
using DatabaseBuddy.Infrastructure.ConsoleStuff.ExceptionHandling.Services;

namespace DatabaseBuddy.Infrastructure.ConsoleStuff.ExecutionContext.Services.Implementation
{
    internal class ConsoleActionHandler(IExceptionHandler exceptionHandler) : IConsoleActionHandler
    {
        [SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Wanted here")]
        public void HandleAction(Action callback)
        {
            try
            {
                callback();
            }
            catch (Exception ex)
            {
                exceptionHandler.HandleException(ex);
            }
        }

        [SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Wanted here")]
        public async Task HandleAsyncAction(Func<Task> callback)
        {
            try
            {
                await callback();
            }
            catch (Exception ex)
            {
                exceptionHandler.HandleException(ex);
            }
        }
    }
}