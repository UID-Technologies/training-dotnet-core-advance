namespace AdvancedAspNetTraining.Console.Modules.ApiSecurityBestPractices;

public static class Exercise35_SensitiveDataProtection
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 35: Protecting Sensitive Data");
        System.Console.WriteLine("-------------------------------------");

        System.Console.WriteLine("Never log secrets, passwords, or full JWT tokens.");
        System.Console.WriteLine("Store secrets in Azure Key Vault, User Secrets (dev), or environment variables.");
        System.Console.WriteLine();
        System.Console.WriteLine("API responses:");
        System.Console.WriteLine("  • Return DTOs without internal IDs or PII when not needed");
        System.Console.WriteLine("  • Use HTTPS everywhere (HSTS in production)");
        System.Console.WriteLine();
        System.Console.WriteLine("Data protection API for cookies/tokens at rest:");
        System.Console.WriteLine("  services.AddDataProtection().PersistKeysTo...();");
        System.Console.WriteLine();
        System.Console.WriteLine("Training JWT key in appsettings.json is for lab only — rotate in production.");

        return Task.CompletedTask;
    }
}
