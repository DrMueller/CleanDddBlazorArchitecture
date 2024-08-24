using JetBrains.Annotations;

namespace Mmu.CleanBlazor.Application.Infrastructure.Mediation.Services.Servants.Implementation
{
    [UsedImplicitly]
    public class RequestInfoFactory : IRequestInfoFactory
    {
        public string Create<TRequest>(TRequest t) where TRequest : notnull
        {
            // For records
            return t.ToString();
            var message = "Type: {0}. Params: {1}.";
            var typeName = t.GetType().Name;
            var typeParams = t.ToString();

            return string.Format(message, typeName, typeParams);
        }
    }
}