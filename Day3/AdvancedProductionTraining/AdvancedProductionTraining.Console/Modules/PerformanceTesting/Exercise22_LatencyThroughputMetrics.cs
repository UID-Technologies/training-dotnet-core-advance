namespace AdvancedProductionTraining.Console.Modules.PerformanceTesting;

public static class Exercise22_LatencyThroughputMetrics
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 22: Latency, Throughput, Error Rate");
        System.Console.WriteLine("--------------------------------------------");
        System.Console.WriteLine("  Latency     — p50, p95, p99 response time");
        System.Console.WriteLine("  Throughput  — requests per second (RPS)");
        System.Console.WriteLine("  Error rate  — % failed requests (4xx/5xx/timeouts)");
        System.Console.WriteLine();
        System.Console.WriteLine("SLO example: p95 < 500ms, error rate < 1% at 100 RPS.");

        return Task.CompletedTask;
    }
}
