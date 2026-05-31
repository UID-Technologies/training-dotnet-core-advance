using AdvancedAsyncTraining.Console.Modules.EntityFrameworkCore.EfCoreModels;
using Microsoft.EntityFrameworkCore;

namespace AdvancedAsyncTraining.Console.Modules.EntityFrameworkCore.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext db)
    {
        await db.Database.EnsureCreatedAsync();

        if (await db.Customers.AnyAsync())
        {
            return;
        }

        var products = Enumerable.Range(1, 30)
            .Select(i => new Product
            {
                Name = $"Product-{i:000}",
                Price = Random.Shared.Next(50, 1500)
            })
            .ToList();

        await db.Products.AddRangeAsync(products);

        var customers = Enumerable.Range(1, 50)
            .Select(i => new Customer
            {
                FullName = $"Customer {i:000}"
            })
            .ToList();

        await db.Customers.AddRangeAsync(customers);
        await db.SaveChangesAsync();

        var orders = new List<Order>();
        var orderItems = new List<OrderItem>();

        foreach (var customer in customers)
        {
            var customerOrders = Enumerable.Range(1, Random.Shared.Next(2, 6))
                .Select(_ => new Order
                {
                    CustomerId = customer.Id,
                    OrderDate = DateTime.UtcNow.AddDays(-Random.Shared.Next(1, 180)),
                    TotalAmount = 0m
                })
                .ToList();

            orders.AddRange(customerOrders);
        }

        await db.Orders.AddRangeAsync(orders);
        await db.SaveChangesAsync();

        foreach (var order in orders)
        {
            var items = Enumerable.Range(1, Random.Shared.Next(1, 5))
                .Select(_ =>
                {
                    var product = products[Random.Shared.Next(products.Count)];
                    var quantity = Random.Shared.Next(1, 5);

                    return new OrderItem
                    {
                        OrderId = order.Id,
                        ProductId = product.Id,
                        Quantity = quantity
                    };
                })
                .ToList();

            orderItems.AddRange(items);

            order.TotalAmount = items.Sum(i => i.Quantity * products.First(p => p.Id == i.ProductId).Price);
        }

        await db.OrderItems.AddRangeAsync(orderItems);
        await db.SaveChangesAsync();
    }
}
