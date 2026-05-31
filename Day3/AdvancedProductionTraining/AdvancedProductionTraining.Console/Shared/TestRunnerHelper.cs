using System.Diagnostics;

namespace AdvancedProductionTraining.Console.Shared;

public static class TestRunnerHelper
{
    public static string SolutionRoot =>
        Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".."));

    public static string TestsProjectPath =>
        Path.Combine(SolutionRoot, "AdvancedProductionTraining.Tests", "AdvancedProductionTraining.Tests.csproj");

    public static string BenchmarksProjectPath =>
        Path.Combine(SolutionRoot, "AdvancedProductionTraining.Benchmarks", "AdvancedProductionTraining.Benchmarks.csproj");

    public static async Task<int> RunDotnetTestAsync(string? filter = null)
    {
        var args = $"test \"{TestsProjectPath}\" --nologo -v minimal";
        if (!string.IsNullOrWhiteSpace(filter))
        {
            args += $" --filter \"{filter}\"";
        }

        return await RunProcessAsync("dotnet", args, SolutionRoot);
    }

    public static async Task<int> RunDotnetBenchmarkAsync()
    {
        return await RunProcessAsync(
            "dotnet",
            $"run -c Release --project \"{BenchmarksProjectPath}\" -- --filter *",
            SolutionRoot);
    }

    public static async Task<int> RunProcessAsync(string fileName, string arguments, string workingDirectory)
    {
        System.Console.WriteLine($"$ {fileName} {arguments}");
        System.Console.WriteLine();

        var psi = new ProcessStartInfo
        {
            FileName = fileName,
            Arguments = arguments,
            WorkingDirectory = workingDirectory,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false
        };

        using var process = Process.Start(psi)
            ?? throw new InvalidOperationException($"Failed to start {fileName}.");

        var stdout = await process.StandardOutput.ReadToEndAsync();
        var stderr = await process.StandardError.ReadToEndAsync();
        if (!string.IsNullOrWhiteSpace(stdout))
        {
            System.Console.WriteLine(stdout);
        }

        if (!string.IsNullOrWhiteSpace(stderr))
        {
            System.Console.WriteLine(stderr);
        }

        await process.WaitForExitAsync();
        return process.ExitCode;
    }
}
