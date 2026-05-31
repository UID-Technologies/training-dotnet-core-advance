using AdvancedProductionTraining.Core.Abstractions;
using AdvancedProductionTraining.Core.Models;
using AdvancedProductionTraining.Core.Services;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace AdvancedProductionTraining.Tests.Unit;

public sealed class OrderServiceDiTests
{
    [Fact]
    public void ResolveOrderService_FromServiceProvider_Succeeds()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();
        services.AddSingleton<IPricingService, PricingService>();
        services.AddScoped<OrderService>();

        var provider = services.BuildServiceProvider();

        using var scope = provider.CreateScope();
        var sut = scope.ServiceProvider.GetRequiredService<OrderService>();

        sut.Should().NotBeNull();
    }

    private sealed class InMemoryOrderRepository : IOrderRepository
    {
        public Task<Order> AddAsync(Order order, CancellationToken cancellationToken = default)
        {
            order.Id = 1;
            return Task.FromResult(order);
        }

        public Task<IReadOnlyList<Order>> GetAllAsync(CancellationToken cancellationToken = default) =>
            Task.FromResult<IReadOnlyList<Order>>([]);

        public Task<Order?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
            Task.FromResult<Order?>(null);

        public Task<bool> UpdateStatusAsync(int id, string status, CancellationToken cancellationToken = default) =>
            Task.FromResult(true);
    }
}
