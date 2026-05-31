namespace AdvancedAspNetTraining.Console.Modules.Capstone;

public static class Exercise36_ProductionReadyProject
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 36: Hands-on Lab — Production-Ready ASP.NET Core Project");
        System.Console.WriteLine("================================================================");

        System.Console.WriteLine("The capstone Web project includes:");
        System.Console.WriteLine("  • Layered folders: Controllers, Services, Models, Middleware, Auth");
        System.Console.WriteLine("  • Structured configuration (appsettings + environment)");
        System.Console.WriteLine("  • Global exception handling middleware");
        System.Console.WriteLine("  • Security headers middleware");
        System.Console.WriteLine("  • Swagger/OpenAPI with JWT security scheme");
        System.Console.WriteLine("  • HSTS for non-development environments");
        System.Console.WriteLine();
        System.Console.WriteLine("Run the production-ready API:");
        System.Console.WriteLine("  cd Day2/AdvancedAspNetTraining/AdvancedAspNetTraining.Web");
        System.Console.WriteLine("  dotnet run --launch-profile CapstoneApi");
        System.Console.WriteLine();
        System.Console.WriteLine("Verify:");
        System.Console.WriteLine("  1. https://localhost:7150/swagger");
        System.Console.WriteLine("  2. POST /api/auth/login -> copy token");
        System.Console.WriteLine("  3. GET /api/v1/orders with Authorization: Bearer {token}");

        return Task.CompletedTask;
    }
}
