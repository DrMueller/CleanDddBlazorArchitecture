using Microsoft.Playwright;
using Mmu.CleanBlazor.Presentation2.Areas.Test.Components;
using Mmu.CleanBlazor.Presentation2.QualityTests.TestingInfrastructure.Fixtures;
using Xunit;

namespace Mmu.CleanBlazor.Presentation2.QualityTests.TestingAreas.CrossCutting.ExceptionHandling
{
    public class BlazorExceptionHandlingTests : QualityTestBase
    {
        public BlazorExceptionHandlingTests(QualityTestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task ThrowingUncaughtException_ShowsError()
        {
            // Arrange
            var page = await Browser.NewPageAsync();

            // Act
            await page.GotoAsync($"{BaseAddress}test");

            // Assert
            await Assertions.Expect(page.Locator("p.ErrorUI").First).ToHaveTextAsync(TestPage.ExceptionMessage);
        }
    }
}