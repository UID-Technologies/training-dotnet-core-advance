using System.Collections.Concurrent;

namespace AdvancedAsyncTraining.Console.Modules.AsynchronousProgramming;

public static class Exercise07_ParallelForEach
{
    public static void Run()
    {
        System.Console.WriteLine("Exercise 7: Parallel.ForEach");
        System.Console.WriteLine("----------------------------");

        var documents = Enumerable.Range(1, 100).ToList();
        var results = new ConcurrentDictionary<int, string>();

        Parallel.ForEach(documents, documentId =>
        {
            Thread.Sleep(100);

            results.TryAdd(
                documentId,
                $"Document {documentId} processed on Thread {Environment.CurrentManagedThreadId}");
        });

        System.Console.WriteLine($"Processed documents: {results.Count}");

        foreach (var result in results.OrderBy(r => r.Key).Take(10))
        {
            System.Console.WriteLine(result.Value);
        }

        System.Console.WriteLine("Exercise completed");
    }
}


