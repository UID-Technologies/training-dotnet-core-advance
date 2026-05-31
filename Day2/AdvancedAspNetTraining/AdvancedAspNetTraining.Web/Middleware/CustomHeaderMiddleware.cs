namespace AdvancedAspNetTraining.Web.Middleware;

public sealed class CustomHeaderMiddleware
{
    private readonly RequestDelegate _next;

    public CustomHeaderMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Request.Headers.TryGetValue("X-Training-Client", out var clientId);
        context.Items["TrainingClientId"] = clientId.ToString();

        await _next(context);

        context.Response.Headers["X-Training-Processed-By"] = "AdvancedAspNetTraining";
    }
}
