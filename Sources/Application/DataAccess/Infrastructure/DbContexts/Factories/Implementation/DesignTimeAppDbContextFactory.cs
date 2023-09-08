using Lamar;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Mmu.CleanBlazor.Common.Settings.Config.Services;
using Mmu.CleanBlazor.Common.Settings.Provisioning.Models;
using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Contexts.Implementation;

namespace Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Factories.Implementation;

public class DesignTimeAppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var container = CreateContainer();

        var appDbContextFactory = container.GetInstance<IAppDbContextFactory>();

        return (AppDbContext)appDbContextFactory.Create();
    }

    private static IContainer CreateContainer()
    {
        return new Container(
            cfg =>
            {
                cfg.Scan(
                    scanner =>
                    {
                        scanner.AssembliesFromApplicationBaseDirectory();
                        scanner.LookForRegistries();
                    });

                var config = ConfigurationFactory.Create();
                cfg.Configure<AppSettings>(config.GetSection(AppSettings.SectionKey));
            });
    }
}