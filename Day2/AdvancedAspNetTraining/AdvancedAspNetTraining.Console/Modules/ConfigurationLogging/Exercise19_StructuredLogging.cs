using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AdvancedAspNetTraining.Console.Modules.ConfigurationLogging;

public static class Exercise19_StructuredLogging
{
    public static async Task RunAsync()
    {
        System.Console.WriteLine("Exercise 19: Logging Providers & Structured Logging");
        System.Console.WriteLine("----------------------------------------------------");

        var host = Host.CreateDefaultBuilder()
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
                logging.SetMinimumLevel(LogLevel.Debug);
            })
            .ConfigureServices(services => services.AddSingleton<OrderAuditService>())
            .Build();

        await host.StartAsync();

        var audit = host.Services.GetRequiredService<OrderAuditService>();
        audit.LogOrderCreated(1001, "Contoso", 499.99m);
        audit.LogOrderFailed(1002, new InvalidOperationException("Payment declined"));

        await host.StopAsync();
    }

    public sealed class OrderAuditService
    {
        private readonly ILogger<OrderAuditService> _logger;

        public OrderAuditService(ILogger<OrderAuditService> logger)
        {
            _logger = logger;
        }

        public void LogOrderCreated(int orderId, string customer, decimal total)
        {
            _logger.LogInformation(
                "Order {OrderId} created for {Customer} with total {OrderTotal:C}",
                orderId,
                customer,
                total);
        }

        public void LogOrderFailed(int orderId, Exception ex)
        {
            _logger.LogError(
                ex,
                "Order {OrderId} failed during processing",
                orderId);
        }
    }
}
