using DatabaseBuddy.Infrastructure.DockerStuff.Configurations;
using DatabaseBuddy.Infrastructure.DockerStuff.Containers.Models;
using Mmu.CleanBlazor.Common.LanguageExtensions.Types.Eithers;

namespace DatabaseBuddy.Infrastructure.DockerStuff.Containers.Services.Servants
{
    public interface IContainerFactory
    {
        Task<Either<ContainerErrors, CreatedContainer>> CreateIfNotExistingAsync(IContainerConfiguration containerConfig);
    }
}