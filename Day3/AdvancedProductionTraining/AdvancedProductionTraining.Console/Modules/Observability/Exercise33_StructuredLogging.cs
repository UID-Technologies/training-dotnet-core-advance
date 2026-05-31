namespace AdvancedProductionTraining.Console.Modules.Observability;

public static class Exercise33_StructuredLogging
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 33: Structured Logging");
        System.Console.WriteLine("-------------------------------");
        System.Console.WriteLine("Use message templates, not string interpolation:");
        System.Console.WriteLine("  logger.LogInformation(\"Order {OrderId} created for {Customer}\", id, name);");
        System.Console.WriteLine();
        System.Console.WriteLine("CorrelationIdMiddleware adds scope for distributed correlation.");

        return Task.CompletedTask;
    }
}
