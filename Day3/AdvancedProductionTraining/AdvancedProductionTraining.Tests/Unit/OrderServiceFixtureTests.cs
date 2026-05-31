using AdvancedProductionTraining.Core.Abstractions;
using AdvancedProductionTraining.Core.Models;
using AdvancedProductionTraining.Core.Services;
using FluentAssertions;
using Moq;

namespace AdvancedProductionTraining.Tests.Unit;

public sealed class OrderServiceFixtureTests : IClassFixture<OrderServiceFixture>
{
    private readonly OrderServiceFixture _fixture;

    public OrderServiceFixtureTests(OrderServiceFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task CancelOrderAsync_ExistingDraftOrder_ReturnsTrue()
    {
        _fixture.Repository.Setup(x => x.GetByIdAsync(1, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Order { Id = 1, Status = "Submitted" });
        _fixture.Repository.Setup(x => x.UpdateStatusAsync(1, "Cancelled", It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        var result = await _fixture.Sut.CancelOrderAsync(1);

        result.Should().BeTrue();
    }
}

public sealed class OrderServiceFixture
{
    public Mock<IOrderRepository> Repository { get; } = new();
    public OrderService Sut { get; }

    public OrderServiceFixture()
    {
        Sut = new OrderService(Repository.Object, new PricingService());
    }
}
