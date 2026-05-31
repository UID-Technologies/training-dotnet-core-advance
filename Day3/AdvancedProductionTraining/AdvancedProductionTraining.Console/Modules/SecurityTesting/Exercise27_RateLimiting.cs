namespace AdvancedProductionTraining.Console.Modules.SecurityTesting;

public static class Exercise27_RateLimiting
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 27: Rate Limiting");
        System.Console.WriteLine("--------------------------");
        System.Console.WriteLine("Web API uses ASP.NET Core rate limiter (30 requests/minute per IP).");
        System.Console.WriteLine("Test: send 35 rapid requests — expect HTTP 429 Too Many Requests.");
        System.Console.WriteLine();
        System.Console.WriteLine("Configured in Program.cs: AddRateLimiter + RequireRateLimiting(\"fixed\")");

        return Task.CompletedTask;
    }
}
