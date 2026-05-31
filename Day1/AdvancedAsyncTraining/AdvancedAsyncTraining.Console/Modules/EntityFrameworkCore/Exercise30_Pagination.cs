using AdvancedAsyncTraining.Console.Modules.EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;

namespace AdvancedAsyncTraining.Console.Modules.EntityFrameworkCore;

public static class Exercise30_Pagination
{
    public static async Task RunAsync()
    {
        System.Console.WriteLine("Exercise 30: Pagination");

        const int pageNumber = 2;
        const int pageSize = 10;

        await using var db = new AppDbContext();
        await DbSeeder.SeedAsync(db);

        var customers = await db.Customers
            .AsNoTracking()
            .OrderBy(x => x.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        System.Console.WriteLine($"Page {pageNumber}, Size {pageSize}");

        foreach (var customer in customers)
        {
            System.Console.WriteLine($"{customer.Id} - {customer.FullName}");
        }
    }
}
