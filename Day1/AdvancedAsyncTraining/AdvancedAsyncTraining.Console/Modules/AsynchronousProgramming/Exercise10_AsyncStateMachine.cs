namespace AdvancedAsyncTraining.Console.Modules.AsynchronousProgramming;

public static class Exercise10_AsyncStateMachine
{
    public static async Task RunAsync()
    {
        System.Console.WriteLine("Exercise 10: Async State Machine");
        System.Console.WriteLine("--------------------------------");

        System.Console.WriteLine("Before calling async method");

        var result = await CalculateAsync();

        System.Console.WriteLine($"Result: {result}");
        System.Console.WriteLine("Open this file in SharpLab to inspect compiler-generated state machine.");
    }

    private static async Task<int> CalculateAsync()
    {
        System.Console.WriteLine("Before await");
        System.Console.WriteLine($"Thread before await: {Environment.CurrentManagedThreadId}");

        await Task.Delay(1000);

        System.Console.WriteLine("After await");
        System.Console.WriteLine($"Thread after await: {Environment.CurrentManagedThreadId}");

        return 100;
    }
}


