using AdvancedAsyncTraining.Console.Modules.EntityFrameworkCore.Data;
using AdvancedAsyncTraining.Console.Modules.EntityFrameworkCore.EfCoreModels;
using Microsoft.EntityFrameworkCore;

namespace AdvancedAsyncTraining.Console.Modules.EntityFrameworkCore;

public static class Exercise29_CompiledQueries
{
    private static readonly Func<AppDbContext, int, IAsyncEnumerable<Customer>> GetCustomerById =
        EF.CompileAsyncQuery(
            (AppDbContext db, int id) =>
                db.Customers.AsNoTracking().Where(x => x.Id == id));

    public static async Task RunAsync()
    {
        System.Console.WriteLine("Exercise 29: Compiled Queries");

        await using var db = new AppDbContext();
        await DbSeeder.SeedAsync(db);

        Customer? customer = null;
        await foreach (var item in GetCustomerById(db, 1))
        {
            customer = item;
            break;
        }

        System.Console.WriteLine(customer?.FullName ?? "Customer not found");
    }
}
