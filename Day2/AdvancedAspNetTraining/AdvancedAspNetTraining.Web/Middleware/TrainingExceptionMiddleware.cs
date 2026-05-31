using System.Net;
using System.Text.Json;

namespace AdvancedAspNetTraining.Web.Middleware;

public sealed class TrainingExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public TrainingExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var payload = JsonSerializer.Serialize(new
            {
                error = "Unhandled exception captured by middleware.",
                message = ex.Message,
                path = context.Request.Path.Value
            });

            await context.Response.WriteAsync(payload);
        }
    }
}
