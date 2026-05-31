namespace AdvancedProductionTraining.Console.Modules.UnitTesting;

public static class Exercise09_NUnitMSTestComparison
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 9: xUnit vs NUnit vs MSTest");
        System.Console.WriteLine("------------------------------------");
        System.Console.WriteLine("| Feature        | xUnit        | NUnit          | MSTest        |");
        System.Console.WriteLine("| Test method    | [Fact]       | [Test]         | [TestMethod]  |");
        System.Console.WriteLine("| Setup          | Constructor  | [SetUp]        | [TestInitialize]|");
        System.Console.WriteLine("| Parallel       | By default   | Configurable   | Configurable  |");
        System.Console.WriteLine();
        System.Console.WriteLine("This course standardizes on xUnit + Moq + FluentAssertions.");

        return Task.CompletedTask;
    }
}
