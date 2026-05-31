using AdvancedProductionTraining.Core.Abstractions;
using AdvancedProductionTraining.Core.Models;

namespace AdvancedProductionTraining.Core.Services;

public sealed class OrderService
{
    private readonly IOrderRepository _repository;
    private readonly IPricingService _pricing;

    public OrderService(IOrderRepository repository, IPricingService pricing)
    {
        _repository = repository;
        _pricing = pricing;
    }

    public async Task<Order> PlaceOrderAsync(string customerName, decimal total, string customerTier, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(customerName))
        {
            throw new ArgumentException("Customer name is required.", nameof(customerName));
        }

        if (total <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(total), "Total must be greater than zero.");
        }

        var discount = _pricing.CalculateDiscount(total, customerTier);
        var finalTotal = total - discount;

        var order = new Order
        {
            CustomerName = customerName.Trim(),
            Total = finalTotal,
            Status = "Submitted"
        };

        return await _repository.AddAsync(order, cancellationToken);
    }

    public async Task<bool> CancelOrderAsync(int orderId, CancellationToken cancellationToken = default)
    {
        var order = await _repository.GetByIdAsync(orderId, cancellationToken);
        if (order is null)
        {
            return false;
        }

        if (order.Status is "Shipped" or "Delivered")
        {
            throw new InvalidOperationException($"Cannot cancel order in status '{order.Status}'.");
        }

        return await _repository.UpdateStatusAsync(orderId, "Cancelled", cancellationToken);
    }
}
