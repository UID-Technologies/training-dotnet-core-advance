using AdvancedAspNetTraining.Console.Shared;
using Microsoft.AspNetCore.Builder;

namespace AdvancedAspNetTraining.Console.Modules.RestApiDesign;

public static class Exercise23_HateoasConcepts
{
    public static Task RunAsync() =>
        ExerciseWebHostHelper.RunInteractiveHostAsync(
            _ => { },
            app =>
            {
                app.MapGet("/api/v1/orders/{id:int}", (int id, HttpContext ctx) =>
                {
                    var baseUrl = $"{ctx.Request.Scheme}://{ctx.Request.Host}";

                    return Results.Ok(new
                    {
                        id,
                        status = "Submitted",
                        total = 1200m,
                        links = new[]
                        {
                            new { rel = "self", href = $"{baseUrl}/api/v1/orders/{id}", method = "GET" },
                            new { rel = "update", href = $"{baseUrl}/api/v1/orders/{id}", method = "PUT" },
                            new { rel = "cancel", href = $"{baseUrl}/api/v1/orders/{id}/cancel", method = "POST" }
                        }
                    });
                });
            },
            "Exercise 23: HATEOAS (hypermedia links in response)");
}
