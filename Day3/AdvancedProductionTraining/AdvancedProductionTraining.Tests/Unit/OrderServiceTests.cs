using AdvancedProductionTraining.Core.Abstractions;
using AdvancedProductionTraining.Core.Models;
using AdvancedProductionTraining.Core.Services;
using FluentAssertions;
using Moq;

namespace AdvancedProductionTraining.Tests.Unit;

public sealed class OrderServiceTests
{
    [Fact]
    public async Task PlaceOrderAsync_ValidRequest_PersistsOrderWithDiscount()
    {
        // Arrange
        var repository = new Mock<IOrderRepository>();
        var pricing = new Mock<IPricingService>();
        pricing.Setup(x => x.CalculateDiscount(1000m, "GOLD")).Returns(150m);

        repository.Setup(x => x.AddAsync(It.IsAny<Order>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Order o, CancellationToken _) =>
            {
                o.Id = 42;
                return o;
            });

        var sut = new OrderService(repository.Object, pricing.Object);

        // Act
        var result = await sut.PlaceOrderAsync("Contoso", 1000m, "GOLD");

        // Assert
        result.Id.Should().Be(42);
        result.Total.Should().Be(850m);
        result.Status.Should().Be("Submitted");
        repository.Verify(x => x.AddAsync(It.Is<Order>(o => o.CustomerName == "Contoso"), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task PlaceOrderAsync_EmptyCustomer_ThrowsArgumentException()
    {
        var sut = new OrderService(Mock.Of<IOrderRepository>(), Mock.Of<IPricingService>());

        var act = () => sut.PlaceOrderAsync("  ", 100m, "BRONZE");

        await act.Should().ThrowAsync<ArgumentException>();
    }
}
