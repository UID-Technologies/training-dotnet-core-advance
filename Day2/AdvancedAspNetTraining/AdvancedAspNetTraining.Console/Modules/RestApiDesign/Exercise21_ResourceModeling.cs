namespace AdvancedAspNetTraining.Console.Modules.RestApiDesign;

public static class Exercise21_ResourceModeling
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 21: Resource Modeling");
        System.Console.WriteLine("------------------------------");

        System.Console.WriteLine("Model resources as nouns, not verbs:");
        System.Console.WriteLine("  Good: POST /api/v1/orders");
        System.Console.WriteLine("  Avoid: POST /api/v1/createOrder");
        System.Console.WriteLine();
        System.Console.WriteLine("Nested resources for relationships:");
        System.Console.WriteLine("  GET /api/v1/customers/10/orders");
        System.Console.WriteLine("  GET /api/v1/orders/42/items");
        System.Console.WriteLine();
        System.Console.WriteLine("DTOs vs domain entities:");
        System.Console.WriteLine("  CreateOrderRequest -> maps to Order entity");
        System.Console.WriteLine("  OrderResource -> returned to clients (no internal fields)");
        System.Console.WriteLine();
        System.Console.WriteLine("See AdvancedAspNetTraining.Web/Models/OrderResource.cs");

        return Task.CompletedTask;
    }
}
