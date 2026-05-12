using Mmu.CleanBlazor.Common.LanguageExtensions.Invariance;

namespace DatabaseBuddy.Infrastructure.DockerStuff.Configurations
{
    public class ImageIdentifier
    {
        public string Name { get; }
        public string Tag { get; }

        internal string CompleteIdentifier => $"{Name}:{Tag}";

        public ImageIdentifier(string name, string tag)
        {
            Guard.StringNotNullOrEmpty(() => name);
            Guard.StringNotNullOrEmpty(() => tag);

            Name = name;
            Tag = tag;
        }
    }
}