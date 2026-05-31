namespace AdvancedProductionTraining.Console.Modules.IntegrationTesting;

public static class Exercise13_InMemoryTestServer
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 13: In-Memory Test Server");
        System.Console.WriteLine("--------------------------------");
        System.Console.WriteLine("factory.CreateClient() returns HttpClient that talks to TestServer — no network port.");
        System.Console.WriteLine("Benefits: fast, deterministic, runs in CI without Kestrel binding.");
        System.Console.WriteLine();
        System.Console.WriteLine("Used in OrdersApiIntegrationTests.");

        return Task.CompletedTask;
    }
}
