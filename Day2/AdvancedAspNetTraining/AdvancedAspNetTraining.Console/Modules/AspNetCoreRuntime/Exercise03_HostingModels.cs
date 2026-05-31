namespace AdvancedAspNetTraining.Console.Modules.AspNetCoreRuntime;

public static class Exercise03_HostingModels
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 3: ASP.NET Core Hosting Models");
        System.Console.WriteLine("----------------------------------------");

        var models = new[]
        {
            ("In-Process (IIS)", "App runs inside IIS worker process (w3wp). Lower latency on Windows."),
            ("Out-of-Process (IIS)", "IIS forwards requests to Kestrel via ASP.NET Core Module."),
            ("Kestrel Only", "Self-hosted: containers, Linux services, `dotnet run`, Windows Service."),
            ("Generic Host", "WebApplication.CreateBuilder() unifies logging, config, DI, lifetime.")
        };

        foreach (var (name, description) in models)
        {
            System.Console.WriteLine();
            System.Console.WriteLine($"  {name}");
            System.Console.WriteLine($"    {description}");
        }

        System.Console.WriteLine();
        System.Console.WriteLine($"Current environment: {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Not set"}");
        System.Console.WriteLine("Set ASPNETCORE_ENVIRONMENT=Development|Staging|Production to switch behavior.");

        return Task.CompletedTask;
    }
}
