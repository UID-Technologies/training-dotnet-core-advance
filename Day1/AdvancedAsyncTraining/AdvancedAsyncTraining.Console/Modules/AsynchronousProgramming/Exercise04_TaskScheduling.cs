namespace AdvancedAsyncTraining.Console.Modules.AsynchronousProgramming;

public static class Exercise04_TaskScheduling
{
    public static async Task RunAsync()
    {
        System.Console.WriteLine("Exercise 4: Task Scheduling");
        System.Console.WriteLine("---------------------------");

        System.Console.WriteLine($"Main Thread: {Environment.CurrentManagedThreadId}");
        System.Console.WriteLine($"TaskScheduler.Current: {TaskScheduler.Current}");
        System.Console.WriteLine($"TaskScheduler.Default: {TaskScheduler.Default}");

        var tasks = Enumerable.Range(1, 20)
            .Select(i => Task.Run(() =>
            {
                System.Console.WriteLine(
                    $"Item {i}, Task {Task.CurrentId}, Thread {Environment.CurrentManagedThreadId}");
            }));

        await Task.WhenAll(tasks);

        System.Console.WriteLine("Exercise completed");
    }
}


