using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AdvancedAspNetTraining.Console.Modules.DependencyInjection;

public static class Exercise13_BuiltInDiContainer
{
    public static async Task RunAsync()
    {
        System.Console.WriteLine("Exercise 13: Built-in DI Container");
        System.Console.WriteLine("----------------------------------");

        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<IClock, SystemClock>();
                services.AddTransient<IOrderValidator, OrderValidator>();
                services.AddScoped<IOrderProcessor, OrderProcessor>();
            })
            .Build();

        await host.StartAsync();

        using var scope1 = host.Services.CreateScope();
        using var scope2 = host.Services.CreateScope();

        var processor1 = scope1.ServiceProvider.GetRequiredService<IOrderProcessor>();
        var processor2 = scope2.ServiceProvider.GetRequiredService<IOrderProcessor>();

        System.Console.WriteLine($"Scoped instance same in scope: {ReferenceEquals(processor1, processor1)}");
        System.Console.WriteLine($"Scoped instance different across scopes: {!ReferenceEquals(processor1, processor2)}");

        await processor1.ProcessAsync(101);

        await host.StopAsync();
    }

    public interface IClock
    {
        DateTime UtcNow { get; }
    }

    public sealed class SystemClock : IClock
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }

    public interface IOrderValidator
    {
        bool IsValid(int orderId);
    }

    public sealed class OrderValidator : IOrderValidator
    {
        public bool IsValid(int orderId) => orderId > 0;
    }

    public interface IOrderProcessor
    {
        Guid InstanceId { get; }
        Task ProcessAsync(int orderId);
    }

    public sealed class OrderProcessor : IOrderProcessor
    {
        private readonly IOrderValidator _validator;
        private readonly IClock _clock;

        public Guid InstanceId { get; } = Guid.NewGuid();

        public OrderProcessor(IOrderValidator validator, IClock clock)
        {
            _validator = validator;
            _clock = clock;
        }

        public Task ProcessAsync(int orderId)
        {
            var valid = _validator.IsValid(orderId);
            System.Console.WriteLine($"Processor {InstanceId:N} at {_clock.UtcNow:O} -> Order {orderId} valid={valid}");
            return Task.CompletedTask;
        }
    }
}
