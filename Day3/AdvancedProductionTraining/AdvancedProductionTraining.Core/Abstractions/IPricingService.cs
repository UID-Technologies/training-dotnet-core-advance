namespace AdvancedProductionTraining.Core.Abstractions;

public interface IPricingService
{
    decimal CalculateDiscount(decimal total, string customerTier);
}
