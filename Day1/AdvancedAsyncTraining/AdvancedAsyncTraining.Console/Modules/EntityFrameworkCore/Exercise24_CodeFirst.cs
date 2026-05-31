namespace AdvancedAsyncTraining.Console.Modules.EntityFrameworkCore;

public static class Exercise24_CodeFirst
{
    public static Task RunAsync()
    {
        System.Console.WriteLine("Exercise 24: Code First Approach");
        System.Console.WriteLine("Run these commands in terminal:");
        System.Console.WriteLine("dotnet ef migrations add InitialCreate");
        System.Console.WriteLine("dotnet ef database update");
        System.Console.WriteLine("Use this approach when model classes and migration history are application-owned.");

        return Task.CompletedTask;
    }
}
