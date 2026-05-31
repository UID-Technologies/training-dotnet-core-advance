using AdvancedAspNetTraining.Console.Shared;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace AdvancedAspNetTraining.Console.Modules.AspNetCoreRuntime;

public static class Exercise01_KestrelServer
{
    public static Task RunAsync() =>
        ExerciseWebHostHelper.RunInteractiveHostAsync(
            builder =>
            {
                builder.WebHost.ConfigureKestrel(options =>
                {
                    options.Limits.MaxRequestBodySize = 10 * 1024 * 1024;
                    System.Console.WriteLine($"Kestrel max request body: {options.Limits.MaxRequestBodySize} bytes");
                });
            },
            app =>
            {
                app.MapGet("/", () => Results.Ok(new
                {
                    server = "Kestrel",
                    message = "Kestrel is the cross-platform web server for ASP.NET Core.",
                    features = new[] { "HTTP/1.1", "HTTP/2", "HTTPS", "WebSockets" }
                }));

                app.MapGet("/health", () => Results.Ok(new { status = "healthy" }));
            },
            "Exercise 1: Kestrel Server");
}
