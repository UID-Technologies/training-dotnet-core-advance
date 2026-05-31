namespace AdvancedProductionTraining.Console.Modules.UnitTesting;

public static class Exercise02_ArrangeActAssert
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 2: Arrange / Act / Assert");
        System.Console.WriteLine("----------------------------------");
        System.Console.WriteLine("""
          // Arrange — setup dependencies and inputs
          var sut = new PricingService();

          // Act — execute the behavior under test
          var discount = sut.CalculateDiscount(1000m, "GOLD");

          // Assert — verify outcomes
          discount.Should().Be(150m);
          """);
        System.Console.WriteLine("See: Tests/Unit/PricingServiceTests.cs");

        return Task.CompletedTask;
    }
}
