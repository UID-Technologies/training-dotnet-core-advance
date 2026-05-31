namespace AdvancedProductionTraining.Console.Modules.SecurityTesting;

public static class Exercise25_AuthenticationAttacks
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 25: Authentication Attacks");
        System.Console.WriteLine("---------------------------------");
        System.Console.WriteLine("Test for: credential stuffing, brute force, weak tokens, missing expiration.");
        System.Console.WriteLine("Mitigations: rate limiting, lockout, MFA, short-lived JWT, refresh token rotation.");
        System.Console.WriteLine("Day 2 capstone JWT — verify expired/invalid tokens return 401.");

        return Task.CompletedTask;
    }
}
