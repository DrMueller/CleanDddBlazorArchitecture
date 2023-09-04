using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Contexts
{
    public interface IAppDbContext : IDisposable
    {
        ChangeTracker ChangeTracker { get; }

        [SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "Same name as the one on the DbContext needed")]
        IDbSetProxy<TEntity> DbSet<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}