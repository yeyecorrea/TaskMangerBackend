using Newtonsoft.Json;
using System.Net;
using System;

namespace TaskManager.Api.Config
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<ExceptionMiddleware>();
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Ha occurriodo un error:{ex.Message}");
                await HandleGlobalExceptionAsync(httpContext, ex);
            }
        }

        private async Task<Task> HandleGlobalExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.NotAcceptable;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorDetails()
            {
                StatusCode = StatusCodes.Status406NotAcceptable,
                Message = exception.Message,
                StackTrace = exception.StackTrace

            }));
        }
    }
}
