namespace AdvancedProductionTraining.Console.Modules.Observability;

public static class Exercise36_DistributedTracing
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 36: Distributed Tracing");
        System.Console.WriteLine("--------------------------------");
        System.Console.WriteLine("Trace spans across API → database → external HTTP.");
        System.Console.WriteLine("Propagate trace context: traceparent header, W3C format.");
        System.Console.WriteLine("X-Correlation-Id middleware complements platform tracing.");

        return Task.CompletedTask;
    }
}
