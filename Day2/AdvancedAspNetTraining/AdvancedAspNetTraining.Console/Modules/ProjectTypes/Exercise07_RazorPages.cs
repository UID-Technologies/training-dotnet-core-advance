namespace AdvancedAspNetTraining.Console.Modules.ProjectTypes;

public static class Exercise07_RazorPages
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 7: Razor Pages");
        System.Console.WriteLine("-----------------------");

        System.Console.WriteLine("Razor Pages map URLs to PageModel classes (page-focused MVC):");
        System.Console.WriteLine("  Pages/Orders/Index.cshtml");
        System.Console.WriteLine("  Pages/Orders/Index.cshtml.cs  (PageModel with OnGet, OnPost)");
        System.Console.WriteLine();
        System.Console.WriteLine("Benefits:");
        System.Console.WriteLine("  • Co-location of UI and handler");
        System.Console.WriteLine("  • Simpler than full MVC for CRUD-style pages");
        System.Console.WriteLine();
        System.Console.WriteLine("Create with: dotnet new webapp");
        System.Console.WriteLine("This training focuses on APIs; Razor Pages are ideal for internal admin portals.");

        return Task.CompletedTask;
    }
}
