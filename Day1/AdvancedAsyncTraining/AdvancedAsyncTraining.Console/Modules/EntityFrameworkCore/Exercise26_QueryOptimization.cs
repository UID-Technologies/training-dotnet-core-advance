using System.Diagnostics;
using AdvancedAsyncTraining.Console.Modules.EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;

namespace AdvancedAsyncTraining.Console.Modules.EntityFrameworkCore;

public static class Exercise26_QueryOptimization
{
    public static async Task RunAsync()
    {
        System.Console.WriteLine("Exercise 26: Tracking vs NoTracking");

        await using var db = new AppDbContext();
        await DbSeeder.SeedAsync(db);

        var stopwatch = Stopwatch.StartNew();

        var tracked = await db.Customers.ToListAsync();

        stopwatch.Stop();

        System.Console.WriteLine($"Tracked Query: {stopwatch.ElapsedMilliseconds} ms, Rows: {tracked.Count}");

        stopwatch.Restart();

        var notTracked = await db.Customers
            .AsNoTracking()
            .ToListAsync();

        stopwatch.Stop();

        System.Console.WriteLine($"NoTracking Query: {stopwatch.ElapsedMilliseconds} ms, Rows: {notTracked.Count}");
    }
}
