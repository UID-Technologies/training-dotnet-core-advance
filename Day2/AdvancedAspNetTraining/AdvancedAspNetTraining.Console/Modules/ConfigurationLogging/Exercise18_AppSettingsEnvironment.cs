using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AdvancedAspNetTraining.Console.Modules.ConfigurationLogging;

public static class Exercise18_AppSettingsEnvironment
{
    public static async Task RunAsync()
    {
        System.Console.WriteLine("Exercise 18: appsettings.json & Environment Configuration");
        System.Console.WriteLine("---------------------------------------------------------");

        var host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, config) =>
            {
                var env = context.HostingEnvironment;
                System.Console.WriteLine($"Environment name: {env.EnvironmentName}");
                System.Console.WriteLine("Loaded files: appsettings.json + appsettings.{Environment}.json");
            })
            .Build();

        var configuration = host.Services.GetRequiredService<IConfiguration>();

        System.Console.WriteLine($"Training:EnvironmentName = {configuration["Training:EnvironmentName"]}");
        System.Console.WriteLine($"Jwt:Issuer = {configuration["Jwt:Issuer"] ?? "(from Web project when running API)"}");

        System.Console.WriteLine();
        System.Console.WriteLine("Override at runtime:");
        System.Console.WriteLine("  set ASPNETCORE_ENVIRONMENT=Staging");
        System.Console.WriteLine("  dotnet run --project AdvancedAspNetTraining.Web");

        await host.StopAsync();
    }
}
