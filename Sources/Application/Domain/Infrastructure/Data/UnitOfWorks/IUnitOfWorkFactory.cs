namespace Mmu.CleanBlazor.Domain.Infrastructure.Data.UnitOfWorks
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}