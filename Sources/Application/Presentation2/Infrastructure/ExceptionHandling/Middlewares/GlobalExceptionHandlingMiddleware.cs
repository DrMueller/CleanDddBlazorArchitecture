using System.Net;
using JetBrains.Annotations;
using Mmu.CleanBlazor.Common.Logging;
using Newtonsoft.Json;

namespace Mmu.CleanBlazor.Presentation2.Infrastructure.ExceptionHandling.Middlewares;

[PublicAPI]
public class GlobalExceptionHandlingMiddleware
{
    private readonly ILoggingService _loggingService;
    private readonly RequestDelegate _next;

    public GlobalExceptionHandlingMiddleware(RequestDelegate next, ILoggingService loggingService)
    {
        _next = next;
        _loggingService = loggingService;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception exception)
        {
            var result = JsonConvert.SerializeObject(new { error = exception.Message });
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await httpContext.Response.WriteAsync(result);
        }
    }
}