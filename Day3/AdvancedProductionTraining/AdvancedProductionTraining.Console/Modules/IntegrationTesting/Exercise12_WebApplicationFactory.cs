namespace AdvancedProductionTraining.Console.Modules.IntegrationTesting;

public static class Exercise12_WebApplicationFactory
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 12: WebApplicationFactory");
        System.Console.WriteLine("----------------------------------");
        System.Console.WriteLine("Bootstraps the real application in-memory for tests:");
        System.Console.WriteLine("  public class TrainingWebApplicationFactory : WebApplicationFactory<Program>");
        System.Console.WriteLine();
        System.Console.WriteLine("Override ConfigureWebHost to replace services (e.g. SQLite in-memory DB).");
        System.Console.WriteLine("See: Tests/Integration/TrainingWebApplicationFactory.cs");

        return Task.CompletedTask;
    }
}
