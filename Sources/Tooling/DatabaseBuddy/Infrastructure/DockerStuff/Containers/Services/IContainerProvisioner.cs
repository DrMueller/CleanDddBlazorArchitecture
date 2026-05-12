namespace DatabaseBuddy.Infrastructure.DockerStuff.Containers.Services
{
    public interface IContainerProvisioner
    {
        Task AssureStartedAsync();
    }
}