namespace Mmu.CleanBlazor.Application.Infrastructure.Mediation.Services.Servants
{
    public interface IRequestInfoFactory
    {
        string Create<TRequest>(TRequest t)
            where TRequest : notnull;
    }
}