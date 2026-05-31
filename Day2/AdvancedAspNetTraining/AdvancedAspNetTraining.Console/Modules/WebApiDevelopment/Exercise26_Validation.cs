using AdvancedAspNetTraining.Console.Shared;
using Microsoft.AspNetCore.Builder;

namespace AdvancedAspNetTraining.Console.Modules.WebApiDevelopment;

public static class Exercise26_Validation
{
    public static Task RunAsync() =>
        ExerciseWebHostHelper.RunInteractiveHostAsync(
            builder => builder.Services.AddControllers(),
            app => app.MapControllers(),
            "Exercise 26: Validation (POST /api/validation/orders with invalid JSON body)");
}
