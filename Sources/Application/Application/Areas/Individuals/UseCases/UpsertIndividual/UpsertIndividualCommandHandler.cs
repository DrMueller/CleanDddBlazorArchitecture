using JetBrains.Annotations;
using MediatR;
using Mmu.CleanBlazor.Domain.Areas.Common.Specifications;
using Mmu.CleanBlazor.Domain.Areas.Individuals.Models;
using Mmu.CleanBlazor.Domain.Areas.Individuals.Repositories;
using Mmu.CleanBlazor.Domain.Infrastructure.Data.UnitOfWorks;

namespace Mmu.CleanBlazor.Application.Areas.Individuals.UseCases.UpsertIndividual;

[UsedImplicitly]
public class UpsertIndividualCommandHandler : IRequestHandler<UpsertIndividualCommand>
{
    private readonly IUnitOfWorkFactory _uowFactory;

    public UpsertIndividualCommandHandler(IUnitOfWorkFactory uowFactory)
    {
        _uowFactory = uowFactory;
    }

    public async Task Handle(UpsertIndividualCommand request, CancellationToken cancellationToken)
    {
        using var uow = _uowFactory.Create();
        var indRepo = uow.GetRepository<IIndividualRepository>();

        Individual individual;

        if (request.Individual.IndividualId != 0)
        {
            individual = await indRepo.LoadSingleAsync(new LoadAggregateByIdSpec<Individual>(request.Individual.IndividualId));
            individual.FirstName = request.Individual.FirstName;
            individual.LastName = request.Individual.LastName;
            individual.BirthDate = request.Individual.BirthDate;
        }
        else
        {
            individual = Individual.CreateNew(
                request.Individual.FirstName,
                request.Individual.LastName,
                Gender.Male,
                request.Individual.BirthDate);

            await indRepo.InsertAsync(individual);
        }

        await uow.SaveAsync();
    }
}