namespace AdvancedAsyncTraining.Console.Modules.MemoryManagement;

public static class Exercise18_IDisposablePattern
{
    public static void Run()
    {
        System.Console.WriteLine("Exercise 18: IDisposable Pattern");

        using var processor = new FileProcessor();

        processor.Process();

        System.Console.WriteLine("Processor disposed automatically");
    }

    private sealed class FileProcessor : IDisposable
    {
        private bool _disposed;

        public void Process()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(FileProcessor));
            }

            System.Console.WriteLine("Processing file...");
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            System.Console.WriteLine("Releasing resources...");
            _disposed = true;
        }
    }
}
