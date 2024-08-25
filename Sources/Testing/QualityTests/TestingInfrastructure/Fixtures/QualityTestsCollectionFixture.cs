using Xunit;

namespace Mmu.CleanBlazor.Presentation2.QualityTests.TestingInfrastructure.Fixtures
{
    [CollectionDefinition(CollectionName)]
    public class QualityTestsCollectionFixture : ICollectionFixture<QualityTestFixture>
    {
        public const string CollectionName = "QualityTests";
    }
}