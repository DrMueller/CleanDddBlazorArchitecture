using MediatR;
using Mmu.CleanBlazor.Application.Infrastructure.Mediation.Models;
using Mmu.CleanBlazor.Application.Infrastructure.Outbox.Repositories;
using Mmu.CleanBlazor.Domain.Infrastructure.Data.UnitOfWorks;

namespace Mmu.CleanBlazor.Application.Infrastructure.Outbox.UseCases
{
    public record DispatchMessagesCommand : ICommand;

    public class DispatchMessagesCommandHandler : IRequestHandler<DispatchMessagesCommand>
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public DispatchMessagesCommandHandler(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public async Task Handle(DispatchMessagesCommand request, CancellationToken cancellationToken)
        {
            using var uow = _uowFactory.Create();
            {
                var outboxRepo = uow.GetRepository<IOutboxRepository>();
                var unsentMessages = await outboxRepo.LoadUnsentMessagesAsync();

                foreach (var message in unsentMessages)
                {
                    try
                    {
                        // Do stuff with it
                        Console.WriteLine(message.Payload);
                        message.MarkAsProcessed();
                    }
                    catch (Exception ex)
                    {
                        // Logging
                        message.MarkAsFailed(ex.Message);
                    }
                }

                await uow.SaveAsync();
            }
        }
    }
}