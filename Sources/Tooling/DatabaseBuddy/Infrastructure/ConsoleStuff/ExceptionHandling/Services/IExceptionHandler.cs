using System;

namespace DatabaseBuddy.Infrastructure.ConsoleStuff.ExceptionHandling.Services
{
    public interface IExceptionHandler
    {
        void HandleException(Exception exception);
    }
}