using MediatR;

namespace Mmu.CleanBlazor.Application.Areas.Individuals.EventHandlers.IndividualDeleted
{
    public class IndividualDeletedEventHandler : INotificationHandler<Domain.Areas.Individuals.Events.IndividualDeleted>
    {
        public Task Handle(Domain.Areas.Individuals.Events.IndividualDeleted notification, CancellationToken cancellationToken)
        {
            Console.WriteLine(notification.IndividualId);

            return Task.CompletedTask;
        }
    }
}