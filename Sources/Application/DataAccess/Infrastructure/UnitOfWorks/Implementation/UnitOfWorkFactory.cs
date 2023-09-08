using Lamar;
using Mmu.CleanBlazor.DataAccess.Infrastructure.DbContexts.Factories;
using Mmu.CleanBlazor.Domain.Infrastructure.Data.UnitOfWorks;

namespace Mmu.CleanBlazor.DataAccess.Infrastructure.UnitOfWorks.Implementation
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IContainer _container;
        private readonly IAppDbContextFactory _dbContextFactory;

        public UnitOfWorkFactory(
            IContainer container,
            IAppDbContextFactory dbContextFactory)
        {
            _container = container;
            _dbContextFactory = dbContextFactory;
        }

        public IUnitOfWork Create()
        {
            var dbContext = _dbContextFactory.Create();
            var unitOfWork = _container.GetInstance<UnitOfWork>();
            unitOfWork.Initialize(dbContext);

            return unitOfWork;
        }
    }
}