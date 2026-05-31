namespace AdvancedAsyncTraining.Console.Modules.MemoryManagement;

public static class Exercise16_ObjectRoots
{
    private static byte[]? _staticRoot;

    public static void Run()
    {
        System.Console.WriteLine("Exercise 16: Object Roots");

        _staticRoot = new byte[50 * 1024 * 1024];

        System.Console.WriteLine($"Memory with static root: {GC.GetTotalMemory(false) / 1024 / 1024} MB");

        GC.Collect();
        GC.WaitForPendingFinalizers();

        System.Console.WriteLine($"After GC while static root exists: {GC.GetTotalMemory(true) / 1024 / 1024} MB");

        _staticRoot = null;

        GC.Collect();
        GC.WaitForPendingFinalizers();

        System.Console.WriteLine($"After removing static root: {GC.GetTotalMemory(true) / 1024 / 1024} MB");
    }
}
