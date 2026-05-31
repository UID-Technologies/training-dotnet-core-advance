namespace AdvancedProductionTraining.Console.Modules.IntegrationTesting;

public static class Exercise11_IntegrationVsUnit
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 11: Integration vs Unit Testing");
        System.Console.WriteLine("----------------------------------------");
        System.Console.WriteLine("Unit tests — isolate one class, mock collaborators, fast, many.");
        System.Console.WriteLine("Integration tests — real DI, database, HTTP pipeline, slower, fewer.");
        System.Console.WriteLine();
        System.Console.WriteLine("Test pyramid: many unit → some integration → few E2E.");

        return Task.CompletedTask;
    }
}
