using JetBrains.Annotations;
using MediatR;

namespace Mmu.CleanBlazor.Application.Areas.Individuals.EventHandlers.IndividualAdded;

[UsedImplicitly]
public class IndividualAddedEventHandler : INotificationHandler<Domain.Areas.Individuals.Events.IndividualAdded>
{
    public Task Handle(Domain.Areas.Individuals.Events.IndividualAdded notification, CancellationToken cancellationToken)
    {
        Console.WriteLine(notification.Individual.Id);

        return Task.CompletedTask;
    }
}