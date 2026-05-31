namespace AdvancedProductionTraining.Console.Modules.Observability;

public static class Exercise34_HealthChecks
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 34: Health Checks");
        System.Console.WriteLine("--------------------------");
        System.Console.WriteLine("  GET /health        — all checks");
        System.Console.WriteLine("  GET /health/ready  — readiness (database)");
        System.Console.WriteLine();
        System.Console.WriteLine("Kubernetes uses liveness vs readiness probes for orchestration.");

        return Task.CompletedTask;
    }
}
