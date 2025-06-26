using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Mmu.CleanBlazor.Domain.Infrastructure.Data.Querying;

namespace Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Contexts
{
    public interface IAppDbContext : IDisposable, IQueryBase
    {
        ChangeTracker ChangeTracker { get; }

        [SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "Same name as the one on the DbContext needed")]
        IDbSetProxy<TEntity> DbSet<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}