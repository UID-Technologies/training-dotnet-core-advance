using AdvancedProductionTraining.Console.Shared;

namespace AdvancedProductionTraining.Console.Modules.UnitTesting;

public static class Exercise10_UnitTestLab
{
    public static async Task RunAsync()
    {
        System.Console.WriteLine("Exercise 10: Lab — Unit Tests for Business Services");
        System.Console.WriteLine("=================================================");
        System.Console.WriteLine("Target: OrderService and PricingService in Core project");
        System.Console.WriteLine("Running all unit tests...");
        System.Console.WriteLine();

        var exitCode = await TestRunnerHelper.RunDotnetTestAsync("FullyQualifiedName~AdvancedProductionTraining.Tests.Unit");
        System.Console.WriteLine();
        System.Console.WriteLine("Extend the lab:");
        System.Console.WriteLine("  • Add test for CancelOrderAsync when status is Shipped");
        System.Console.WriteLine("  • Add Theory for invalid customer tiers");
    }
}
