using System.Text.RegularExpressions;
using AdvancedAspNetTraining.Console.Shared;
using Microsoft.AspNetCore.Builder;

namespace AdvancedAspNetTraining.Console.Modules.ApiSecurityBestPractices;

public static class Exercise33_InputValidationSecurity
{
    private static readonly Regex SafeNamePattern = new(@"^[a-zA-Z0-9\s\-\.]{2,100}$", RegexOptions.Compiled);

    public static Task RunAsync() =>
        ExerciseWebHostHelper.RunInteractiveHostAsync(
            _ => { },
            app =>
            {
                app.MapPost("/api/customers", (CustomerInput input) =>
                {
                    if (string.IsNullOrWhiteSpace(input.Name) || !SafeNamePattern.IsMatch(input.Name))
                    {
                        return Results.BadRequest(new { error = "Invalid customer name." });
                    }

                    if (input.Email is not null && !input.Email.Contains('@'))
                    {
                        return Results.BadRequest(new { error = "Invalid email format." });
                    }

                    return Results.Created("/api/customers/1", new { input.Name, input.Email });
                });
            },
            "Exercise 33: Input Validation (try POST with script tags in name)");

    private sealed record CustomerInput(string Name, string? Email);
}
