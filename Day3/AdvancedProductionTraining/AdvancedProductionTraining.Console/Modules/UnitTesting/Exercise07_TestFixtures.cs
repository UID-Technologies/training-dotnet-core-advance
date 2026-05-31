using AdvancedProductionTraining.Console.Shared;

namespace AdvancedProductionTraining.Console.Modules.UnitTesting;

public static class Exercise07_TestFixtures
{
    public static async Task RunAsync()
    {
        System.Console.WriteLine("Exercise 7: Test Fixtures (IClassFixture)");
        System.Console.WriteLine("Share expensive setup across tests in a class.");
        System.Console.WriteLine("See: OrderServiceFixtureTests + OrderServiceFixture");
        System.Console.WriteLine();

        var exitCode = await TestRunnerHelper.RunDotnetTestAsync("FullyQualifiedName~OrderServiceFixtureTests");
        System.Console.WriteLine(exitCode == 0 ? "Fixture tests passed." : $"Failed: {exitCode}");
    }
}
