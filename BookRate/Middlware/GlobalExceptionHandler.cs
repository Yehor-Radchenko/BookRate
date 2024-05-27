using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace BookRate.Middlware
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {

            _logger.LogError(exception, exception.Message);

            var problemDetails = new ProblemDetails()
            {
                Detail = $"API ERROR: {exception.Message}",
                Instance = "API",
                Status = (int)HttpStatusCode.InternalServerError,
                Title = "Api Error",
                Type = "Server Error"
            };

            var response = JsonSerializer.Serialize(problemDetails);
            httpContext.Response.ContentType = "application/json";

            await httpContext.Response.WriteAsync(response, cancellationToken);

            return true;
        }
    }
}