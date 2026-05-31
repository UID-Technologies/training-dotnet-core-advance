using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace AdvancedAspNetTraining.Console.Shared;

public static class ExerciseWebHostHelper
{
    public static async Task RunInteractiveHostAsync(
        Action<WebApplicationBuilder> configureBuilder,
        Action<WebApplication> configurePipeline,
        string exerciseTitle)
    {
        var builder = WebApplication.CreateBuilder(new WebApplicationOptions { Args = [] });

        builder.WebHost.UseUrls("http://127.0.0.1:0");

        configureBuilder(builder);

        var app = builder.Build();
        configurePipeline(app);

        await app.StartAsync();

        System.Console.WriteLine();
        System.Console.WriteLine($"[{exerciseTitle}]");
        System.Console.WriteLine("Server started. Open these URLs in a browser or REST client:");
        foreach (var url in app.Urls)
        {
            System.Console.WriteLine($"  {url}");
        }

        System.Console.WriteLine();
        System.Console.WriteLine("Press Enter to stop the server...");
        System.Console.ReadLine();

        await app.StopAsync();
    }
}
