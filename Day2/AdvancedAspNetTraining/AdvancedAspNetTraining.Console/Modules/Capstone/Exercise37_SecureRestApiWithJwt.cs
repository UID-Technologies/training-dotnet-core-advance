namespace AdvancedAspNetTraining.Console.Modules.Capstone;

public static class Exercise37_SecureRestApiWithJwt
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 37: Hands-on Lab — Secure REST API with JWT");
        System.Console.WriteLine("===================================================");

        System.Console.WriteLine("Step 1 — Start API:");
        System.Console.WriteLine("  dotnet run --project AdvancedAspNetTraining.Web --launch-profile CapstoneApi");
        System.Console.WriteLine();
        System.Console.WriteLine("Step 2 — Authenticate:");
        System.Console.WriteLine(@"  POST https://localhost:7150/api/auth/login
  Body: { ""username"": ""writer"", ""password"": ""Writer@123"" }");
        System.Console.WriteLine();
        System.Console.WriteLine("Step 3 — Call protected endpoints:");
        System.Console.WriteLine("  GET  /api/v1/orders        (requires orders:read)");
        System.Console.WriteLine("  POST /api/v1/orders        (requires orders:write)");
        System.Console.WriteLine(@"  Body: { ""customerName"": ""New Corp"", ""total"": 500 }");
        System.Console.WriteLine("  DELETE /api/v1/orders/1    (requires Admin role — use admin user)");
        System.Console.WriteLine();
        System.Console.WriteLine("Step 4 — Observe authorization failures:");
        System.Console.WriteLine("  Login as reader and attempt POST or DELETE — expect 403 Forbidden.");
        System.Console.WriteLine();
        System.Console.WriteLine("Step 5 — Review code:");
        System.Console.WriteLine("  Auth/JwtTokenService.cs, Controllers/OrdersController.cs, Program.cs");

        return Task.CompletedTask;
    }
}
