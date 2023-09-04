using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Factories.Implementation
{
    public class DbContextOptionsFactory : IDbContextOptionsFactory
    {
        public DbContextOptions CreateForSqlServer(string connectionString)
        {
            var configuration = SqlServerConventionSetBuilder.Build();
            var mb = new ModelBuilder(configuration);
            mb.ApplyConfigurationsFromAssembly(typeof(AppDbContextFactory).Assembly);

            return new DbContextOptionsBuilder()
                //.UseSqlServer(connectionString)
                .UseInMemoryDatabase("Tra")
                .UseModel(mb.FinalizeModel())
                .Options;
        }
    }
}