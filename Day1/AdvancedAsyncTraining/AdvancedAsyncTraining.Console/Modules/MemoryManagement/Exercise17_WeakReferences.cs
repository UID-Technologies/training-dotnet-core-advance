namespace AdvancedAsyncTraining.Console.Modules.MemoryManagement;

public static class Exercise17_WeakReferences
{
    public static void Run()
    {
        System.Console.WriteLine("Exercise 17: Weak References");

        var customer = new Customer("C001");
        var weakReference = new WeakReference<Customer>(customer);

        System.Console.WriteLine($"Before GC: {weakReference.TryGetTarget(out _)}");

        customer = null!;

        GC.Collect();
        GC.WaitForPendingFinalizers();

        System.Console.WriteLine($"After GC: {weakReference.TryGetTarget(out _)}");
    }

    private sealed record Customer(string Code);
}
