using AdvancedProductionTraining.Console.Shared;

namespace AdvancedProductionTraining.Console.Modules.UnitTesting;

public static class Exercise03_WritingUnitTests
{
    public static async Task RunAsync()
    {
        System.Console.WriteLine("Exercise 3: Writing Unit Tests");
        System.Console.WriteLine("Running PricingServiceTests...");
        System.Console.WriteLine();

        var exitCode = await TestRunnerHelper.RunDotnetTestAsync("FullyQualifiedName~PricingServiceTests");
        System.Console.WriteLine(exitCode == 0 ? "All tests passed." : $"Tests failed with exit code {exitCode}.");
    }
}
