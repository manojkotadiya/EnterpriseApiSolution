using EnterpriseApi.Application.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EnterpriseApi.API.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<RequestLoggingMiddleware>
            _logger;

        public RequestLoggingMiddleware(
            RequestDelegate next,
            ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(
            HttpContext context)
        {
            var correlationId =
                context.Items["CorrelationId"]
                    ?.ToString();

            var user =
                context.User?.FindFirst(
                    ClaimTypes.Email)?.Value
                ?? "Anonymous";

            var ipAddress =
                context.Connection.RemoteIpAddress
                    ?.ToString();

            _logger.LogInformation(
                LogMessages.IncomingRequest + " | "+ ApplicationConstants.CorrelationId + ":{CorrelationId} | Method:{Method} | Path:{Path} | User:{User} | IP:{IP}",
                correlationId,
                context.Request.Method,
                context.Request.Path,
                user,
                ipAddress);

            await _next(context);
        }
    }
}