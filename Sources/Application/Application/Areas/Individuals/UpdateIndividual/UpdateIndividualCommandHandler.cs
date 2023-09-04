using MediatR;
using Mmu.CleanBlazor.Common.LanguageExtensions.Types.Maybes;
using Mmu.CleanBlazor.Domain.Areas.Common.Specifications;
using Mmu.CleanBlazor.Domain.Areas.Individuals.Models;
using Mmu.CleanBlazor.Domain.Areas.Individuals.Repositories;
using Mmu.CleanBlazor.Domain.Infrastructure.Data.UnitOfWorks;

namespace Mmu.CleanBlazor.Application.Areas.Individuals.UpdateIndividual;

public class UpdateIndividualCommandHandler : IRequestHandler<UpdateIndividualCommand>
{
    private readonly IUnitOfWorkFactory _uowFactory;

    public UpdateIndividualCommandHandler(IUnitOfWorkFactory uowFactory)
    {
        _uowFactory = uowFactory;
    }


    public async Task Handle(UpdateIndividualCommand request, CancellationToken cancellationToken)
    {
        using var uow = _uowFactory.Create();
        var indRepo = uow.GetRepository<IIndividualRepository>();

        var ind = await indRepo.LoadSingleAsync(new LoadAggregateByIdSpec<Individual>(request.Dto.IndividualId));
        ind.FirstName = request.Dto.NewFirstName;

        await uow.SaveAsync();
    }
}