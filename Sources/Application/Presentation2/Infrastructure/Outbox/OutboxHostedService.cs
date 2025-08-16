using Mmu.CleanBlazor.Application.Infrastructure.Mediation.Services;
using Mmu.CleanBlazor.Application.Infrastructure.Outbox.UseCases;

namespace Mmu.CleanBlazor.Presentation2.Infrastructure.Outbox
{
    public class OutboxHostedService : BackgroundService
    {
        private readonly IMediationService _mediator;

        public OutboxHostedService(IMediationService mediator)
        {
            _mediator = mediator;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var timer = new PeriodicTimer(TimeSpan.FromSeconds(5));

            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                await _mediator.SendAsync(new DispatchMessagesCommand());
            }
        }
    }
}