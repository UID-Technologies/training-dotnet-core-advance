namespace AdvancedAsyncTraining.Console.Modules.AsynchronousProgramming;

public static class Exercise11_ConfigureAwait
{
    public static async Task RunAsync()
    {
        System.Console.WriteLine("Exercise 11: ConfigureAwait");
        System.Console.WriteLine("---------------------------");

        System.Console.WriteLine($"Before await Thread: {Environment.CurrentManagedThreadId}");

        var result = await LoadDataAsync();

        System.Console.WriteLine($"After await Thread: {Environment.CurrentManagedThreadId}");
        System.Console.WriteLine(result);

        System.Console.WriteLine("ConfigureAwait(false) is mainly useful in reusable libraries.");
    }

    private static async Task<string> LoadDataAsync()
    {
        await Task.Delay(1000).ConfigureAwait(false);

        return "Data loaded using ConfigureAwait(false)";
    }
}


