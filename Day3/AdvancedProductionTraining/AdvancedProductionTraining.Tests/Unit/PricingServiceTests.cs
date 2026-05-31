using AdvancedProductionTraining.Core.Services;
using FluentAssertions;

namespace AdvancedProductionTraining.Tests.Unit;

public sealed class PricingServiceTests
{
    private readonly PricingService _sut = new();

    [Fact]
    public void CalculateDiscount_GoldTier_ReturnsFifteenPercent()
    {
        // Arrange
        const decimal total = 1000m;

        // Act
        var discount = _sut.CalculateDiscount(total, "GOLD");

        // Assert
        discount.Should().Be(150m);
    }

    [Theory]
    [InlineData("SILVER", 100)]
    [InlineData("BRONZE", 50)]
    [InlineData("STANDARD", 0)]
    public void CalculateDiscount_VariousTiers_ReturnsExpectedDiscount(string tier, double expected)
    {
        var discount = _sut.CalculateDiscount(1000m, tier);
        discount.Should().Be((decimal)expected);
    }
}
