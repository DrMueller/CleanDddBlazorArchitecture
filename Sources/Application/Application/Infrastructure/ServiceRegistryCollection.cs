using JetBrains.Annotations;
using Lamar;
using Microsoft.Extensions.DependencyInjection;
using Mmu.CleanBlazor.Application.Infrastructure.Mediation.Services;
using Mmu.CleanBlazor.Application.Infrastructure.Mediation.Services.Implementation;

namespace Mmu.CleanBlazor.Application.Infrastructure;

[UsedImplicitly]
public class ServiceRegistryCollection : ServiceRegistry
{
    public ServiceRegistryCollection()
    {
        For<IMediationService>().Use<MediationService>()
            .Transient(); // IMPORTANT: The underlaying Mediator service is defined as Transient, we need to use that as well
        this.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<ServiceRegistryCollection>());

        this.AddAutoMapper(typeof(ServiceRegistryCollection));
    }
}