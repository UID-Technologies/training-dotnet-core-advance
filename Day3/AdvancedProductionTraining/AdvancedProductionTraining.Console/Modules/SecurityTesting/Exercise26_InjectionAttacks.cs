namespace AdvancedProductionTraining.Console.Modules.SecurityTesting;

public static class Exercise26_InjectionAttacks
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 26: Injection Attacks");
        System.Console.WriteLine("----------------------------");
        System.Console.WriteLine("Test payloads in API inputs:");
        System.Console.WriteLine(@"  ' OR 1=1 --");
        System.Console.WriteLine(@"  <script>alert(1)</script>");
        System.Console.WriteLine("EF Core LINQ parameterizes queries — avoid raw SQL concatenation.");
        System.Console.WriteLine("Validate and encode outputs; use allow-lists for enums/tiers.");

        return Task.CompletedTask;
    }
}
