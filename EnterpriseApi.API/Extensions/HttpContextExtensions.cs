using EnterpriseApi.Application.Common;
using Microsoft.AspNetCore.Http;

namespace EnterpriseApi.API.Extensions
{
    public static class HttpContextExtensions
    {
        public static string? GetCorrelationId(this HttpContext context)
        {
            if (context.Items.TryGetValue(ApplicationConstants.CorrelationId, out var correlationId))
            {
                return correlationId?.ToString();
            }

            return string.Empty;
        }
    }
}