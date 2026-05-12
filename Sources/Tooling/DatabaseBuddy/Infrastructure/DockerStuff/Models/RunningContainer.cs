using Mmu.CleanBlazor.Common.LanguageExtensions.Invariance;

namespace DatabaseBuddy.Infrastructure.DockerStuff.Models
{
    public class RunningContainer
    {
        public string ContainerId { get; }

        public RunningContainer(string containerId)
        {
            Guard.StringNotNullOrEmpty(() => containerId);

            ContainerId = containerId;
        }
    }
}