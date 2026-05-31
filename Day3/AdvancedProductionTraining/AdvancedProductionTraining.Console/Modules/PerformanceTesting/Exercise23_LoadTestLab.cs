namespace AdvancedProductionTraining.Console.Modules.PerformanceTesting;

public static class Exercise23_LoadTestLab
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 23: Lab — Load Test Web API");
        System.Console.WriteLine("====================================");
        System.Console.WriteLine("Step 1 — Start API:");
        System.Console.WriteLine("  dotnet run --project AdvancedProductionTraining.Web --launch-profile ProductionApi");
        System.Console.WriteLine();
        System.Console.WriteLine("Step 2 — Install k6: https://k6.io/docs/get-started/installation/");
        System.Console.WriteLine();
        System.Console.WriteLine("Step 3 — Run load test:");
        System.Console.WriteLine("  k6 run Scripts/k6-load-test.js");
        System.Console.WriteLine("  k6 run -e API_URL=http://localhost:5250 Scripts/k6-load-test.js");
        System.Console.WriteLine();
        System.Console.WriteLine("Alternatives: Apache JMeter, Postman Collection Runner with iterations.");
        System.Console.WriteLine("Script location: AdvancedProductionTraining/Scripts/k6-load-test.js");

        return Task.CompletedTask;
    }
}
