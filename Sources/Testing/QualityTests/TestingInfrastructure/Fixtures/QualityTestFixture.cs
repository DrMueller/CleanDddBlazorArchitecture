using JetBrains.Annotations;
using Mmu.CleanBlazor.QualityTests.TestingInfrastructure.WebApp.AppFactories;

namespace Mmu.CleanBlazor.QualityTests.TestingInfrastructure.Fixtures
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