namespace AdvancedProductionTraining.Console.Modules.Observability;

public static class Exercise32_Serilog
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 32: Serilog");
        System.Console.WriteLine("--------------------");
        System.Console.WriteLine("Web project uses Serilog.AspNetCore:");
        System.Console.WriteLine("  builder.Host.UseSerilog(...)");
        System.Console.WriteLine("  app.UseSerilogRequestLogging()");
        System.Console.WriteLine();
        System.Console.WriteLine("Run API and observe structured request logs in console.");

        return Task.CompletedTask;
    }
}
