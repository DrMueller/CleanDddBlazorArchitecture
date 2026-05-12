using JetBrains.Annotations;
using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Contexts.Implementation;
using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Factories;
using Mmu.CleanBlazor.Domain.Areas.Common.Models;

namespace Mmu.CleanBlazor.Presentation2.Testing.Common.Data.EntityPersister.Implementation
{
    [UsedImplicitly]
    public class EntityPersister(IAppDbContextFactory dbContextFactory) : IEntityPersister
    {
        // We cant use PersistAsync for code entities, as they don't have a reflected id
        public async Task InsertAsync<T>(IEnumerable<T> entities)
        {
            await using var context = (AppDbContext)dbContextFactory.Create();
            foreach (var entity in entities)
            {
                await context.AddAsync(entity!);
            }

            await context.SaveChangesAsync();
        }

        public async Task PersistAsync(params object[] entities)
        {
            var cast = entities.Cast<AggregateRoot>().ToList();
            await PersistAsync(cast);
        }

        public async Task PersistAsync<T>(IEnumerable<T> aggregateRoots) where T : AggregateRoot
        {
            await using var context = (AppDbContext)dbContextFactory.Create();

            foreach (var aggregateRoot in aggregateRoots)
            {
                if (aggregateRoot.Id == 0)
                {
                    await context.AddAsync(aggregateRoot);
                }
                else
                {
                    context.Update(aggregateRoot);
                }
            }

            await context.SaveChangesAsync();
        }
    }
}