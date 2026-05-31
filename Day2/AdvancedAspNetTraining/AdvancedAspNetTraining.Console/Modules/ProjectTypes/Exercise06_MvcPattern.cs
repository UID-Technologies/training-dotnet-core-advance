namespace AdvancedAspNetTraining.Console.Modules.ProjectTypes;

public static class Exercise06_MvcPattern
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 6: MVC Pattern");
        System.Console.WriteLine("-----------------------");

        System.Console.WriteLine("MVC separates concerns for server-rendered applications:");
        System.Console.WriteLine("  Model      -> data + business rules (Order, Customer)");
        System.Console.WriteLine("  View       -> UI rendering (Razor .cshtml)");
        System.Console.WriteLine("  Controller -> coordinates HTTP requests");
        System.Console.WriteLine();
        System.Console.WriteLine("Typical flow:");
        System.Console.WriteLine("  GET /Orders/Details/5 -> OrdersController.Details(5) -> View(order)");
        System.Console.WriteLine();
        System.Console.WriteLine("When to choose MVC:");
        System.Console.WriteLine("  • Traditional web apps with HTML responses");
        System.Console.WriteLine("  • Server-side rendering and form posts");
        System.Console.WriteLine();
        System.Console.WriteLine("Enterprise APIs usually prefer Web API controllers or Minimal APIs.");
        System.Console.WriteLine("Capstone project in AdvancedAspNetTraining.Web uses API controllers.");

        return Task.CompletedTask;
    }
}
