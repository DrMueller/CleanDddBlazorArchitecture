using Mmu.CleanBlazor.Common.LanguageExtensions.Invariance;

namespace Mmu.CleanBlazor.Common.InformationHandling
{
    public class InformationEntry
    {
        public string Message { get; }
        public InformationType Type { get; }

        public InformationEntry(InformationType type, string message)
        {
            Guard.StringNotNullOrEmpty(() => message);

            Type = type;
            Message = message;
        }
    }
}