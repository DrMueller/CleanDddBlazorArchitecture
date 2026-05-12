using DatabaseBuddy.Infrastructure;
using DatabaseBuddy.Infrastructure.ConsoleStuff.Commands.Models;
using DatabaseBuddy.Infrastructure.DockerStuff.Containers.Services;

using Microsoft.EntityFrameworkCore;
using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Contexts.Implementation;
using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Factories;

namespace DatabaseBuddy.ConsoleCommands.InitalizeDatabase
{
    public class InitalizeDatabaseCommand(
        IContainerProvisioner containerProvisioner,
        IContainerRemover containerRemover,
        IAppDbContextFactory dbContextFactory)
        : IConsoleCommand
    {
        public string Description { get; } = "Initialize DB";
        public ConsoleKey Key { get; } = ConsoleKey.F1;

        public async Task ExecuteAsync()
        {
            await containerRemover.RemoveAsync(Constants.ContainerName);
            await containerProvisioner.AssureStartedAsync();

            var dbContext = dbContextFactory.Create();
            var dbContextApp = (AppDbContext)dbContext;
            await dbContextApp.Database.MigrateAsync();
        }
    }
}