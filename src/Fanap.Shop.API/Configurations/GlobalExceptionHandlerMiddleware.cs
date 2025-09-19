using Fanap.Shop.Domain.Common;
using System.Net;
using System.Text.Json;

public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

    public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
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
            _logger.LogError(ex, "Unhandled exception occurred");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode status;
        string message;

        switch (exception)
        {
            case DomainException or ApplicationException:
                status = HttpStatusCode.BadRequest;
                message = exception.Message;
                break;

            case UnauthorizedAccessException:
                status = HttpStatusCode.Unauthorized;
                message = "دسترسی غیر مجاز";
                break;

            case InvalidOperationException:
                status = HttpStatusCode.BadRequest;
                message = exception.Message;
                break;

            default:
                status = HttpStatusCode.InternalServerError;
                message = "خطایی رخ داد";
                break;
        }

        var response = new
        {
            error = message,
            details = exception.InnerException?.Message
        };

        var payload = JsonSerializer.Serialize(response);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)status;
        return context.Response.WriteAsync(payload);
    }
}
