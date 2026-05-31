using AdvancedProductionTraining.Console.Shared;

namespace AdvancedProductionTraining.Console.Modules.UnitTesting;

public static class Exercise05_MockingDependencies
{
    public static async Task RunAsync()
    {
        System.Console.WriteLine("Exercise 5: Mocking Dependencies");
        System.Console.WriteLine("Running OrderServiceTests with Moq...");
        System.Console.WriteLine();

        var exitCode = await TestRunnerHelper.RunDotnetTestAsync("FullyQualifiedName~OrderServiceTests");
        System.Console.WriteLine(exitCode == 0 ? "Mock-based tests passed." : $"Failed: {exitCode}");
    }
}
