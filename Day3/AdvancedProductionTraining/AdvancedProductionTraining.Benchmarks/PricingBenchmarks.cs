using AdvancedProductionTraining.Core.Services;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace AdvancedProductionTraining.Benchmarks;

[MemoryDiagnoser]
public class PricingBenchmarks
{
    private readonly PricingService _pricing = new();

    [Benchmark(Baseline = true)]
    public decimal BronzeTier() => _pricing.CalculateDiscount(1000m, "BRONZE");

    [Benchmark]
    public decimal GoldTier() => _pricing.CalculateDiscount(1000m, "GOLD");

    [Benchmark]
    public decimal LargeOrderSilver() => _pricing.CalculateDiscount(10000m, "SILVER");
}

public static class Program
{
    public static void Main(string[] args) =>
        BenchmarkRunner.Run<PricingBenchmarks>();
}
