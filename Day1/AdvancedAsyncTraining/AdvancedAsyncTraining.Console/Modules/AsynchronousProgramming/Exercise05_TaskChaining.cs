namespace AdvancedAsyncTraining.Console.Modules.AsynchronousProgramming;

public static class Exercise05_TaskChaining
{
    public static async Task RunAsync()
    {
        System.Console.WriteLine("Exercise 5: Task Chaining");
        System.Console.WriteLine("-------------------------");

        System.Console.WriteLine("Version 1: ContinueWith");

        await Task.Run(SubmitClaim)
            .ContinueWith(_ => ValidateClaim())
            .ContinueWith(_ => FraudCheck())
            .ContinueWith(_ => ApproveClaim())
            .ContinueWith(_ => ProcessPayment());

        System.Console.WriteLine();

        System.Console.WriteLine("Version 2: Async/Await");

        await SubmitClaimAsync();
        await ValidateClaimAsync();
        await FraudCheckAsync();
        await ApproveClaimAsync();
        await ProcessPaymentAsync();

        System.Console.WriteLine("Exercise completed");
    }

    private static void SubmitClaim() => System.Console.WriteLine("Claim submitted");
    private static void ValidateClaim() => System.Console.WriteLine("Claim validated");
    private static void FraudCheck() => System.Console.WriteLine("Fraud check completed");
    private static void ApproveClaim() => System.Console.WriteLine("Claim approved");
    private static void ProcessPayment() => System.Console.WriteLine("Payment processed");

    private static async Task SubmitClaimAsync()
    {
        await Task.Delay(300);
        System.Console.WriteLine("Claim submitted");
    }

    private static async Task ValidateClaimAsync()
    {
        await Task.Delay(300);
        System.Console.WriteLine("Claim validated");
    }

    private static async Task FraudCheckAsync()
    {
        await Task.Delay(300);
        System.Console.WriteLine("Fraud check completed");
    }

    private static async Task ApproveClaimAsync()
    {
        await Task.Delay(300);
        System.Console.WriteLine("Claim approved");
    }

    private static async Task ProcessPaymentAsync()
    {
        await Task.Delay(300);
        System.Console.WriteLine("Payment processed");
    }
}


