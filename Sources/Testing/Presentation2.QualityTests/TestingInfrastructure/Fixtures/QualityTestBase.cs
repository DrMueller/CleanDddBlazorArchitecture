using Microsoft.Playwright;
using Mmu.CleanBlazor.Presentation2.QualityTests.TestingInfrastructure.DataAccess;
using Mmu.CleanBlazor.Presentation2.QualityTests.TestingInfrastructure.WebApp.AppFactories;
using Xunit;

namespace Mmu.CleanBlazor.Presentation2.QualityTests.TestingInfrastructure.Fixtures
{
    [Collection(QualityTestsCollectionFixture.CollectionName)]
    public abstract class QualityTestBase : IAsyncLifetime
    {
        private readonly QualityTestFixture _fixture;
        private IPlaywright _playwrightInstance;

        protected QualityTestAppFactory AppFactory => _fixture.AppFactory;

        protected string BaseAddress => _fixture.AppFactory.ServerAddress;
        protected IBrowser Browser { get; private set; } = null!;

        protected QualityTestBase(QualityTestFixture fixture)
        {
            TestAppDbContextFactory.InitializeName();

            _fixture = fixture;
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        public async Task InitializeAsync()
        {
            _playwrightInstance = await Playwright.CreateAsync();
            Browser = await _playwrightInstance.Chromium.LaunchAsync(new() { Headless = false });
        }
    }
}