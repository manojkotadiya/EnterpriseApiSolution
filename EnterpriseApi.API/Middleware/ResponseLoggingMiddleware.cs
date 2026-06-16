using EnterpriseApi.API.Extensions;
using EnterpriseApi.Application.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EnterpriseApi.API.Middleware
{
    public class ResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<ResponseLoggingMiddleware>
            _logger;

        public ResponseLoggingMiddleware(
            RequestDelegate next,
            ILogger<ResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(
            HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            await _next(context);


            stopwatch.Stop();

            var correlationId =
                context.GetCorrelationId();

            _logger.LogInformation(
                LogMessages.RequestCompleted + " | " + ApplicationConstants.CorrelationId + ":{CorrelationId} | Method:{Method} | Path:{Path} | StatusCode:{StatusCode} | ElapsedMs:{ElapsedMs}",
                correlationId,
                context.Request.Method,
                context.Request.Path,
                context.Response.StatusCode,
                stopwatch.ElapsedMilliseconds);

            if (stopwatch.ElapsedMilliseconds > 1000)
            {
                _logger.LogWarning(
                    LogMessages.SlowRequestDetected + " | " + ApplicationConstants.CorrelationId + ":{CorrelationId} | Path:{Path} | ElapsedMs:{ElapsedMs}",
                    correlationId,
                    context.Request.Path,
                    stopwatch.ElapsedMilliseconds);
            }

        }
    }
}