using EnterpriseApi.API.Middleware;
using Microsoft.AspNetCore.Builder;

namespace EnterpriseApi.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware
                <GlobalExceptionMiddleware>();
        }
        public static IApplicationBuilder UseCorrelationIdMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware
                <CorrelationIdMiddleware>();
        }
        public static IApplicationBuilder UseRequestLoggingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware
                <RequestLoggingMiddleware>();
        }
        public static IApplicationBuilder UseResponseLoggingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware
                <ResponseLoggingMiddleware>();
        }
        public static IApplicationBuilder UseSecurityHeadersMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware
                <SecurityHeadersMiddleware>();
        }
    }
}