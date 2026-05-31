namespace AdvancedAsyncTraining.Console.Modules.MemoryManagement;

public static class Exercise15_GenerationalGC
{
    public static void Run()
    {
        System.Console.WriteLine("Exercise 15: Generational Garbage Collection");

        var customer = new CustomerBuffer();

        System.Console.WriteLine($"Initial Generation: {GC.GetGeneration(customer)}");

        GC.Collect();
        System.Console.WriteLine($"After First GC: {GC.GetGeneration(customer)}");

        GC.Collect();
        System.Console.WriteLine($"After Second GC: {GC.GetGeneration(customer)}");
    }

    private sealed class CustomerBuffer
    {
        public byte[] Data { get; } = new byte[1024];
    }
}
