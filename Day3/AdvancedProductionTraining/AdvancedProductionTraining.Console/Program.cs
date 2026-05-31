using AdvancedProductionTraining.Console.Modules.Capstone;
using AdvancedProductionTraining.Console.Modules.IntegrationTesting;
using AdvancedProductionTraining.Console.Modules.Observability;
using AdvancedProductionTraining.Console.Modules.PerformanceTesting;
using AdvancedProductionTraining.Console.Modules.SecurityTesting;
using AdvancedProductionTraining.Console.Modules.UnitTesting;

while (true)
{
    Console.Clear();
    Console.WriteLine("Advanced .NET Training — Day 3");
    Console.WriteLine("Testing, Performance & Production Readiness");
    Console.WriteLine("============================================");
    Console.WriteLine();
    Console.WriteLine("Select a module:");
    Console.WriteLine("  1. Unit Testing (10 exercises)");
    Console.WriteLine("  2. Integration Testing (6 exercises)");
    Console.WriteLine("  3. API Performance Testing (7 exercises)");
    Console.WriteLine("  4. API Security Testing (7 exercises)");
    Console.WriteLine("  5. Observability & Monitoring (7 exercises)");
    Console.WriteLine("  0. Exit");
    Console.WriteLine();
    Console.Write("Select module: ");

    switch (Console.ReadLine())
    {
        case "1": await RunUnitTestingModuleAsync(); break;
        case "2": await RunIntegrationTestingModuleAsync(); break;
        case "3": await RunPerformanceTestingModuleAsync(); break;
        case "4": await RunSecurityTestingModuleAsync(); break;
        case "5": await RunObservabilityModuleAsync(); break;
        case "0": return;
        default:
            Console.WriteLine("Invalid module selected.");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            break;
    }
}

static async Task RunUnitTestingModuleAsync()
{
    Console.Clear();
    Console.WriteLine("Module 1: Unit Testing");
    Console.WriteLine("======================");
    PrintMenu(1, 10, new[]
    {
        "xUnit Introduction", "Arrange Act Assert", "Writing Unit Tests", "Moq Basics",
        "Mocking Dependencies", "DI Testing", "Test Fixtures", "FluentAssertions",
        "xUnit vs NUnit vs MSTest", "Lab: Business Services"
    });
    switch (Console.ReadLine())
    {
        case "1": await Exercise01_XUnitIntroduction.RunAsync(); break;
        case "2": await Exercise02_ArrangeActAssert.RunAsync(); break;
        case "3": await Exercise03_WritingUnitTests.RunAsync(); break;
        case "4": await Exercise04_MoqBasics.RunAsync(); break;
        case "5": await Exercise05_MockingDependencies.RunAsync(); break;
        case "6": await Exercise06_DependencyInjectionTesting.RunAsync(); break;
        case "7": await Exercise07_TestFixtures.RunAsync(); break;
        case "8": await Exercise08_FluentAssertions.RunAsync(); break;
        case "9": await Exercise09_NUnitMSTestComparison.RunAsync(); break;
        case "10": await Exercise10_UnitTestLab.RunAsync(); break;
        case "0": return;
        default: Console.WriteLine("Invalid exercise."); break;
    }
    await PauseAsync();
}

static async Task RunIntegrationTestingModuleAsync()
{
    Console.Clear();
    Console.WriteLine("Module 2: Integration Testing");
    Console.WriteLine("===============================");
    PrintMenu(11, 16, new[]
    {
        "Integration vs Unit", "WebApplicationFactory", "In-Memory Test Server",
        "Testing ASP.NET Core APIs", "Test Database Setup", "Lab: API Endpoints"
    });
    switch (Console.ReadLine())
    {
        case "1": await Exercise11_IntegrationVsUnit.RunAsync(); break;
        case "2": await Exercise12_WebApplicationFactory.RunAsync(); break;
        case "3": await Exercise13_InMemoryTestServer.RunAsync(); break;
        case "4": await Exercise14_TestingAspNetCoreApis.RunAsync(); break;
        case "5": await Exercise15_TestDatabaseSetup.RunAsync(); break;
        case "6": await Exercise16_IntegrationTestLab.RunAsync(); break;
        case "0": return;
        default: Console.WriteLine("Invalid exercise."); break;
    }
    await PauseAsync();
}

static async Task RunPerformanceTestingModuleAsync()
{
    Console.Clear();
    Console.WriteLine("Module 3: API Performance Testing");
    Console.WriteLine("=================================");
    PrintMenu(17, 23, new[]
    {
        "Performance Bottlenecks", "Load Testing Strategies", "Stress Testing",
        "BenchmarkDotNet", "Benchmark Lab", "Latency & Throughput", "Lab: k6 Load Test"
    });
    switch (Console.ReadLine())
    {
        case "1": await Exercise17_PerformanceBottlenecks.RunAsync(); break;
        case "2": await Exercise18_LoadTestingStrategies.RunAsync(); break;
        case "3": await Exercise19_StressTesting.RunAsync(); break;
        case "4": await Exercise20_BenchmarkDotNet.RunAsync(); break;
        case "5": await Exercise21_BenchmarkLab.RunAsync(); break;
        case "6": await Exercise22_LatencyThroughputMetrics.RunAsync(); break;
        case "7": await Exercise23_LoadTestLab.RunAsync(); break;
        case "0": return;
        default: Console.WriteLine("Invalid exercise."); break;
    }
    await PauseAsync();
}

static async Task RunSecurityTestingModuleAsync()
{
    Console.Clear();
    Console.WriteLine("Module 4: API Security Testing");
    Console.WriteLine("==============================");
    PrintMenu(24, 30, new[]
    {
        "OWASP Top 10", "Authentication Attacks", "Injection Attacks",
        "Rate Limiting", "API Throttling", "Security Tools", "Security Lab"
    });
    switch (Console.ReadLine())
    {
        case "1": await Exercise24_OwaspTop10.RunAsync(); break;
        case "2": await Exercise25_AuthenticationAttacks.RunAsync(); break;
        case "3": await Exercise26_InjectionAttacks.RunAsync(); break;
        case "4": await Exercise27_RateLimiting.RunAsync(); break;
        case "5": await Exercise28_ApiThrottling.RunAsync(); break;
        case "6": await Exercise29_SecurityTestingTools.RunAsync(); break;
        case "7": await Exercise30_SecurityTestLab.RunAsync(); break;
        case "0": return;
        default: Console.WriteLine("Invalid exercise."); break;
    }
    await PauseAsync();
}

static async Task RunObservabilityModuleAsync()
{
    Console.Clear();
    Console.WriteLine("Module 5: Observability & Monitoring");
    Console.WriteLine("====================================");
    PrintMenu(31, 38, new[]
    {
        "Logging Strategies", "Serilog", "Structured Logging", "Health Checks",
        "OpenTelemetry", "Distributed Tracing", "Application Insights", "Production Capstone"
    });
    switch (Console.ReadLine())
    {
        case "1": await Exercise31_LoggingStrategies.RunAsync(); break;
        case "2": await Exercise32_Serilog.RunAsync(); break;
        case "3": await Exercise33_StructuredLogging.RunAsync(); break;
        case "4": await Exercise34_HealthChecks.RunAsync(); break;
        case "5": await Exercise35_OpenTelemetry.RunAsync(); break;
        case "6": await Exercise36_DistributedTracing.RunAsync(); break;
        case "7": await Exercise37_ApplicationInsights.RunAsync(); break;
        case "8": await Exercise38_ProductionReadinessCapstone.RunAsync(); break;
        case "0": return;
        default: Console.WriteLine("Invalid exercise."); break;
    }
    await PauseAsync();
}

static void PrintMenu(int start, int end, string[] titles)
{
    for (var i = 0; i < titles.Length; i++)
    {
        Console.WriteLine($"  {i + 1,2}. {titles[i]}");
    }
    Console.WriteLine("   0. Back to main menu");
    Console.WriteLine();
    Console.Write("Select exercise: ");
}

static Task PauseAsync()
{
    Console.WriteLine();
    Console.WriteLine("Press Enter to return to main menu...");
    Console.ReadLine();
    return Task.CompletedTask;
}
