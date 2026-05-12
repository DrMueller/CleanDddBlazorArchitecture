using System.Text;
using Spectre.Console;

namespace DatabaseBuddy.Infrastructure.ConsoleStuff.ExceptionHandling.Services.Implementation
{
    internal class ExceptionHandler : IExceptionHandler
    {
        public void HandleException(Exception exception)
        {
            var sb = new StringBuilder();
            sb.Append("Exception Message: ");
            sb.AppendLine(exception.Message);
            sb.Append("Exception Type: ");
            sb.AppendLine(exception.GetType().Name);
            sb.Append("Stack Trace: ");
            sb.AppendLine(exception.StackTrace);

            var str = sb.ToString();
            AnsiConsole.Write(str);
        }
    }
}