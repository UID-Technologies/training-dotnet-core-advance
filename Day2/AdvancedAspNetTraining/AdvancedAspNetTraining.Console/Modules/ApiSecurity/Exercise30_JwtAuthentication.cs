using System.Text;
using AdvancedAspNetTraining.Console.Shared;
using AdvancedAspNetTraining.Web.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace AdvancedAspNetTraining.Console.Modules.ApiSecurity;

public static class Exercise30_JwtAuthentication
{
    public static Task RunAsync() =>
        ExerciseWebHostHelper.RunInteractiveHostAsync(
            builder =>
            {
                var jwt = new JwtSettings
                {
                    Issuer = "TrainingIssuer",
                    Audience = "TrainingAudience",
                    SigningKey = "TrainingSigningKey_ChangeInProduction_Min32Chars!",
                    ExpirationMinutes = 30
                };

                builder.Services.AddSingleton<IJwtTokenService>(new JwtTokenService(Microsoft.Extensions.Options.Options.Create(jwt)));

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

                builder.Services.AddAuthorization();
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen(o =>
                {
                    o.SwaggerDoc("v1", new OpenApiInfo { Title = "JWT Demo", Version = "v1" });
                    o.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header
                    });
                });
            },
            app =>
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseAuthentication();
                app.UseAuthorization();

                app.MapPost("/api/auth/login", (LoginDto login, IJwtTokenService tokens) =>
                {
                    var (ok, token, _, _) = tokens.Authenticate(login.Username, login.Password);
                    return ok ? Results.Ok(new { access_token = token }) : Results.Unauthorized();
                });

                app.MapGet("/api/secure/profile", () => Results.Ok(new { message = "Authenticated user" }))
                    .RequireAuthorization();
            },
            "Exercise 30: JWT (POST /api/auth/login then GET /api/secure/profile with Bearer token)");

    private sealed record LoginDto(string Username, string Password);
}
