using FluentAssertions;
using Mmu.CleanBlazor.Presentation2.QualityTests.TestingInfrastructure.Fixtures;
using Xunit;

namespace Mmu.CleanBlazor.Presentation2.QualityTests.TestingAreas.CrossCutting.ExceptionHandling
{
    public class ApiExceptionHandlingTests : QualityTestBase
    {
        public ApiExceptionHandlingTests(QualityTestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task CallingUnknownPage_ReturnsErorrPage_WithStatus404()
        {
            // Arrange
            using var client = AppFactory.CreateClient();

            // Act
            using var actualResult = await client.GetAsync(new Uri("notexisting/tra", UriKind.Relative));

            // Assert
            var actualErrorViewHtml = await actualResult.Content.ReadAsStringAsync();

            actualErrorViewHtml.Should().NotBeNull();

            actualErrorViewHtml.Should().Contain("<h1>404</h1>");
        }

        [Fact]
        public async Task ThrowingUncaughtException_ReturnsErrorPage_WithStatus500()
        {
            // Arrange
            using var client = AppFactory.CreateClient();

            // Act
            using var actualResult = await client.GetAsync(new Uri("api/test/exception", UriKind.Relative));

            // Assert
            var actualErrorViewHtml = await actualResult.Content.ReadAsStringAsync();

            actualErrorViewHtml.Should().NotBeNull();
        }
    }
}