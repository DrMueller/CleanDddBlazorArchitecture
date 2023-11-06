using JetBrains.Annotations;
using Lamar;
using Mmu.CleanBlazor.Common.Logging;
using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Factories;
using Mmu.CleanBlazor.Presentation2.QualityTests.TestingInfrastructure.DataAccess;
using Mmu.CleanBlazor.Presentation2.QualityTests.TestingInfrastructure.Mocks;

namespace Mmu.CleanBlazor.Presentation2.QualityTests.TestingInfrastructure
{
    [UsedImplicitly]
    public class ServiceRegistryCollection : ServiceRegistry
    {
        public ServiceRegistryCollection()
        {
            For<IAppDbContextFactory>().Use<TestAppDbContextFactory>().Singleton();

            For<ILoggingService>().Use<LoggingServiceMock>().Singleton();
        }
    }
}