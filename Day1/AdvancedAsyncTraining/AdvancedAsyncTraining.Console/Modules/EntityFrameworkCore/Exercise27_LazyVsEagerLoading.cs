using AdvancedAsyncTraining.Console.Modules.EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;

namespace AdvancedAsyncTraining.Console.Modules.EntityFrameworkCore;

public static class Exercise27_LazyVsEagerLoading
{
    public static async Task RunAsync()
    {
        System.Console.WriteLine("Exercise 27: Lazy Loading vs Eager Loading");

        await using var db = new AppDbContext();
        await DbSeeder.SeedAsync(db);

        var customers = await db.Customers
            .Include(x => x.Orders)
            .ThenInclude(x => x.Items)
            .AsNoTracking()
            .Take(5)
            .ToListAsync();

        foreach (var customer in customers)
        {
            System.Console.WriteLine($"{customer.FullName} - Orders: {customer.Orders.Count}");
        }
    }
}
