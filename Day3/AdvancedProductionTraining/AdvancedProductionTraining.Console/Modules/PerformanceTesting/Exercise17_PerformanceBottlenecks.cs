namespace AdvancedProductionTraining.Console.Modules.PerformanceTesting;

public static class Exercise17_PerformanceBottlenecks
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 17: Performance Bottlenecks");
        System.Console.WriteLine("------------------------------------");
        System.Console.WriteLine("Common API bottlenecks:");
        System.Console.WriteLine("  • N+1 database queries");
        System.Console.WriteLine("  • Missing indexes");
        System.Console.WriteLine("  • Synchronous I/O");
        System.Console.WriteLine("  • Large payloads / no pagination");
        System.Console.WriteLine("  • Lock contention and over-allocation");
        System.Console.WriteLine();
        System.Console.WriteLine("Measure before optimizing — profile with dotnet-counters, traces, load tests.");

        return Task.CompletedTask;
    }
}
