using AdvancedAsyncTraining.Console.Modules.EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;

namespace AdvancedAsyncTraining.Console.Modules.EntityFrameworkCore;

public static class Exercise28_SplitQueries
{
    public static async Task RunAsync()
    {
        System.Console.WriteLine("Exercise 28: Split Queries");

        await using var db = new AppDbContext();
        await DbSeeder.SeedAsync(db);

        var customers = await db.Customers
            .Include(x => x.Orders)
            .ThenInclude(x => x.Items)
            .AsSplitQuery()
            .AsNoTracking()
            .ToListAsync();

        System.Console.WriteLine($"Customers loaded: {customers.Count}");
    }
}
