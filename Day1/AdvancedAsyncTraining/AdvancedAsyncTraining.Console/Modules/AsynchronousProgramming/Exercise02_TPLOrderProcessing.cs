namespace AdvancedAsyncTraining.Console.Modules.AsynchronousProgramming;

public static class Exercise02_TPLOrderProcessing
{
    public static async Task RunAsync()
    {
        System.Console.WriteLine("Exercise 2: TPL Order Processing");
        System.Console.WriteLine("--------------------------------");

        var orders = Enumerable.Range(1, 10).ToList();

        var tasks = orders.Select(ProcessOrderAsync);

        await Task.WhenAll(tasks);

        System.Console.WriteLine("All orders processed");
    }

    private static async Task ProcessOrderAsync(int orderId)
    {
        System.Console.WriteLine($"Order {orderId} started");

        await Task.WhenAll(
            ValidateOrderAsync(orderId),
            FraudCheckAsync(orderId),
            InventoryCheckAsync(orderId)
        );

        await ProcessPaymentAsync(orderId);
        await SendNotificationAsync(orderId);

        System.Console.WriteLine($"Order {orderId} completed");
    }

    private static async Task ValidateOrderAsync(int orderId)
    {
        await Task.Delay(500);
        System.Console.WriteLine($"Order {orderId}: validated");
    }

    private static async Task FraudCheckAsync(int orderId)
    {
        await Task.Delay(700);
        System.Console.WriteLine($"Order {orderId}: fraud checked");
    }

    private static async Task InventoryCheckAsync(int orderId)
    {
        await Task.Delay(600);
        System.Console.WriteLine($"Order {orderId}: inventory checked");
    }

    private static async Task ProcessPaymentAsync(int orderId)
    {
        await Task.Delay(800);
        System.Console.WriteLine($"Order {orderId}: payment processed");
    }

    private static async Task SendNotificationAsync(int orderId)
    {
        await Task.Delay(300);
        System.Console.WriteLine($"Order {orderId}: notification sent");
    }
}


