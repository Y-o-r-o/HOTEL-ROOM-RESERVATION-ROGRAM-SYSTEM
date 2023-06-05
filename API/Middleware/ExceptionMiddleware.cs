using API.Extensions;
using BusinessLayer.DTOs;
using Core;
using System.Net;
using System.Text.Json;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                _logger.LogError(ex, ex.Response.ToString());
                await HandleValidationExceptionAsync(context, ex);
            }
            catch (HttpResponseException ex)
            {
                _logger.LogError(ex, ex.Response.ToString());
                await HandleExceptionAsync(context, ex, ex.Response.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode httpStatusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)httpStatusCode;

            var response = _env.IsDevelopment()
            ? new GenericHttpExceptionDTO(context.Response.StatusCode, exception.Message, exception.AnalyzeException())
            : new GenericHttpExceptionDTO(context.Response.StatusCode, exception.Message);

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var json = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(json);
        }

        private async Task HandleValidationExceptionAsync(HttpContext context, ValidationException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 400;

            var response = _env.IsDevelopment()
            ? new ValidationHttpExceptionDTO(exception.VariableErrors, exception.AnalyzeException())
            : new ValidationHttpExceptionDTO(exception.VariableErrors);

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var json = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(json);
        }
    }
}