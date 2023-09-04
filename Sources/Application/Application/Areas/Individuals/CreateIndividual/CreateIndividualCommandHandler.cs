using MediatR;
using Mmu.CleanBlazor.Common.Logging;
using Mmu.CleanBlazor.Domain.Areas.Individuals.Models;
using Mmu.CleanBlazor.Domain.Areas.Individuals.Repositories;
using Mmu.CleanBlazor.Domain.Infrastructure.Data.UnitOfWorks;

namespace Mmu.CleanBlazor.Application.Areas.Individuals.CreateIndividual;

public class CreateIndividualCommandHandler : IRequestHandler<CreateIndividualCommand, CreateIndividualResultDto>
{
    private readonly ILoggingService _loggingService;
    private readonly IUnitOfWorkFactory _uowFactory;

    public CreateIndividualCommandHandler(
        ILoggingService loggingService,
        IUnitOfWorkFactory uowFactory)
    {
        _loggingService = loggingService;
        _uowFactory = uowFactory;
    }

    public async Task<CreateIndividualResultDto> Handle(CreateIndividualCommand request,
        CancellationToken cancellationToken)
    {
        _loggingService.LogInformation("Creating new Individual..");

        var individual = new Individual
        {
            BirthDate = request.RequestDto.BirthDate,
            FirstName = request.RequestDto.FirstName + " " + Guid.NewGuid(),
            Gender = request.RequestDto.Gender,
            LastName = request.RequestDto.LastName + " " + Guid.NewGuid()
        };

        
        
        using (var uow = _uowFactory.Create())
        {
            var individualRepo = uow.GetRepository<IIndividualRepository>();
            await individualRepo.InsertAsync(individual);
            await uow.SaveAsync();
        }

        _loggingService.LogInformation("Individual created");

        return new CreateIndividualResultDto
        {
            IndividualId = individual.Id
        };
    }
}