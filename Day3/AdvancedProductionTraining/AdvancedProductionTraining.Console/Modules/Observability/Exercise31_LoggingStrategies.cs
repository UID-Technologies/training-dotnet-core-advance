namespace AdvancedProductionTraining.Console.Modules.Observability;

public static class Exercise31_LoggingStrategies
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 31: Logging Strategies");
        System.Console.WriteLine("-------------------------------");
        System.Console.WriteLine("  • Log levels: Trace/Debug for dev, Information for business events, Warning/Error for problems");
        System.Console.WriteLine("  • Never log secrets or PII without redaction");
        System.Console.WriteLine("  • Centralize logs (App Insights, ELK, Seq)");
        System.Console.WriteLine("  • Correlate with trace IDs across services");

        return Task.CompletedTask;
    }
}
