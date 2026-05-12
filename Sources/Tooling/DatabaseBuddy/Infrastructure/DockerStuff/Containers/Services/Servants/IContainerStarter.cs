using DatabaseBuddy.Infrastructure.DockerStuff.Containers.Models;
using Mmu.CleanBlazor.Common.LanguageExtensions.Types.Eithers;

namespace DatabaseBuddy.Infrastructure.DockerStuff.Containers.Services.Servants
{
    public interface IContainerStarter
    {
        Task<Either<ContainerErrors, RunningContainer>> StartContainerAsync(string containerId);
    }
}