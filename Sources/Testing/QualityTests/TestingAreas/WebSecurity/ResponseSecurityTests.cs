//using System.Net.Http.Headers;
//using FluentAssertions;
//using modan.FK2.Presentation.Infrastructure.Security.ResponseHeader.Models;
//using modan.FK2.QualityTests.TestingInfrastructure.Fixtures.Quality;
//using modan.FK2.QualityTests.TestingInfrastructure.Startups;
//using Xunit;

// TODO
//namespace modan.FK2.QualityTests.TestingAreas.WebSecurity
//{
//    public class ResponseSecurityTests : QualityTestBase
//    {
//        private readonly QualityTestAppFactory _appFactory;

//        public ResponseSecurityTests(QualityTestFixture fixture) : base(fixture)
//        {
//            _appFactory = fixture.AppFactory;
//        }

//        [Fact]
//        public async Task CallingApi_ReturnsSecurityHeaders()
//        {
//            // Arrange
//            using var client = _appFactory.CreateClient();

//            // Act
//            using var actualResponse = await client.GetBenutzerAsync(new Uri("", UriKind.Relative));

//            // Assert
//            //AssertHeader(actualResponse.Headers, SecurityResponseHeader.ContentSecurityPolicy);
//            AssertHeader(actualResponse.Headers, SecurityResponseHeader.ContentTypeOptions);
//        }

//        private static void AssertHeader(HttpHeaders actualHeaders, SecurityResponseHeader expectedHeader)
//        {
//            var actualValues = actualHeaders.GetValues(expectedHeader.Name).ToList();
//            actualValues.Should().ContainSingle();
//            actualValues.Single().Should().Contain(expectedHeader.Value);
//        }
//    }
//}