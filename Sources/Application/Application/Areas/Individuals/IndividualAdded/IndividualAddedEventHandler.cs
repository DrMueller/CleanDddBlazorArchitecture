using JetBrains.Annotations;
using MediatR;

namespace Mmu.CleanBlazor.Application.Areas.Individuals.IndividualAdded;

[UsedImplicitly]
public class IndividualAddedEventHandler : INotificationHandler<Domain.Areas.Individuals.Events.IndividualAdded>
{
    public Task Handle(Domain.Areas.Individuals.Events.IndividualAdded notification, CancellationToken cancellationToken)
    {
        Console.WriteLine(notification.IndividualId);

        return Task.CompletedTask;
    }
}