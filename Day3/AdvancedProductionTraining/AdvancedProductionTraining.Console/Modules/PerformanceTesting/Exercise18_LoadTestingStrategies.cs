namespace AdvancedProductionTraining.Console.Modules.PerformanceTesting;

public static class Exercise18_LoadTestingStrategies
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 18: Load Testing Strategies");
        System.Console.WriteLine("------------------------------------");
        System.Console.WriteLine("  Smoke test    — minimal load, verify system works");
        System.Console.WriteLine("  Load test     — expected production traffic");
        System.Console.WriteLine("  Stress test   — beyond capacity, find breaking point");
        System.Console.WriteLine("  Soak test     — sustained load, find memory leaks");
        System.Console.WriteLine();
        System.Console.WriteLine("Tools: k6, JMeter, Postman Collection Runner, Azure Load Testing");

        return Task.CompletedTask;
    }
}
