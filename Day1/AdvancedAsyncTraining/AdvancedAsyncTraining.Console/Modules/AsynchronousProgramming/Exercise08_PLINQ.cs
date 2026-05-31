using System.Diagnostics;
using AdvancedAsyncTraining.Console.Modules.AsynchronousProgramming.Models;

namespace AdvancedAsyncTraining.Console.Modules.AsynchronousProgramming;

public static class Exercise08_PLINQ
{
    public static void Run()
    {
        System.Console.WriteLine("Exercise 8: PLINQ Fraud Analytics");
        System.Console.WriteLine("---------------------------------");

        var transactions = Enumerable.Range(1, 1_000_000)
            .Select(i => new Transaction(i, Random.Shared.Next(100, 100_000)))
            .ToList();

        var stopwatch = Stopwatch.StartNew();

        var sequentialResult = transactions
            .Where(IsSuspicious)
            .ToList();

        stopwatch.Stop();
        System.Console.WriteLine($"Sequential Count: {sequentialResult.Count}");
        System.Console.WriteLine($"Sequential Time: {stopwatch.ElapsedMilliseconds} ms");

        stopwatch.Restart();

        var parallelResult = transactions
            .AsParallel()
            .WithDegreeOfParallelism(Environment.ProcessorCount)
            .Where(IsSuspicious)
            .ToList();

        stopwatch.Stop();
        System.Console.WriteLine($"Parallel Count: {parallelResult.Count}");
        System.Console.WriteLine($"Parallel Time: {stopwatch.ElapsedMilliseconds} ms");

        System.Console.WriteLine("Exercise completed");
    }

    private static bool IsSuspicious(Transaction transaction)
    {
        return transaction.Amount > 90_000;
    }
}


