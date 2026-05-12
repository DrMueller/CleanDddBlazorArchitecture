using Mmu.CleanBlazor.Common.LanguageExtensions.Invariance;
using Mmu.CleanBlazor.Common.LanguageExtensions.Types.Maybes;

namespace DatabaseBuddy.Infrastructure.DockerStuff.Configurations.Ports
{
    public class HostPort
    {
        public const string DefaultHostIp = "127.0.0.1";

        public string CompleteHost => $"{HostIp},{PortNumber}";

        public string HostIp { get; }
        public int PortNumber { get; }

        public HostPort(int portNumber, Maybe<string> possibleIp)
        {
            Guard.That(() => portNumber > 0, "Port number not set.");
            Guard.ObjectNotNull(() => possibleIp);

            PortNumber = portNumber;
            HostIp = possibleIp.Reduce(() => DefaultHostIp);
        }
    }
}