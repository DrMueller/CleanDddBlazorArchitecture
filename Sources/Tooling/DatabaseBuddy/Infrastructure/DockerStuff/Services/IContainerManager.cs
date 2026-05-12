namespace DatabaseBuddy.Infrastructure.DockerStuff.Services
{
    public interface IContainerManager
    {
        Task AssureStartedAsync();
        Task RemoveAsync();
    }
}