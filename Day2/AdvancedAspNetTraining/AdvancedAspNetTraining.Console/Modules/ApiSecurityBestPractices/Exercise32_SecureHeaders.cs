using AdvancedAspNetTraining.Console.Shared;
using AdvancedAspNetTraining.Web.Middleware;
using Microsoft.AspNetCore.Builder;

namespace AdvancedAspNetTraining.Console.Modules.ApiSecurityBestPractices;

public static class Exercise32_SecureHeaders
{
    public static Task RunAsync() =>
        ExerciseWebHostHelper.RunInteractiveHostAsync(
            _ => { },
            app =>
            {
                app.UseMiddleware<SecurityHeadersMiddleware>();

                app.MapGet("/api/secure-response", () => Results.Ok(new
                {
                    message = "Inspect response headers: X-Content-Type-Options, X-Frame-Options, Referrer-Policy"
                }));
            },
            "Exercise 32: Secure Headers");
}
