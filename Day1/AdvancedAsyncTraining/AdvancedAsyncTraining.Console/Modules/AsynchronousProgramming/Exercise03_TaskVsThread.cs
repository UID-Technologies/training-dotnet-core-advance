namespace AdvancedAsyncTraining.Console.Modules.AsynchronousProgramming;

public static class Exercise03_TaskVsThread
{
    public static async Task RunAsync()
    {
        System.Console.WriteLine("Exercise 3: Task vs Thread");
        System.Console.WriteLine("--------------------------");

        var messages = Enumerable.Range(1, 20).ToList();

        System.Console.WriteLine("Bad approach: thread per message");

        foreach (var message in messages.Take(5))
        {
            var localMessage = message;

            var thread = new Thread(() =>
            {
                System.Console.WriteLine($"Message {localMessage} processed on Thread {Environment.CurrentManagedThreadId}");
                Thread.Sleep(500);
            });

            thread.Start();
            thread.Join();
        }

        System.Console.WriteLine("Better approach: controlled task concurrency");

        await Parallel.ForEachAsync(
            messages,
            new ParallelOptions
            {
                MaxDegreeOfParallelism = 5
            },
            async (message, token) =>
            {
                await ProcessMessageAsync(message, token);
            });

        System.Console.WriteLine("Exercise completed");
    }

    private static async Task ProcessMessageAsync(int messageId, CancellationToken token)
    {
        await Task.Delay(500, token);
        System.Console.WriteLine($"Message {messageId} processed on Thread {Environment.CurrentManagedThreadId}");
    }
}


