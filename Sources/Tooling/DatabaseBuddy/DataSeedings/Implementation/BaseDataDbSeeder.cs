using Mmu.CleanBlazor.Domain.Areas.Individuals.Models;
using Mmu.CleanBlazor.Presentation2.Testing.Common.Data.EntityPersister;

namespace DatabaseBuddy.DataSeedings.Implementation
{
    public class BaseDataDbSeeder : IBaseDataDbSeeder
    {
        private readonly IEntityPersister _entityPersister;

        public BaseDataDbSeeder(
            IEntityPersister entityPersister)
        {            _entityPersister = entityPersister;
        }

        public async Task SeedAsync()
        {
            var individual = Individual.CreateNew(
                "Test1",
                "Test2",
                Gender.Female,
                DateTime.Now,
                123);

            await _entityPersister.PersistAsync(individual);
        }

    }
}