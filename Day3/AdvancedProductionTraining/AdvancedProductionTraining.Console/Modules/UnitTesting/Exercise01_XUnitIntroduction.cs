namespace AdvancedProductionTraining.Console.Modules.UnitTesting;

public static class Exercise01_XUnitIntroduction
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 1: xUnit Introduction");
        System.Console.WriteLine("------------------------------");
        System.Console.WriteLine("xUnit is the default test framework for modern .NET.");
        System.Console.WriteLine("  [Fact]       — single test method");
        System.Console.WriteLine("  [Theory]     — parameterized tests");
        System.Console.WriteLine("  [InlineData] — test case data");
        System.Console.WriteLine();
        System.Console.WriteLine("Test project: AdvancedProductionTraining.Tests");
        System.Console.WriteLine("Compare with NUnit ([Test]) and MSTest ([TestMethod]) — xUnit is idiomatic for .NET Core.");

        return Task.CompletedTask;
    }
}
