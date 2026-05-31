namespace AdvancedProductionTraining.Console.Modules.UnitTesting;

public static class Exercise08_FluentAssertions
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 8: FluentAssertions");
        System.Console.WriteLine("----------------------------");
        System.Console.WriteLine("Readable assertions:");
        System.Console.WriteLine("  result.Should().Be(850m);");
        System.Console.WriteLine("  act.Should().ThrowAsync<ArgumentException>();");
        System.Console.WriteLine("  collection.Should().HaveCount(3).And.OnlyContain(x => x.Total > 0);");
        System.Console.WriteLine();
        System.Console.WriteLine("Used throughout AdvancedProductionTraining.Tests");

        return Task.CompletedTask;
    }
}
