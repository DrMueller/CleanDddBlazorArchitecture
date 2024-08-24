using JetBrains.Annotations;
using Mmu.CleanBlazor.Presentation2.QualityTests.TestingInfrastructure.WebApp.AppFactories;

namespace Mmu.CleanBlazor.Presentation2.QualityTests.TestingInfrastructure.Fixtures
{
    [UsedImplicitly]
    public sealed class QualityTestFixture : IDisposable, IAsyncDisposable
    {
        internal QualityTestAppFactory AppFactory { get; } = new();

        public void Dispose()
        {
            AppFactory.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            await AppFactory.DisposeAsync();
        }
    }
}