namespace AdvancedProductionTraining.Console.Modules.SecurityTesting;

public static class Exercise30_SecurityTestLab
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 30: Lab — API Security Testing");
        System.Console.WriteLine("=========================================");
        System.Console.WriteLine("1. Start AdvancedProductionTraining.Web");
        System.Console.WriteLine("2. POST invalid JSON to /api/orders — expect 400");
        System.Console.WriteLine("3. Flood endpoints — verify 429 after rate limit");
        System.Console.WriteLine("4. Run OWASP ZAP or Postman security collection");
        System.Console.WriteLine("5. Document findings: severity, reproduction, remediation");

        return Task.CompletedTask;
    }
}
