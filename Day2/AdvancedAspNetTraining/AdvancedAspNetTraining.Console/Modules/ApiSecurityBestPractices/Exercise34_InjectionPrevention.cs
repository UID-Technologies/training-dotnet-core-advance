namespace AdvancedAspNetTraining.Console.Modules.ApiSecurityBestPractices;

public static class Exercise34_InjectionPrevention
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 34: Preventing Injection Attacks");
        System.Console.WriteLine("-----------------------------------------");

        System.Console.WriteLine("SQL Injection — use parameterized queries / EF Core LINQ:");
        System.Console.WriteLine("  UNSAFE: $\"SELECT * FROM Orders WHERE Id = {userInput}\"");
        System.Console.WriteLine("  SAFE:   db.Orders.Where(o => o.Id == id).ToListAsync()");
        System.Console.WriteLine();
        System.Console.WriteLine("Command Injection — never pass user input to Process.Start shell.");
        System.Console.WriteLine();
        System.Console.WriteLine("LDAP/XML/Template injection — validate input, use allow-lists.");
        System.Console.WriteLine();
        System.Console.WriteLine("EF Core automatically parameterizes LINQ translations to SQL.");

        return Task.CompletedTask;
    }
}
