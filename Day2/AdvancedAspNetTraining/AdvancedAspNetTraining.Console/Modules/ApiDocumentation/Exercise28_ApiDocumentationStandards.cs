namespace AdvancedAspNetTraining.Console.Modules.ApiDocumentation;

public static class Exercise28_ApiDocumentationStandards
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 28: API Documentation Standards");
        System.Console.WriteLine("--------------------------------------");

        System.Console.WriteLine("OpenAPI should document:");
        System.Console.WriteLine("  • Resource paths and HTTP verbs");
        System.Console.WriteLine("  • Request/response schemas with examples");
        System.Console.WriteLine("  • Authentication requirements (Bearer JWT)");
        System.Console.WriteLine("  • Error responses (400, 401, 403, 404, 500)");
        System.Console.WriteLine("  • Pagination, filtering, sorting conventions");
        System.Console.WriteLine();
        System.Console.WriteLine("Enterprise standards:");
        System.Console.WriteLine("  • Version every breaking change");
        System.Console.WriteLine("  • Publish swagger.json in CI for API consumers");
        System.Console.WriteLine("  • Use consistent ProblemDetails (RFC 7807) for errors");
        System.Console.WriteLine();
        System.Console.WriteLine("Capstone Web project includes JWT security definitions in Swagger.");

        return Task.CompletedTask;
    }
}
