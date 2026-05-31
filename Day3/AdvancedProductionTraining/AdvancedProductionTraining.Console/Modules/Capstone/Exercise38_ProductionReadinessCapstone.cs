namespace AdvancedProductionTraining.Console.Modules.Capstone;

public static class Exercise38_ProductionReadinessCapstone
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 38: Production Readiness Capstone");
        System.Console.WriteLine("==========================================");
        System.Console.WriteLine("Complete checklist:");
        System.Console.WriteLine("  [ ] dotnet test — all unit + integration tests pass");
        System.Console.WriteLine("  [ ] dotnet run --project AdvancedProductionTraining.Web");
        System.Console.WriteLine("  [ ] GET /health and /health/ready return Healthy");
        System.Console.WriteLine("  [ ] Serilog request logs + correlation ID in output");
        System.Console.WriteLine("  [ ] OpenTelemetry traces visible in console");
        System.Console.WriteLine("  [ ] k6 load test meets latency/error thresholds");
        System.Console.WriteLine("  [ ] Rate limit returns 429 under flood");
        System.Console.WriteLine("  [ ] Security scan (ZAP/Postman) reviewed");
        System.Console.WriteLine();
        System.Console.WriteLine("Commands:");
        System.Console.WriteLine("  cd Day3/AdvancedProductionTraining");
        System.Console.WriteLine("  dotnet test");
        System.Console.WriteLine("  dotnet run --project AdvancedProductionTraining.Web --launch-profile ProductionApi");

        return Task.CompletedTask;
    }
}
