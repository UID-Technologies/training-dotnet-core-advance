namespace AdvancedAspNetTraining.Console.Modules.AspNetCoreRuntime;

public static class Exercise04_IisIntegration
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 4: IIS Integration");
        System.Console.WriteLine("-----------------------------");

        System.Console.WriteLine("IIS acts as a reverse proxy in front of Kestrel.");
        System.Console.WriteLine();
        System.Console.WriteLine("Key components:");
        System.Console.WriteLine("  • ASP.NET Core Module (ANCM) forwards requests to Kestrel");
        System.Console.WriteLine("  • web.config defines processPath=dotnet and arguments");
        System.Console.WriteLine("  • In-process hosting runs inside IIS worker process");
        System.Console.WriteLine("  • Out-of-process hosting runs Kestrel as separate process");
        System.Console.WriteLine();
        System.Console.WriteLine("Sample web.config excerpt:");
        System.Console.WriteLine("""
          <aspNetCore processPath="dotnet"
                      arguments=".\AdvancedAspNetTraining.Web.dll"
                      hostingModel="inprocess" />
          """);
        System.Console.WriteLine();
        System.Console.WriteLine("This lab runs Kestrel directly (`dotnet run`). Deploy to IIS for production Windows hosting.");

        return Task.CompletedTask;
    }
}
