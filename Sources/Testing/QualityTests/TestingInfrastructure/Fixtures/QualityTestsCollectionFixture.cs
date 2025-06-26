using Xunit;

namespace Mmu.CleanBlazor.QualityTests.TestingInfrastructure.Fixtures
{
    [CollectionDefinition(CollectionName)]
    public class QualityTestsCollectionFixture : ICollectionFixture<QualityTestFixture>
    {
        public const string CollectionName = "QualityTests";
    }
}