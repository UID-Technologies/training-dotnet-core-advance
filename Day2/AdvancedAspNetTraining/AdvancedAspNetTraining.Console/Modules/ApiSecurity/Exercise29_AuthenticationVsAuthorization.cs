namespace AdvancedAspNetTraining.Console.Modules.ApiSecurity;

public static class Exercise29_AuthenticationVsAuthorization
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 29: Authentication vs Authorization");
        System.Console.WriteLine("--------------------------------------------");

        System.Console.WriteLine("Authentication — WHO are you?");
        System.Console.WriteLine("  Validates credentials or tokens (JWT, API key, certificate)");
        System.Console.WriteLine();
        System.Console.WriteLine("Authorization — WHAT can you do?");
        System.Console.WriteLine("  Checks roles, claims, or policies after authentication");
        System.Console.WriteLine();
        System.Console.WriteLine("Pipeline order:");
        System.Console.WriteLine("  UseAuthentication() -> UseAuthorization() -> [Authorize] endpoints");
        System.Console.WriteLine();
        System.Console.WriteLine("Demo users in capstone API:");
        System.Console.WriteLine("  admin / Admin@123   -> roles: Admin, permissions: orders:read, orders:write");
        System.Console.WriteLine("  reader / Reader@123 -> orders:read only");
        System.Console.WriteLine("  writer / Writer@123 -> orders:read, orders:write");

        return Task.CompletedTask;
    }
}
