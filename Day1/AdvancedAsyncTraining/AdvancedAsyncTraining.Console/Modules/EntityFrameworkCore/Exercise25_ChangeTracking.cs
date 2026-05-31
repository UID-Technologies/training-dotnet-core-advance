using AdvancedAsyncTraining.Console.Modules.EntityFrameworkCore.Data;
using AdvancedAsyncTraining.Console.Modules.EntityFrameworkCore.EfCoreModels;
using Microsoft.EntityFrameworkCore;

namespace AdvancedAsyncTraining.Console.Modules.EntityFrameworkCore;

public static class Exercise25_ChangeTracking
{
    public static async Task RunAsync()
    {
        System.Console.WriteLine("Exercise 25: Change Tracking");

        await using var db = new AppDbContext();
        await DbSeeder.SeedAsync(db);

        var customer = new Customer
        {
            FullName = "Varun Gupta"
        };

        db.Customers.Add(customer);

        System.Console.WriteLine($"After Add: {db.Entry(customer).State}");

        await db.SaveChangesAsync();

        System.Console.WriteLine($"After Save: {db.Entry(customer).State}");

        customer.FullName = "Varun G.";

        System.Console.WriteLine($"After Modify: {db.Entry(customer).State}");

        await db.SaveChangesAsync();

        System.Console.WriteLine($"After Save Modify: {db.Entry(customer).State}");
    }
}
