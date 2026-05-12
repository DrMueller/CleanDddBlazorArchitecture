namespace DatabaseBuddy.Infrastructure.DockerStuff.Containers.Services
{
    public interface IContainerRemover
    {
        Task RemoveContainerAsync(string containerId);
        Task RemoveAsync(string containerName);
    }
}