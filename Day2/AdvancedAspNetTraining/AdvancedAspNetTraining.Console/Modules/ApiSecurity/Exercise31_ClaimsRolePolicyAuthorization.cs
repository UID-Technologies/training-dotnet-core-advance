using System.Text;
using AdvancedAspNetTraining.Console.Shared;
using AdvancedAspNetTraining.Web.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;

namespace AdvancedAspNetTraining.Console.Modules.ApiSecurity;

public static class Exercise31_ClaimsRolePolicyAuthorization
{
    public static Task RunAsync() =>
        ExerciseWebHostHelper.RunInteractiveHostAsync(
            ConfigureServices,
            app =>
            {
                app.UseAuthentication();
                app.UseAuthorization();

                app.MapPost("/api/auth/login", (LoginDto login, IJwtTokenService tokens) =>
                {
                    var (ok, token, roles, permissions) = tokens.Authenticate(login.Username, login.Password);
                    return ok
                        ? Results.Ok(new { access_token = token, roles, permissions })
                        : Results.Unauthorized();
                });

                app.MapGet("/api/admin/dashboard", () => Results.Ok(new { area = "admin" }))
                    .RequireAuthorization("AdminOnly");

                app.MapGet("/api/orders", () => Results.Ok(new[] { new { Id = 1 } }))
                    .RequireAuthorization("OrdersRead");

                app.MapPost("/api/orders", () => Results.Created("/api/orders/99", new { Id = 99 }))
                    .RequireAuthorization("OrdersWrite");
            },
            "Exercise 31: Claims, Roles & Policies");

    private static void ConfigureServices(WebApplicationBuilder builder)
    {
        var jwt = new JwtSettings
        {
            Issuer = "TrainingIssuer",
            Audience = "TrainingAudience",
            SigningKey = "TrainingSigningKey_ChangeInProduction_Min32Chars!",
            ExpirationMinutes = 30
        };

        builder.Services.AddSingleton<IJwtTokenService>(
            new JwtTokenService(Microsoft.Extensions.Options.Options.Create(jwt)));

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwt.Issuer,
                    ValidAudience = jwt.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SigningKey))
                };
            });

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("OrdersRead", policy => policy.RequireClaim("permission", "orders:read"));
            options.AddPolicy("OrdersWrite", policy => policy.RequireClaim("permission", "orders:write"));
            options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
        });
    }

    private sealed record LoginDto(string Username, string Password);
}
