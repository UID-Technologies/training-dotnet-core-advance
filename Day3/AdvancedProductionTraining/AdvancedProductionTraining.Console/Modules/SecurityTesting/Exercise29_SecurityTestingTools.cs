namespace AdvancedProductionTraining.Console.Modules.SecurityTesting;

public static class Exercise29_SecurityTestingTools
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 29: Security Testing Tools");
        System.Console.WriteLine("-----------------------------------");
        System.Console.WriteLine("  OWASP ZAP     — automated DAST scanning");
        System.Console.WriteLine("  Burp Suite    — manual proxy testing");
        System.Console.WriteLine("  Postman       — collections + security tests in CI");
        System.Console.WriteLine();
        System.Console.WriteLine("Run ZAP baseline against local API:");
        System.Console.WriteLine("  docker run -t owasp/zap2docker-stable zap-baseline.py -t http://localhost:5250");

        return Task.CompletedTask;
    }
}
