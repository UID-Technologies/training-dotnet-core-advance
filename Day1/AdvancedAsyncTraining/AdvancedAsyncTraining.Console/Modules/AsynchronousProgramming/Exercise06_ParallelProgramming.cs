using System.Diagnostics;

namespace AdvancedAsyncTraining.Console.Modules.AsynchronousProgramming;

public static class Exercise06_ParallelProgramming
{
    public static void Run()
    {
        System.Console.WriteLine("Exercise 6: Parallel Programming");
        System.Console.WriteLine("--------------------------------");

        var customers = Enumerable.Range(1, 1_000_000).ToList();

        var stopwatch = Stopwatch.StartNew();

        foreach (var customer in customers)
        {
            CalculateTax(customer);
        }

        stopwatch.Stop();
        System.Console.WriteLine($"Sequential Time: {stopwatch.ElapsedMilliseconds} ms");

        stopwatch.Restart();

        Parallel.ForEach(customers, customer =>
        {
            CalculateTax(customer);
        });

        stopwatch.Stop();
        System.Console.WriteLine($"Parallel Time: {stopwatch.ElapsedMilliseconds} ms");

        System.Console.WriteLine("Exercise completed");
    }

    private static decimal CalculateTax(int customerId)
    {
        decimal taxableAmount = customerId * 100;
        decimal tax = taxableAmount * 0.18m;

        for (int i = 0; i < 10; i++)
        {
            tax += i * 0.0001m;
        }

        return tax;
    }
}


