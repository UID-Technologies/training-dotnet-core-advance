namespace AdvancedProductionTraining.Console.Modules.PerformanceTesting;

public static class Exercise20_BenchmarkDotNet
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 20: BenchmarkDotNet");
        System.Console.WriteLine("----------------------------");
        System.Console.WriteLine("Micro-benchmark CPU/memory for hot paths — not a substitute for load tests.");
        System.Console.WriteLine("Project: AdvancedProductionTraining.Benchmarks");
        System.Console.WriteLine();
        System.Console.WriteLine("Run:");
        System.Console.WriteLine("  dotnet run -c Release --project AdvancedProductionTraining.Benchmarks");

        return Task.CompletedTask;
    }
}
