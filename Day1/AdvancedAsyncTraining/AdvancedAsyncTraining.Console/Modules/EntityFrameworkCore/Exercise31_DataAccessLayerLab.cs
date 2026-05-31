using AdvancedAsyncTraining.Console.Modules.EntityFrameworkCore.Data;
using AdvancedAsyncTraining.Console.Modules.EntityFrameworkCore.EfCoreModels;
using Microsoft.EntityFrameworkCore;

namespace AdvancedAsyncTraining.Console.Modules.EntityFrameworkCore;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task SaveChangesAsync();
}

public sealed class EfRepository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _db;

    public EfRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _db.Set<T>().FindAsync(id);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _db.Set<T>()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _db.Set<T>().AddAsync(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }
}

public static class Exercise31_DataAccessLayerLab
{
    public static async Task RunAsync()
    {
        System.Console.WriteLine("Exercise 31: Data Access Layer using EF Core");

        await using var db = new AppDbContext();
        await DbSeeder.SeedAsync(db);

        IRepository<Customer> customerRepository = new EfRepository<Customer>(db);

        var customer = new Customer
        {
            FullName = "Enterprise Customer"
        };

        await customerRepository.AddAsync(customer);
        await customerRepository.SaveChangesAsync();

        var customers = await customerRepository.GetAllAsync();

        foreach (var item in customers.Take(10))
        {
            System.Console.WriteLine($"{item.Id} - {item.FullName}");
        }
    }
}
