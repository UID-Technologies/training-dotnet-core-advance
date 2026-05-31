using System.Runtime.InteropServices;

namespace AdvancedAsyncTraining.Console.Modules.MemoryManagement;

public static class Exercise13_ManagedVsUnmanagedMemory
{
    public static void Run()
    {
        System.Console.WriteLine("Exercise 13: Managed vs Unmanaged Memory");

        var managedObjects = new List<byte[]>();

        for (int i = 0; i < 1_000; i++)
        {
            managedObjects.Add(new byte[4 * 1024]);
        }

        System.Console.WriteLine($"Managed allocations created: {managedObjects.Count}");
        System.Console.WriteLine($"Managed memory: {GC.GetTotalMemory(false) / 1024 / 1024} MB");

        var unmanagedPtr = Marshal.AllocHGlobal(10 * 1024 * 1024);
        try
        {
            System.Console.WriteLine("Allocated 10 MB unmanaged memory");
        }
        finally
        {
            Marshal.FreeHGlobal(unmanagedPtr);
            System.Console.WriteLine("Freed unmanaged memory manually");
        }
    }
}
