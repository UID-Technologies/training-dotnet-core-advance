using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AdvancedAspNetTraining.Console.Modules.DependencyInjection;

public static class Exercise16_AdvancedDiPatterns
{
    public static async Task RunAsync()
    {
        System.Console.WriteLine("Exercise 16: Advanced DI Patterns");
        System.Console.WriteLine("--------------------------------");

        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddKeyedSingleton<INotifier, EmailNotifier>("email");
                services.AddKeyedSingleton<INotifier, SmsNotifier>("sms");

                services.AddSingleton<INotificationService, NotificationService>();

                services.AddSingleton<ReportService>();
                services.AddSingleton<IReportService>(sp => sp.GetRequiredService<ReportService>());
            })
            .Build();

        await host.StartAsync();

        var notification = host.Services.GetRequiredService<INotificationService>();
        notification.Send("Order 42 shipped", "email");
        notification.Send("Order 42 shipped", "sms");

        var report = host.Services.GetRequiredService<IReportService>();
        report.Generate();

        await host.StopAsync();
    }

    public interface INotifier
    {
        void Send(string message);
    }

    public sealed class EmailNotifier : INotifier
    {
        public void Send(string message) =>
            System.Console.WriteLine($"[Email] {message}");
    }

    public sealed class SmsNotifier : INotifier
    {
        public void Send(string message) =>
            System.Console.WriteLine($"[SMS] {message}");
    }

    public interface INotificationService
    {
        void Send(string message, string channel);
    }

    public sealed class NotificationService : INotificationService
    {
        private readonly IServiceProvider _provider;

        public NotificationService(IServiceProvider provider)
        {
            _provider = provider;
        }

        public void Send(string message, string channel)
        {
            var notifier = _provider.GetRequiredKeyedService<INotifier>(channel);
            notifier.Send(message);
        }
    }

    public interface IReportService
    {
        void Generate();
    }

    public sealed class ReportService : IReportService
    {
        public void Generate() =>
            System.Console.WriteLine("[Report] Generated via factory/delegate registration.");
    }
}
