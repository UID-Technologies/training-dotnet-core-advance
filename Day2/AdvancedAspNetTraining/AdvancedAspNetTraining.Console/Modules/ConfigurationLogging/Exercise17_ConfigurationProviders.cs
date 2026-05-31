using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace AdvancedAspNetTraining.Console.Modules.ConfigurationLogging;

public static class Exercise17_ConfigurationProviders
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 17: Configuration Providers");
        System.Console.WriteLine("------------------------------------");

        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.training.json", optional: true)
            .AddEnvironmentVariables(prefix: "TRAINING_")
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Training:ApiName"] = "OrdersApi",
                ["Training:Region"] = "in-memory"
            })
            .AddCommandLine(Environment.GetCommandLineArgs())
            .Build();

        System.Console.WriteLine("Provider chain (last wins):");
        System.Console.WriteLine("  JSON file -> Environment variables -> In-memory -> Command line");
        System.Console.WriteLine();
        System.Console.WriteLine($"  Training:ApiName  = {configuration["Training:ApiName"]}");
        System.Console.WriteLine($"  Training:Region   = {configuration["Training:Region"]}");
        System.Console.WriteLine($"  Training:ApiBasePath = {configuration["Training:ApiBasePath"] ?? "(not set)"}");

        return Task.CompletedTask;
    }
}
