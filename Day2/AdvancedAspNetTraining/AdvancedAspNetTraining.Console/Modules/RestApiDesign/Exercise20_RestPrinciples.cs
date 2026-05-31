namespace AdvancedAspNetTraining.Console.Modules.RestApiDesign;

public static class Exercise20_RestPrinciples
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 20: REST Principles");
        System.Console.WriteLine("-----------------------------");

        var principles = new[]
        {
            "Client-Server — UI separated from data storage",
            "Stateless — each request contains all context needed",
            "Cacheable — responses declare cacheability",
            "Uniform Interface — resources identified by URIs, standard verbs",
            "Layered System — proxies, gateways, load balancers",
            "Code on Demand (optional) — scripts sent to client"
        };

        foreach (var principle in principles)
        {
            System.Console.WriteLine($"  • {principle}");
        }

        System.Console.WriteLine();
        System.Console.WriteLine("HTTP verbs mapping:");
        System.Console.WriteLine("  GET /api/v1/orders      -> list");
        System.Console.WriteLine("  GET /api/v1/orders/5    -> read");
        System.Console.WriteLine("  POST /api/v1/orders     -> create");
        System.Console.WriteLine("  PUT /api/v1/orders/5    -> replace/update");
        System.Console.WriteLine("  DELETE /api/v1/orders/5 -> remove");

        return Task.CompletedTask;
    }
}
