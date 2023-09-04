using Microsoft.EntityFrameworkCore;
using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Contexts;
using Mmu.CleanBlazor.DataAccess.Infrastructure.Services;
using Mmu.CleanBlazor.DataAccess.Infrastructure.UnitOfWorks.Servants;
using Mmu.CleanBlazor.Domain.Areas.Common.Models;
using Mmu.CleanBlazor.Domain.Areas.Common.Models.Technical;
using Mmu.CleanBlazor.Domain.Infrastructure.Data.Repositories;
using Mmu.CleanBlazor.Domain.Infrastructure.Data.UnitOfWorks;

namespace Mmu.CleanBlazor.DataAccess.Infrastructure.UnitOfWorks.Implementation
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly IRepositoryCache _repoCache;
        private readonly IDomainEventDispatcher _domainEventDispatcher;
        private IAppDbContext _dbContext = null!;

        public UnitOfWork(
            IRepositoryCache repoCache,
            IDomainEventDispatcher domainEventDispatcher)
        {
            _repoCache = repoCache;
            _domainEventDispatcher = domainEventDispatcher;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public TRepo GetRepository<TRepo>() where TRepo : IRepository
        {
            return _repoCache.GetRepository<TRepo>(_dbContext);
        }

        public void Initialize(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveAsync()
        {
            SetTechnicalFields();
            await _dbContext.SaveChangesAsync();
            await _domainEventDispatcher.DispatchEventsAsync(_dbContext);
        }

        private void SetTechnicalFields()
        {
            var entries = _dbContext
                .ChangeTracker
                .Entries()
                .Where(e => e.State is EntityState.Added or EntityState.Modified);

            foreach (var entityEntry in entries)
            {
                if (entityEntry.Entity is Entity entity)
                {
                    var casted = (IHasTimeStamps)entity;

                    casted.UpdatedDate = DateTime.Now;

                    if (entityEntry.State == EntityState.Added)
                    {
                        casted.CreatedDate = DateTime.Now;
                    }
                }
            }
        }
    }
}