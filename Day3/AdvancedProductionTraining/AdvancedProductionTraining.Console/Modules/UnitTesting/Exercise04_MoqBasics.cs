namespace AdvancedProductionTraining.Console.Modules.UnitTesting;

public static class Exercise04_MoqBasics
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 4: Moq Basics");
        System.Console.WriteLine("----------------------");
        System.Console.WriteLine("""
          var mock = new Mock<IOrderRepository>();
          mock.Setup(x => x.GetByIdAsync(1, default))
              .ReturnsAsync(new Order { Id = 1, Status = "Submitted" });

          mock.Verify(x => x.AddAsync(It.IsAny<Order>(), default), Times.Once);
          """);
        System.Console.WriteLine("Moq creates test doubles for interfaces without manual stub classes.");

        return Task.CompletedTask;
    }
}
