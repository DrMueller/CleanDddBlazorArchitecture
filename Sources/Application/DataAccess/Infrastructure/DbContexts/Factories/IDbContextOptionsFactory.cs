using Microsoft.EntityFrameworkCore;

namespace Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Factories
{
    public interface IDbContextOptionsFactory
    {
        DbContextOptions CreateForSqlServer(string connectionString);
    }
}