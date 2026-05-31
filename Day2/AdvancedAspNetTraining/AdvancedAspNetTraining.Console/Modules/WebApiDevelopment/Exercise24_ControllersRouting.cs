using AdvancedAspNetTraining.Console.Shared;
using Microsoft.AspNetCore.Builder;

namespace AdvancedAspNetTraining.Console.Modules.WebApiDevelopment;

public static class Exercise24_ControllersRouting
{
    public static Task RunAsync() =>
        ExerciseWebHostHelper.RunInteractiveHostAsync(
            builder => builder.Services.AddControllers(),
            app => app.MapControllers(),
            "Exercise 24: Controllers & Routing (GET /api/demo/orders)");
}
