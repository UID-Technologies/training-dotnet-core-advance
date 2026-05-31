namespace AdvancedAsyncTraining.Console.Modules.MemoryManagement;

public static class Exercise14_ManagedHeapInternals
{
    public static void Run()
    {
        System.Console.WriteLine("Exercise 14: Managed Heap Internals");

        var smallObject = new byte[1024];
        var largeObject = new byte[100_000];

        System.Console.WriteLine($"Small object generation: {GC.GetGeneration(smallObject)}");
        System.Console.WriteLine($"Large object generation: {GC.GetGeneration(largeObject)}");

        GC.Collect();

        System.Console.WriteLine($"Small object generation after GC: {GC.GetGeneration(smallObject)}");
        System.Console.WriteLine($"Large object generation after GC: {GC.GetGeneration(largeObject)}");
    }
}
