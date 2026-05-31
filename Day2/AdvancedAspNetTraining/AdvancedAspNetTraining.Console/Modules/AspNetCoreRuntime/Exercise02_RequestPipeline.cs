using AdvancedAspNetTraining.Console.Shared;
using Microsoft.AspNetCore.Builder;

namespace AdvancedAspNetTraining.Console.Modules.AspNetCoreRuntime;

public static class Exercise02_RequestPipeline
{
    public static Task RunAsync() =>
        ExerciseWebHostHelper.RunInteractiveHostAsync(
            _ => { },
            app =>
            {
                System.Console.WriteLine("Pipeline order: Routing -> Endpoints");
                System.Console.WriteLine("Try GET /step1 then /step2");

                app.Use(async (context, next) =>
                {
                    System.Console.WriteLine("[Middleware 1] Before next");
                    await next();
                    System.Console.WriteLine("[Middleware 1] After next");
                });

                app.Use(async (context, next) =>
                {
                    System.Console.WriteLine("[Middleware 2] Before next");
                    await next();
                    System.Console.WriteLine("[Middleware 2] After next");
                });

                app.MapGet("/step1", () => "Step 1 reached endpoint");
                app.MapGet("/step2", () => "Step 2 reached endpoint");
            },
            "Exercise 2: Request Pipeline");
}
