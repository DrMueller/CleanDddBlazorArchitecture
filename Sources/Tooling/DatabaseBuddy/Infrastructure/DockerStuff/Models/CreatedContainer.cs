using Mmu.CleanBlazor.Common.LanguageExtensions.Invariance;

namespace DatabaseBuddy.Infrastructure.DockerStuff.Models
{
    public class CreatedContainer
    {
        public string Id { get; }

        public CreatedContainer(string id)
        {
            Guard.StringNotNullOrEmpty(() => id);

            Id = id;
        }
    }
}