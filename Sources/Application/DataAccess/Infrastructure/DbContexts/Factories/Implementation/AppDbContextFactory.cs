using Microsoft.EntityFrameworkCore;
using Mmu.CleanBlazor.Common.Settings.Provisioning.Services;
using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Contexts;
using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Contexts.Implementation;

namespace Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Factories.Implementation
{
    public class AppDbContextFactory : IAppDbContextFactory
    {
        private readonly Lazy<DbContextOptions> _lazyOptions;

        public AppDbContextFactory(
            IDbContextOptionsFactory optionsFactory,
            IAppSettingsProvider appSettingsProvider)
        {
            _lazyOptions = new Lazy<DbContextOptions>(
                () => optionsFactory.CreateForSqlServer(
                    appSettingsProvider.Settings.ConnectionString));
        }

        public IAppDbContext Create()
        {
            return new AppDbContext(_lazyOptions.Value);
        }
    }
}