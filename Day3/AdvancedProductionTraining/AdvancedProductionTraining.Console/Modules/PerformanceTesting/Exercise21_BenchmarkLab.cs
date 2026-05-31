using AdvancedProductionTraining.Console.Shared;

namespace AdvancedProductionTraining.Console.Modules.PerformanceTesting;

public static class Exercise21_BenchmarkLab
{
    public static async Task RunAsync()
    {
        System.Console.WriteLine("Exercise 21: Benchmark Lab");
        System.Console.WriteLine("Running BenchmarkDotNet (Release, may take 1–2 minutes)...");
        System.Console.WriteLine();

        await TestRunnerHelper.RunDotnetBenchmarkAsync();
    }
}
