using JetBrains.Annotations;
using Lamar;
using Mmu.CleanBlazor.Presentation2.Testing.Common.Data.EntityPersister;
using Mmu.CleanBlazor.Presentation2.Testing.Common.Data.EntityPersister.Implementation;

namespace Mmu.CleanBlazor.Presentation2.Testing.Common
{
    [UsedImplicitly]
    public class ServiceRegistryCollection : ServiceRegistry
    {
        public ServiceRegistryCollection()
        {
            For<IEntityPersister>().Use<EntityPersister>().Scoped();
        }
    }
}