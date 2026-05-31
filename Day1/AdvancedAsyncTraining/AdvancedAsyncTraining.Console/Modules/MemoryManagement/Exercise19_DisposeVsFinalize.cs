namespace AdvancedAsyncTraining.Console.Modules.MemoryManagement;

public static class Exercise19_DisposeVsFinalize
{
    public static void Run()
    {
        System.Console.WriteLine("Exercise 19: Dispose vs Finalize");

        using var resource = new NativeResource();
        resource.Use();

        System.Console.WriteLine("End of using block will call Dispose");
    }

    private sealed class NativeResource : IDisposable
    {
        private bool _disposed;

        public void Use()
        {
            System.Console.WriteLine("Using native resource");
        }

        ~NativeResource()
        {
            System.Console.WriteLine("Finalizer called");
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                System.Console.WriteLine("Cleaning managed resources");
            }

            System.Console.WriteLine("Cleaning unmanaged resources");

            _disposed = true;
        }
    }
}
