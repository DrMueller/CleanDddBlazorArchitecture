using JetBrains.Annotations;
using Mmu.CleanBlazor.Common.LanguageExtensions.Invariance;

namespace DatabaseBuddy.Infrastructure.DockerStuff.Containers.Models
{
    [PublicAPI]
    public class ContainerErrors
    {
        public IReadOnlyCollection<string> ErrorMessages { get; }

        public ContainerErrors(params string[] errorMessages)
        {
            Guard.ObjectNotNull(() => errorMessages);

            ErrorMessages = errorMessages;
        }
    }
}