using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Contexts;
using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Contexts.Implementation;
using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Factories;

namespace Mmu.CleanBlazor.Presentation2.QualityTests.TestingInfrastructure.DataAccess
{
    [UsedImplicitly]
    public class TestAppDbContextFactory : IAppDbContextFactory
    {
        private static string _databaseName = null!;

        public static void InitializeName()
        {
            _databaseName = Guid.NewGuid().ToString();

        }

        public TestAppDbContextFactory()
        {
            
        }

        public IAppDbContext Create()
        {
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(_databaseName)
                .Options;

            var context = new AppDbContext(options);
            context.Database.EnsureCreated(); // This makes sure the dataseeding of the Code-Entities (via `HasData`) is applied to the tests

            return context;
        }
    }
}