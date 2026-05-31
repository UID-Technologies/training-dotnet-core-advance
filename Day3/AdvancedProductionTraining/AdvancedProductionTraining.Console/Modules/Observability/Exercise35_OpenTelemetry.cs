namespace AdvancedProductionTraining.Console.Modules.Observability;

public static class Exercise35_OpenTelemetry
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 35: OpenTelemetry");
        System.Console.WriteLine("--------------------------");
        System.Console.WriteLine("Web project exports traces to console via OpenTelemetry SDK.");
        System.Console.WriteLine("Production: export to Azure Monitor, Jaeger, or OTLP collector.");
        System.Console.WriteLine();
        System.Console.WriteLine("Packages: OpenTelemetry.Extensions.Hosting, Instrumentation.AspNetCore");

        return Task.CompletedTask;
    }
}
