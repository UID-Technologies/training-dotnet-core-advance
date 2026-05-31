using AdvancedAsyncTraining.Console.Modules.EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;

namespace AdvancedAsyncTraining.Console.Modules.EntityFrameworkCore;

public static class Exercise22_EFCoreArchitecture
{
    public static async Task RunAsync()
    {
        System.Console.WriteLine("Exercise 22: EF Core Architecture");

        await using var db = new AppDbContext();
        await DbSeeder.SeedAsync(db);

        System.Console.WriteLine($"DbContext created: {db.ContextId}");
        System.Console.WriteLine($"Provider: {db.Database.ProviderName}");

        var customers = await db.Customers.AsNoTracking().ToListAsync();

        System.Console.WriteLine($"Customers loaded: {customers.Count}");
    }
}
