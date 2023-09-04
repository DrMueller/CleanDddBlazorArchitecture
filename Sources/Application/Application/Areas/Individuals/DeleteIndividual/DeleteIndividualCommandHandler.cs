using MediatR;
using Mmu.CleanBlazor.Domain.Areas.Individuals.Repositories;
using Mmu.CleanBlazor.Domain.Infrastructure.Data.UnitOfWorks;

namespace Mmu.CleanBlazor.Application.Areas.Individuals.DeleteIndividual;

public class DeleteIndividualCommandHandler : IRequestHandler<DeleteIndividualCommand>
{
    private readonly IUnitOfWorkFactory _uowFactory;

    public DeleteIndividualCommandHandler(IUnitOfWorkFactory uowFactory)
    {
        _uowFactory = uowFactory;
    }

    public async Task Handle(DeleteIndividualCommand request, CancellationToken cancellationToken)
    {
        using var uow = _uowFactory.Create();

        var indRepo = uow.GetRepository<IIndividualRepository>();
        await indRepo.DeleteAsync(request.IndividualId);

        await uow.SaveAsync();
    }
}