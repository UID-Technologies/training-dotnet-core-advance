using AdvancedProductionTraining.Console.Shared;

namespace AdvancedProductionTraining.Console.Modules.IntegrationTesting;

public static class Exercise16_IntegrationTestLab
{
    public static async Task RunAsync()
    {
        System.Console.WriteLine("Exercise 16: Lab — Test Complete API Endpoints");
        System.Console.WriteLine("==============================================");
        System.Console.WriteLine("Running integration tests...");
        System.Console.WriteLine();

        var exitCode = await TestRunnerHelper.RunDotnetTestAsync("FullyQualifiedName~AdvancedProductionTraining.Tests.Integration");
        System.Console.WriteLine(exitCode == 0 ? "Integration tests passed." : $"Failed: {exitCode}");
    }
}
