using AdvancedAspNetTraining.Console.Shared;
using AdvancedAspNetTraining.Web.Middleware;
using Microsoft.AspNetCore.Builder;

namespace AdvancedAspNetTraining.Console.Modules.MiddlewarePipeline;

public static class Exercise10_CustomMiddleware
{
    public static Task RunAsync() =>
        ExerciseWebHostHelper.RunInteractiveHostAsync(
            _ => { },
            app =>
            {
                app.UseMiddleware<CustomHeaderMiddleware>();

                app.MapGet("/client", (HttpContext context) =>
                {
                    var clientId = context.Items["TrainingClientId"]?.ToString() ?? "unknown";
                    return Results.Ok(new
                    {
                        message = "Send header X-Training-Client: MyApp",
                        detectedClient = clientId,
                        processedBy = context.Response.Headers["X-Training-Processed-By"].ToString()
                    });
                });
            },
            "Exercise 10: Custom Middleware");
}
