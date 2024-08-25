using JetBrains.Annotations;
using Mmu.CleanBlazor.Common.Logging;

namespace Mmu.CleanBlazor.Presentation2.QualityTests.TestingInfrastructure.Mocks
{
    [UsedImplicitly]
    public class LoggingServiceMock : ILoggingService
    {
        public Exception? LoggedException { get; private set; }

        public void LogError(string message)
        {
        }

        public void LogException(Exception ex)
        {
            LoggedException = ex;
        }

        public void LogInformation(string message)
        {
        }
    }
}