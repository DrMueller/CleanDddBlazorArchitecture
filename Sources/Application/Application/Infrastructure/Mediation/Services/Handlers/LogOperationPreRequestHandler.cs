using JetBrains.Annotations;
using MediatR.Pipeline;
using Mmu.CleanBlazor.Application.Infrastructure.Mediation.Services.Servants;
using Mmu.CleanBlazor.Common.Logging;

namespace Mmu.CleanBlazor.Application.Infrastructure.Mediation.Services.Handlers;

[UsedImplicitly]
public class LogOperationPreRequestHandler<TRequest> : IRequestPreProcessor<TRequest>
    where TRequest : notnull
{
    private readonly IRequestInfoFactory _requestInfoFactory;
    private readonly ILoggingService _loggingService;

    public LogOperationPreRequestHandler(
        IRequestInfoFactory requestInfoFactory,
        ILoggingService loggingService)
    {
        _requestInfoFactory = requestInfoFactory;
        _loggingService = loggingService;
    }

    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestInfo = _requestInfoFactory.Create(request);
        _loggingService.LogInformation(requestInfo);

        return Task.CompletedTask;
    }
}