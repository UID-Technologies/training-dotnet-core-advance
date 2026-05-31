namespace AdvancedProductionTraining.Console.Modules.SecurityTesting;

public static class Exercise28_ApiThrottling
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 28: API Throttling");
        System.Console.WriteLine("---------------------------");
        System.Console.WriteLine("Throttling protects backends from abuse and noisy neighbors.");
        System.Console.WriteLine("Patterns: per-API-key limits, sliding window, queue + 429, gateway-level (APIM, YARP).");
        System.Console.WriteLine("Difference from rate limiting: throttling may queue; rate limiting typically rejects.");

        return Task.CompletedTask;
    }
}
