using DependencyInjectionRegistrationOption.Core.Helper.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace DependencyInjectionRegistrationOption.Core.Middleware
{
    public class FirstMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IOperationSingleton _operationSingleton;

        public FirstMiddleware(RequestDelegate next, ILogger<FirstMiddleware> logger, IOperationSingleton operationSingleton)
        {
            _next = next;
            _logger = logger;
            _operationSingleton = operationSingleton;

        }

        public async Task InvokeAsync(HttpContext httpContext, IOperationScoped operationScoped, IOperationTransient operationTransient)
        {
            _logger.LogInformation("Start");

            _logger.LogInformation($"FirstMiddleware    Singleton:     {_operationSingleton.OperationId}");
            _logger.LogInformation($"FirstMiddleware    Scoped:        {operationScoped.OperationId}");
            _logger.LogInformation($"FirstMiddleware    Transient:     {operationTransient.OperationId}");

            await _next(httpContext);

            httpContext.Response.OnCompleted(state =>
                OnResponseCompleted(),
                httpContext
            );
        }

        private Task OnResponseCompleted()
        {
            _logger.LogInformation("Finish");
            _logger.LogInformation(Environment.NewLine);

            return Task.CompletedTask;
        }
    }

    public static class FirstMiddlewareExtensions
    {
        public static IApplicationBuilder UseFirstMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FirstMiddleware>();
        }
    }
}