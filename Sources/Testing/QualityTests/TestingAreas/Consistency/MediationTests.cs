using FluentAssertions;
using Mmu.CleanBlazor.Application.Infrastructure.Mediation.Models;
using Mmu.CleanBlazor.Application.Infrastructure.Mediation.Services;
using Mmu.CleanBlazor.QualityTests.TestingInfrastructure;
using NetArchTest.Rules;
using Xunit;

namespace Mmu.CleanBlazor.QualityTests.TestingAreas.Consistency
{
    public class MediationTests
    {
        [Fact]
        public void All_requests_are_records()
        {
            var requestTypes = Types.InAssembly(typeof(IMediationService).Assembly)
                .That()
                .ImplementInterface(typeof(ICommand))
                .Or().ImplementInterface(typeof(ICommand<>))
                .Or().ImplementInterface(typeof(IQuery<>))
                .GetTypes()
                .ToList();

            requestTypes.Should().NotBeNullOrEmpty();

            var nonRecordRequestTypes = requestTypes
                .Where(f => !f.IsRecord())
                .Select(f => f.Name);

            nonRecordRequestTypes.Should().BeEmpty();
        }
    }
}