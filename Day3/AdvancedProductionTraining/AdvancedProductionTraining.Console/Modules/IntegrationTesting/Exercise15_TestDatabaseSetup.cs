namespace AdvancedProductionTraining.Console.Modules.IntegrationTesting;

public static class Exercise15_TestDatabaseSetup
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 15: Test Database Setup");
        System.Console.WriteLine("--------------------------------");
        System.Console.WriteLine("Strategies:");
        System.Console.WriteLine("  • SQLite :memory: (used in TrainingWebApplicationFactory)");
        System.Console.WriteLine("  • EF Core InMemory provider (quick, limited SQL fidelity)");
        System.Console.WriteLine("  • Testcontainers (Docker SQL/Postgres for production parity)");
        System.Console.WriteLine();
        System.Console.WriteLine("Keep database per test class or use respawn/transaction rollback for isolation.");

        return Task.CompletedTask;
    }
}
