using JetBrains.Annotations;

namespace Mmu.CleanBlazor.Common.Logging
{
    [PublicAPI]
    public interface ILoggingService
    {
        void LogError(string message);

        void LogException(Exception ex);

        void LogInformation(string message);
    }
}