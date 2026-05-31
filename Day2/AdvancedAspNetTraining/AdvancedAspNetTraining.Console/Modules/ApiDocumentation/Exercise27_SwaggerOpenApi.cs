using AdvancedAspNetTraining.Console.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;

namespace AdvancedAspNetTraining.Console.Modules.ApiDocumentation;

public static class Exercise27_SwaggerOpenApi
{
    public static Task RunAsync() =>
        ExerciseWebHostHelper.RunInteractiveHostAsync(
            builder =>
            {
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Training Orders API",
                        Version = "v1",
                        Description = "OpenAPI documentation for enterprise API standards.",
                        Contact = new OpenApiContact { Name = "Platform Team", Email = "platform@example.com" }
                    });
                });
            },
            app =>
            {
                app.UseSwagger();
                app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Training API v1"));

                app.MapGet("/api/products", () => Results.Ok(new[] { new { Id = 1, Name = "Training SKU" } }));
            },
            "Exercise 27: Swagger / OpenAPI (open /swagger)");
}
