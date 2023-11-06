////using FluentAssertions;
////using Microsoft.AspNetCore.Authorization;
////using Microsoft.AspNetCore.Mvc.Controllers;
////using Microsoft.AspNetCore.Mvc.Infrastructure;
////using modan.FK2.Presentation.Areas.Home.Controllers;
////using modan.FK2.QualityTests.TestingInfrastructure.Fixtures.Quality;
////using Xunit;

////namespace modan.FK2.QualityTests.TestingAreas.WebSecurity
////{
////    public class ControllerAuhtorizationTests : QualityTestBase
////    {
////        public ControllerAuhtorizationTests(QualityTestFixture fixture) : base(fixture)
////        {
////        }

////        [Fact]
////        public void Actions_ContainAuthorizedAttribute()
////        {
////            var authorizedAttrType = typeof(AuthorizeAttribute);

////            var knownAnonymousControllerTypes = new List<Type>
////            {
////                typeof(ErrorsController),
////                typeof(LoginController),
////                //typeof(TestController)
////            };

////            var actionDescriptorsProvider = AppFactory.Services.GetRequiredService<IActionDescriptorCollectionProvider>();
////            var controllerDescriptors = actionDescriptorsProvider.ActionDescriptors.Items.OfType<ControllerActionDescriptor>().ToList();
////            controllerDescriptors.Should().NotBeNullOrEmpty();

////            foreach (var actDesc in controllerDescriptors)
////            {
////                if (knownAnonymousControllerTypes.Contains(actDesc.ControllerTypeInfo))
////                {
////                    continue;
////                }

////                var endpointAttributes = actDesc.EndpointMetadata.OfType<Attribute>().ToList();
////                endpointAttributes.Should().Contain(attr => attr.GetType() == authorizedAttrType, $"Endpoint {actDesc.ControllerTypeInfo.Name} does not contain AuthorizeAttribute");
////            }
////        }
////    }
////}