using AdvancedAspNetTraining.Web.Models;

namespace AdvancedAspNetTraining.Web.Services;

public interface IOrderStore
{
    Task<IReadOnlyList<OrderResource>> GetAllAsync();
    Task<OrderResource?> GetByIdAsync(int id);
    Task<OrderResource> CreateAsync(CreateOrderRequest request);
    Task<OrderResource?> UpdateAsync(int id, UpdateOrderRequest request);
    Task<bool> DeleteAsync(int id);
}
