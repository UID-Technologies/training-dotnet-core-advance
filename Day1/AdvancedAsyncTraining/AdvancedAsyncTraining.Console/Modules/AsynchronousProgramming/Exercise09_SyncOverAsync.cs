namespace AdvancedAsyncTraining.Console.Modules.AsynchronousProgramming;

public static class Exercise09_SyncOverAsync
{
    public static void Run()
    {
        System.Console.WriteLine("Exercise 9: Sync Over Async");
        System.Console.WriteLine("---------------------------");

        System.Console.WriteLine("Bad approach using .Result");

        var badResult = GetCustomerAsync().Result;
        System.Console.WriteLine(badResult);

        System.Console.WriteLine("This works in console, but can cause thread blocking/deadlocks in UI or legacy ASP.NET.");

        System.Console.WriteLine("Preferred approach should be async all the way:");
        System.Console.WriteLine("await GetCustomerAsync();");

        System.Console.WriteLine("Exercise completed");
    }

    private static async Task<string> GetCustomerAsync()
    {
        await Task.Delay(1000);
        return "Customer loaded";
    }
}


