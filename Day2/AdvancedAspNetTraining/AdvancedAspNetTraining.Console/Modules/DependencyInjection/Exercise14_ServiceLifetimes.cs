namespace AdvancedAspNetTraining.Console.Modules.DependencyInjection;

public static class Exercise14_ServiceLifetimes
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 14: Service Lifetimes");
        System.Console.WriteLine("-------------------------------");

        var lifetimes = new[]
        {
            ("Transient", "New instance every time it is requested from the container."),
            ("Scoped", "One instance per scope (typically per HTTP request in web apps)."),
            ("Singleton", "One instance for the application lifetime.")
        };

        foreach (var (name, description) in lifetimes)
        {
            System.Console.WriteLine();
            System.Console.WriteLine($"  {name}");
            System.Console.WriteLine($"    {description}");
        }

        System.Console.WriteLine();
        System.Console.WriteLine("Registration examples:");
        System.Console.WriteLine("  services.AddTransient<IMailer, SmtpMailer>();");
        System.Console.WriteLine("  services.AddScoped<IOrderRepository, EfOrderRepository>();");
        System.Console.WriteLine("  services.AddSingleton<ICache, MemoryCache>();");
        System.Console.WriteLine();
        System.Console.WriteLine("Rule: never inject Scoped into Singleton (captive dependency).");

        return Task.CompletedTask;
    }
}
