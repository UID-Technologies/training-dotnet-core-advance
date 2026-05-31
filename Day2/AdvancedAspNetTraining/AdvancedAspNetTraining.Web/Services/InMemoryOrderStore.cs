using AdvancedAspNetTraining.Web.Models;

namespace AdvancedAspNetTraining.Web.Services;

public sealed class InMemoryOrderStore : IOrderStore
{
    private readonly List<OrderResource> _orders =
    [
        new() { Id = 1, CustomerName = "Contoso Ltd", Total = 1200m, Status = "Submitted", CreatedAt = DateTime.UtcNow.AddDays(-2) },
        new() { Id = 2, CustomerName = "Fabrikam Inc", Total = 450m, Status = "Shipped", CreatedAt = DateTime.UtcNow.AddDays(-1) }
    ];

    private int _nextId = 3;

    public Task<IReadOnlyList<OrderResource>> GetAllAsync() =>
        Task.FromResult<IReadOnlyList<OrderResource>>(_orders.ToList());

    public Task<OrderResource?> GetByIdAsync(int id) =>
        Task.FromResult(_orders.FirstOrDefault(x => x.Id == id));

    public Task<OrderResource> CreateAsync(CreateOrderRequest request)
    {
        var order = new OrderResource
        {
            Id = _nextId++,
            CustomerName = request.CustomerName,
            Total = request.Total,
            Status = "Submitted",
            CreatedAt = DateTime.UtcNow
        };

        _orders.Add(order);
        return Task.FromResult(order);
    }

    public Task<OrderResource?> UpdateAsync(int id, UpdateOrderRequest request)
    {
        var order = _orders.FirstOrDefault(x => x.Id == id);
        if (order is null)
        {
            return Task.FromResult<OrderResource?>(null);
        }

        order.Status = request.Status;
        return Task.FromResult<OrderResource?>(order);
    }

    public Task<bool> DeleteAsync(int id)
    {
        var order = _orders.FirstOrDefault(x => x.Id == id);
        if (order is null)
        {
            return Task.FromResult(false);
        }

        _orders.Remove(order);
        return Task.FromResult(true);
    }
}
