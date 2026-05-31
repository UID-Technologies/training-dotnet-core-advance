using AdvancedAspNetTraining.Console.Shared;
using AdvancedAspNetTraining.Web.Middleware;
using Microsoft.AspNetCore.Builder;

namespace AdvancedAspNetTraining.Console.Modules.MiddlewarePipeline;

public static class Exercise12_ExceptionMiddleware
{
    public static Task RunAsync() =>
        ExerciseWebHostHelper.RunInteractiveHostAsync(
            _ => { },
            app =>
            {
                app.UseMiddleware<TrainingExceptionMiddleware>();

                app.MapGet("/ok", () => Results.Ok(new { status = "ok" }));

                app.MapGet("/fail", () =>
                {
                    throw new InvalidOperationException("Simulated failure for middleware demo");
                });
            },
            "Exercise 12: Exception Middleware (try GET /fail)");
}
