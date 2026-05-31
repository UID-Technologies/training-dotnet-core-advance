namespace AdvancedProductionTraining.Console.Modules.SecurityTesting;

public static class Exercise24_OwaspTop10
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 24: OWASP API Security Top 10 (Overview)");
        System.Console.WriteLine("------------------------------------------------");
        var items = new[]
        {
            "Broken Object Level Authorization",
            "Broken Authentication",
            "Broken Object Property Level Authorization",
            "Unrestricted Resource Consumption",
            "Broken Function Level Authorization",
            "Unrestricted Access to Sensitive Business Flows",
            "Server Side Request Forgery",
            "Security Misconfiguration",
            "Improper Inventory Management",
            "Unsafe Consumption of APIs"
        };
        foreach (var item in items)
        {
            System.Console.WriteLine($"  • {item}");
        }

        return Task.CompletedTask;
    }
}
