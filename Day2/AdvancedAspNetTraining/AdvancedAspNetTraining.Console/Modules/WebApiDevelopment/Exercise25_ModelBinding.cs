using AdvancedAspNetTraining.Console.Shared;
using Microsoft.AspNetCore.Builder;

namespace AdvancedAspNetTraining.Console.Modules.WebApiDevelopment;

public static class Exercise25_ModelBinding
{
    public static Task RunAsync() =>
        ExerciseWebHostHelper.RunInteractiveHostAsync(
            builder => builder.Services.AddControllers(),
            app => app.MapControllers(),
            "Exercise 25: Model Binding (GET /api/binding/orders?status=Shipped)");
}
