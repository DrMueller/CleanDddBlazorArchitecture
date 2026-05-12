using Docker.DotNet.Models;
using Mmu.CleanBlazor.Common.LanguageExtensions.Types.Maybes;

namespace DatabaseBuddy.Infrastructure.DockerStuff.Containers.Services.NativeProxies
{
    internal interface IDockerContainerRepository
    {
        Task<Maybe<ContainerListResponse>> FindByNameAsync(string containerName);
    }
}