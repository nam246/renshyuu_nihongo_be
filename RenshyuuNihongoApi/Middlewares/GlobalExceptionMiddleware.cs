using System.Net;
using System.Text.Json;

namespace RenshyuuNihongoApi.Middlewares;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred.");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var statusCode = exception switch
        {
            InvalidOperationException => HttpStatusCode.Conflict,
            KeyNotFoundException => HttpStatusCode.NotFound,
            UnauthorizedAccessException => HttpStatusCode.Unauthorized,
            _ => HttpStatusCode.InternalServerError
        };

        context.Response.StatusCode = (int)statusCode;

        var response = new
        {
            statusCode = context.Response.StatusCode,
            message = exception.Message,
            detailed = context.Response.StatusCode == (int)HttpStatusCode.InternalServerError 
                ? "An internal server error occurred." 
                : null
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
