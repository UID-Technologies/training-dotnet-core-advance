namespace AdvancedAsyncTraining.Console.Modules.AsynchronousProgramming;

public static class Exercise12_AsyncExceptions
{
    public static async Task RunAsync()
    {
        System.Console.WriteLine("Exercise 12: Async Exception Handling");
        System.Console.WriteLine("-------------------------------------");

        var paymentTask = CallPaymentGatewayAsync();
        var fraudTask = CallFraudServiceAsync();
        var inventoryTask = CallInventoryServiceAsync();

        try
        {
            await Task.WhenAll(paymentTask, fraudTask, inventoryTask);
        }
        catch
        {
            System.Console.WriteLine("One or more services failed");

            PrintException(paymentTask, "Payment");
            PrintException(fraudTask, "Fraud");
            PrintException(inventoryTask, "Inventory");
        }

        System.Console.WriteLine("Exercise completed");
    }

    private static async Task CallPaymentGatewayAsync()
    {
        await Task.Delay(500);
        throw new Exception("Payment gateway timeout");
    }

    private static async Task CallFraudServiceAsync()
    {
        await Task.Delay(700);
        throw new Exception("Fraud service unavailable");
    }

    private static async Task CallInventoryServiceAsync()
    {
        await Task.Delay(300);
        System.Console.WriteLine("Inventory checked");
    }

    private static void PrintException(Task task, string serviceName)
    {
        if (task.Exception is not null)
        {
            System.Console.WriteLine($"{serviceName}: {task.Exception.InnerException?.Message}");
        }
    }
}


