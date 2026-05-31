namespace AdvancedAsyncTraining.Console.Modules.MemoryManagement;

public static class Exercise20_UsingBlocks
{
    public static void Run()
    {
        System.Console.WriteLine("Exercise 20: Using Blocks");

        try
        {
            using var connection = new FakeDatabaseConnection();

            connection.Open();

            throw new Exception("Simulated failure");
        }
        catch
        {
            System.Console.WriteLine("Exception occurred, but Dispose still executed");
        }
    }

    private sealed class FakeDatabaseConnection : IDisposable
    {
        public void Open()
        {
            System.Console.WriteLine("Connection opened");
        }

        public void Dispose()
        {
            System.Console.WriteLine("Connection disposed");
        }
    }
}
