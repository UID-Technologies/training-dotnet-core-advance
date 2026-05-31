using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AdvancedAspNetTraining.Console.Modules.DependencyInjection;

public static class Exercise15_LifetimesComparison
{
    public static async Task RunAsync()
    {
        System.Console.WriteLine("Exercise 15: Scoped vs Singleton vs Transient");
        System.Console.WriteLine("---------------------------------------------");

        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<SingletonService>();
                services.AddScoped<ScopedService>();
                services.AddTransient<TransientService>();
            })
            .Build();

        await host.StartAsync();

        var root = host.Services;

        var singletonA = root.GetRequiredService<SingletonService>();
        var singletonB = root.GetRequiredService<SingletonService>();
        System.Console.WriteLine($"Singleton same instance: {ReferenceEquals(singletonA, singletonB)} (Id {singletonA.Id} vs {singletonB.Id})");

        using (var scope1 = root.CreateScope())
        {
            var scopedA = scope1.ServiceProvider.GetRequiredService<ScopedService>();
            var scopedB = scope1.ServiceProvider.GetRequiredService<ScopedService>();
            System.Console.WriteLine($"Scoped same within scope: {ReferenceEquals(scopedA, scopedB)} (Id {scopedA.Id})");
        }

        using (var scope2 = root.CreateScope())
        {
            var scopedC = scope2.ServiceProvider.GetRequiredService<ScopedService>();
            System.Console.WriteLine($"Scoped new scope new instance: Id {scopedC.Id}");
        }

        using (var scope3 = root.CreateScope())
        {
            var transA = scope3.ServiceProvider.GetRequiredService<TransientService>();
            var transB = scope3.ServiceProvider.GetRequiredService<TransientService>();
            System.Console.WriteLine($"Transient different each resolve: {!ReferenceEquals(transA, transB)} ({transA.Id} vs {transB.Id})");
        }

        await host.StopAsync();
    }

    public sealed class SingletonService
    {
        public Guid Id { get; } = Guid.NewGuid();
    }

    public sealed class ScopedService
    {
        public Guid Id { get; } = Guid.NewGuid();
    }

    public sealed class TransientService
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
