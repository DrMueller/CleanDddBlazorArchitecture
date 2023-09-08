using JetBrains.Annotations;
using Mmu.CleanBlazor.Common.LanguageExtensions.Invariance;
using Mmu.CleanBlazor.Presentation.Infrastructure.ExceptionHandling.Middlewares;

namespace Mmu.CleanBlazor.Presentation.Infrastructure.ExceptionHandling.Initialization;

[PublicAPI]
public static class ExceptionHandlingInitialization
{
    public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
    {
        Guard.ObjectNotNull(() => app);
        app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

        return app;
    }
}