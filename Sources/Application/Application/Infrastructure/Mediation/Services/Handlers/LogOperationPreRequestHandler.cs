﻿using JetBrains.Annotations;
using MediatR.Pipeline;
using Mmu.CleanBlazor.Common.Logging;

namespace Mmu.CleanBlazor.Application.Infrastructure.Mediation.Services.Handlers;

[UsedImplicitly]
public class LogOperationPreRequestHandler<TRequest> : IRequestPreProcessor<TRequest>
    where TRequest : notnull
{
    private readonly ILoggingService _loggingService;

    public LogOperationPreRequestHandler(ILoggingService loggingService)
    {
        _loggingService = loggingService;
    }

    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        _loggingService.LogInformation($"Received message '{request.GetType().Name}'");

        return Task.CompletedTask;
    }
}