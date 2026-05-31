namespace AdvancedProductionTraining.Console.Modules.IntegrationTesting;

public static class Exercise14_TestingAspNetCoreApis
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 14: Testing ASP.NET Core APIs");
        System.Console.WriteLine("--------------------------------------");
        System.Console.WriteLine("""
          var response = await client.PostAsJsonAsync("/api/orders", payload);
          response.StatusCode.Should().Be(HttpStatusCode.Created);
          """);
        System.Console.WriteLine("Package: Microsoft.AspNetCore.Mvc.Testing");

        return Task.CompletedTask;
    }
}
