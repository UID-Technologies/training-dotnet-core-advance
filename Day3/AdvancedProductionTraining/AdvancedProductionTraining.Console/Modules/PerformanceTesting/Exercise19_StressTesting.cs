namespace AdvancedProductionTraining.Console.Modules.PerformanceTesting;

public static class Exercise19_StressTesting
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 19: Stress Testing");
        System.Console.WriteLine("---------------------------");
        System.Console.WriteLine("Increase virtual users until error rate or latency SLO breaks.");
        System.Console.WriteLine("Watch: HTTP 429 (rate limit), 503, thread pool starvation, GC pauses.");
        System.Console.WriteLine("Day 3 API has fixed-window rate limiting (30 req/min per IP).");

        return Task.CompletedTask;
    }
}
