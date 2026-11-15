namespace WebAPI.Middleware;

public class RequestLoggingMiddleware(
    RequestDelegate next,
    ILogger<RequestLoggingMiddleware> logger)
{
    private RequestDelegate _next = next;
    private ILogger<RequestLoggingMiddleware> _logger = logger;
    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation($"Request: {context.Request.Path} {DateTime.Now}");
        await _next(context);
        _logger.LogInformation($"Request: {context.Response.StatusCode} {DateTime.Now}");
    }
}
