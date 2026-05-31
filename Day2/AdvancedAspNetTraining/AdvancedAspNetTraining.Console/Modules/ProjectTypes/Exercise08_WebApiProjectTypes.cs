namespace AdvancedAspNetTraining.Console.Modules.ProjectTypes;

public static class Exercise08_WebApiProjectTypes
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 8: Web API Project Structure");
        System.Console.WriteLine("-------------------------------------");

        System.Console.WriteLine("Enterprise Web API layout (see AdvancedAspNetTraining.Web):");
        System.Console.WriteLine("""
          AdvancedAspNetTraining.Web/
            Program.cs           -> composition root
            appsettings.json     -> configuration
            Controllers/         -> API endpoints
            Models/              -> DTOs and resources
            Services/            -> business/data access
            Middleware/          -> cross-cutting pipeline
            Auth/                -> JWT and security
          """);

        System.Console.WriteLine("Run capstone API:");
        System.Console.WriteLine("  cd AdvancedAspNetTraining.Web");
        System.Console.WriteLine("  dotnet run --launch-profile CapstoneApi");

        return Task.CompletedTask;
    }
}
