using AdvancedAspNetTraining.Console.Shared;
using Microsoft.AspNetCore.Builder;
namespace AdvancedAspNetTraining.Console.Modules.RestApiDesign;

public static class Exercise22_ApiVersioning
{
    public static Task RunAsync() =>
        ExerciseWebHostHelper.RunInteractiveHostAsync(
            builder => builder.Services.AddEndpointsApiExplorer(),
            app =>
            {
                app.MapGet("/api/v1/products", () => Results.Ok(new[] { new { Id = 1, Name = "Widget", Price = 9.99m } }));

                app.MapGet("/api/v2/products", () => Results.Ok(new[]
                {
                    new { Id = 1, Name = "Widget", Price = 9.99m, Currency = "USD", Sku = "W-001" }
                }));

                System.Console.WriteLine("Versioning strategies: URL path, header, query string, media type.");
            },
            "Exercise 22: API Versioning (try /api/v1/products and /api/v2/products)");
}
