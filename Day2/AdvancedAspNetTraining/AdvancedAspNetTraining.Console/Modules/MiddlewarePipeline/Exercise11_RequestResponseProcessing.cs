using AdvancedAspNetTraining.Console.Shared;
using AdvancedAspNetTraining.Web.Middleware;
using Microsoft.AspNetCore.Builder;

namespace AdvancedAspNetTraining.Console.Modules.MiddlewarePipeline;

public static class Exercise11_RequestResponseProcessing
{
    public static Task RunAsync() =>
        ExerciseWebHostHelper.RunInteractiveHostAsync(
            _ => { },
            app =>
            {
                app.UseMiddleware<RequestTimingMiddleware>();

                app.MapGet("/slow", async () =>
                {
                    await Task.Delay(500);
                    return Results.Ok(new { message = "Check X-Response-Time-Ms response header" });
                });

                app.MapPost("/echo", async (HttpRequest request) =>
                {
                    using var reader = new StreamReader(request.Body);
                    var body = await reader.ReadToEndAsync();
                    return Results.Ok(new { receivedBytes = body.Length, body });
                });
            },
            "Exercise 11: Request/Response Processing");
}
