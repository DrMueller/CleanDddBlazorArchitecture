using MediatR;

namespace Mmu.CleanBlazor.Domain.Areas.Common.DomainEvents
{
    public interface IDomainEvent : INotification
    {
        Guid Id { get; }

        DateTime OccurredOn { get; }
    }
}