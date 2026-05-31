using System.Collections.Concurrent;
using System.Diagnostics;

namespace AdvancedAsyncTraining.Console.Modules.MemoryManagement;

public static class Exercise21_AsyncPipelinePerformance
{
    public static async Task RunAsync()
    {
        System.Console.WriteLine("Exercise 21: Async Data Processing Pipeline");

        var records = Enumerable.Range(1, 100_000).ToList();
        var results = new ConcurrentBag<string>();

        var stopwatch = Stopwatch.StartNew();

        await Parallel.ForEachAsync(
            records,
            new ParallelOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            },
            async (record, token) =>
            {
                var transformed = Transform(record);
                var isValid = Validate(transformed);

                if (isValid)
                {
                    await PersistAsync(transformed, token);
                    results.Add(transformed);
                }
            });

        stopwatch.Stop();

        System.Console.WriteLine($"Processed records: {results.Count}");
        System.Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");
        System.Console.WriteLine($"Memory usage: {GC.GetTotalMemory(false) / 1024 / 1024} MB");
    }

    private static string Transform(int record)
    {
        return $"RECORD-{record}";
    }

    private static bool Validate(string record)
    {
        return record.Length > 5;
    }

    private static async Task PersistAsync(string record, CancellationToken token)
    {
        _ = record;
        await Task.Delay(1, token);
    }
}
