using AdvancedProductionTraining.Core.Abstractions;

namespace AdvancedProductionTraining.Core.Services;

public sealed class PricingService : IPricingService
{
    public decimal CalculateDiscount(decimal total, string customerTier) =>
        customerTier.ToUpperInvariant() switch
        {
            "GOLD" => total * 0.15m,
            "SILVER" => total * 0.10m,
            "BRONZE" => total * 0.05m,
            _ => 0m
        };
}
