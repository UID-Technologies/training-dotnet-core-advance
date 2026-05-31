using AdvancedProductionTraining.Console.Shared;

namespace AdvancedProductionTraining.Console.Modules.UnitTesting;

public static class Exercise06_DependencyInjectionTesting
{
    public static async Task RunAsync()
    {
        System.Console.WriteLine("Exercise 6: Dependency Injection Testing");
        System.Console.WriteLine("Build a ServiceCollection, register production types, resolve SUT.");
        System.Console.WriteLine();

        var exitCode = await TestRunnerHelper.RunDotnetTestAsync("FullyQualifiedName~OrderServiceDiTests");
        System.Console.WriteLine(exitCode == 0 ? "DI resolution test passed." : $"Failed: {exitCode}");
    }
}
