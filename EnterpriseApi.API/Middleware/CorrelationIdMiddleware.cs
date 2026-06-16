using EnterpriseApi.Application.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace EnterpriseApi.API.Middleware
{
    public class CorrelationIdMiddleware
    {
        private const string CorrelationIdHeader =
            "X-Correlation-Id";

        private readonly RequestDelegate _next;

        public CorrelationIdMiddleware(
            RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(
            HttpContext context)
        {
            string correlationId;

            if (context.Request.Headers
                .ContainsKey(CorrelationIdHeader))
            {
                correlationId =
                    context.Request.Headers[
                        CorrelationIdHeader];
            }
            else
            {
                correlationId =
                    Guid.NewGuid().ToString();
            }

            context.Items[ApplicationConstants.CorrelationId] =
                correlationId;

            context.Response.OnStarting(() =>
            {
                context.Response.Headers[
                    CorrelationIdHeader] =
                    correlationId;

                return Task.CompletedTask;
            });

            await _next(context);
        }
    }
}