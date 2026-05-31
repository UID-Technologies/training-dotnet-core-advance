namespace AdvancedAsyncTraining.Console.Modules.EntityFrameworkCore;

public static class Exercise23_DatabaseFirst
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 23: Database First Approach");
        System.Console.WriteLine("Run this command in terminal:");
        System.Console.WriteLine("dotnet ef dbcontext scaffold \"Data Source=advanced-efcore.db\" Microsoft.EntityFrameworkCore.Sqlite -o DatabaseFirstModels -c DatabaseFirstDbContext --force");
        System.Console.WriteLine("Use this approach when DB schema already exists and is managed externally.");

        return Task.CompletedTask;
    }
}
