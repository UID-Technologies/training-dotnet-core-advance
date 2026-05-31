namespace AdvancedProductionTraining.Console.Modules.Observability;

public static class Exercise37_ApplicationInsights
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 37: Application Insights");
        System.Console.WriteLine("---------------------------------");
        System.Console.WriteLine("Azure Monitor Application Insights for .NET:");
        System.Console.WriteLine("  builder.Services.AddOpenTelemetry().UseAzureMonitor()");
        System.Console.WriteLine();
        System.Console.WriteLine("Provides: request telemetry, dependencies, exceptions, live metrics, KQL queries.");

        return Task.CompletedTask;
    }
}
