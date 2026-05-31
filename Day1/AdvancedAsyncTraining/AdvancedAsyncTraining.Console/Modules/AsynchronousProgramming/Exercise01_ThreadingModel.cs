namespace AdvancedAsyncTraining.Console.Modules.AsynchronousProgramming;

public static class Exercise01_ThreadingModel
{
    public static async Task RunAsync()
    {
        System.Console.WriteLine("Exercise 1: Threading Model in .NET");
        System.Console.WriteLine("-----------------------------------");

        System.Console.WriteLine($"Main Thread: {Environment.CurrentManagedThreadId}");

        System.Console.WriteLine("Starting blocking operation...");
        Thread.Sleep(2000);
        System.Console.WriteLine($"Blocking operation completed on Thread: {Environment.CurrentManagedThreadId}");

        System.Console.WriteLine("Starting non-blocking async operation...");
        await Task.Delay(2000);
        System.Console.WriteLine($"Async operation resumed on Thread: {Environment.CurrentManagedThreadId}");

        System.Console.WriteLine("Starting ThreadPool work item...");

        var completionSource = new TaskCompletionSource<bool>();

        ThreadPool.QueueUserWorkItem(_ =>
        {
            System.Console.WriteLine($"ThreadPool Thread: {Environment.CurrentManagedThreadId}");
            completionSource.SetResult(true);
        });

        await completionSource.Task;

        System.Console.WriteLine("Exercise completed");
    }
}


