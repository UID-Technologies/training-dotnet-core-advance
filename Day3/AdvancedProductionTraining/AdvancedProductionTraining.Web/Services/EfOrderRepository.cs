using AdvancedProductionTraining.Core.Abstractions;
using AdvancedProductionTraining.Core.Models;
using AdvancedProductionTraining.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace AdvancedProductionTraining.Web.Services;

public sealed class EfOrderRepository : IOrderRepository
{
    private readonly OrdersDbContext _db;

    public EfOrderRepository(OrdersDbContext db)
    {
        _db = db;
    }

    public async Task<Order?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        await _db.Orders.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<IReadOnlyList<Order>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _db.Orders.AsNoTracking().ToListAsync(cancellationToken);

    public async Task<Order> AddAsync(Order order, CancellationToken cancellationToken = default)
    {
        _db.Orders.Add(order);
        await _db.SaveChangesAsync(cancellationToken);
        return order;
    }

    public async Task<bool> UpdateStatusAsync(int id, string status, CancellationToken cancellationToken = default)
    {
        var order = await _db.Orders.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (order is null)
        {
            return false;
        }

        order.Status = status;
        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}
