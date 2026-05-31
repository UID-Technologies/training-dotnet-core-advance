using AdvancedAspNetTraining.Console.Shared;
using Microsoft.AspNetCore.Builder;

namespace AdvancedAspNetTraining.Console.Modules.MiddlewarePipeline;

public static class Exercise09_MiddlewareArchitecture
{
    public static Task RunAsync() =>
        ExerciseWebHostHelper.RunInteractiveHostAsync(
            _ => { },
            app =>
            {
                System.Console.WriteLine("Request flows: Client -> Middleware chain -> Endpoint -> Middleware (reverse)");

                app.UseRouting();

                app.Use(async (context, next) =>
                {
                    context.Response.Headers["X-Pipeline-Stage"] = "Security";
                    await next();
                });

                app.Use(async (context, next) =>
                {
                    context.Response.Headers["X-Pipeline-Stage"] += ",Business";
                    await next();
                });

                app.MapGet("/pipeline", (HttpContext ctx) =>
                {
                    return Results.Ok(new
                    {
                        path = ctx.Request.Path.Value,
                        stages = ctx.Response.Headers["X-Pipeline-Stage"].ToArray()
                    });
                });
            },
            "Exercise 9: Middleware Architecture");
}
