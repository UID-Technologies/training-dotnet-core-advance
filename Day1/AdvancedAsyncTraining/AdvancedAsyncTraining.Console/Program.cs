using AdvancedAsyncTraining.Console.Modules.AsynchronousProgramming;
using AdvancedAsyncTraining.Console.Modules.EntityFrameworkCore;
using AdvancedAsyncTraining.Console.Modules.MemoryManagement;

while (true)
{
	Console.Clear();
	Console.WriteLine("Advanced .NET Training");
	Console.WriteLine("======================");
	Console.WriteLine();
	Console.WriteLine("Select a module:");
	Console.WriteLine("  1. Asynchronous Programming (12 exercises)");
	Console.WriteLine("  2. Memory Management (9 exercises)");
	Console.WriteLine("  3. Entity Framework Core (10 exercises)");
	Console.WriteLine("  0. Exit");
	Console.WriteLine();
	Console.Write("Select module: ");

	var moduleInput = Console.ReadLine();

	switch (moduleInput)
	{
		case "1":
			await RunAsynchronousProgrammingModuleAsync();
			break;

		case "2":
			await RunMemoryManagementModuleAsync();
			break;

		case "3":
			await RunEntityFrameworkCoreModuleAsync();
			break;

		case "0":
			return;

		default:
			Console.WriteLine("Invalid module selected.");
			Console.WriteLine("Press Enter to continue...");
			Console.ReadLine();
			break;
	}
}

static async Task RunAsynchronousProgrammingModuleAsync()
{
	Console.Clear();
	Console.WriteLine("Module 1: Asynchronous Programming");
	Console.WriteLine("==================================");
	Console.WriteLine("  1. Threading Model");
	Console.WriteLine("  2. TPL Order Processing");
	Console.WriteLine("  3. Task vs Thread");
	Console.WriteLine("  4. Task Scheduling");
	Console.WriteLine("  5. Task Chaining");
	Console.WriteLine("  6. Parallel Programming");
	Console.WriteLine("  7. Parallel.ForEach");
	Console.WriteLine("  8. PLINQ");
	Console.WriteLine("  9. Sync Over Async");
	Console.WriteLine(" 10. Async State Machine");
	Console.WriteLine(" 11. ConfigureAwait");
	Console.WriteLine(" 12. Async Exceptions");
	Console.WriteLine("  0. Back to main menu");
	Console.WriteLine();
	Console.Write("Select exercise: ");

	switch (Console.ReadLine())
	{
		case "1":
			await Exercise01_ThreadingModel.RunAsync();
			break;
		case "2":
			await Exercise02_TPLOrderProcessing.RunAsync();
			break;
		case "3":
			await Exercise03_TaskVsThread.RunAsync();
			break;
		case "4":
			await Exercise04_TaskScheduling.RunAsync();
			break;
		case "5":
			await Exercise05_TaskChaining.RunAsync();
			break;
		case "6":
			Exercise06_ParallelProgramming.Run();
			break;
		case "7":
			Exercise07_ParallelForEach.Run();
			break;
		case "8":
			Exercise08_PLINQ.Run();
			break;
		case "9":
			Exercise09_SyncOverAsync.Run();
			break;
		case "10":
			await Exercise10_AsyncStateMachine.RunAsync();
			break;
		case "11":
			await Exercise11_ConfigureAwait.RunAsync();
			break;
		case "12":
			await Exercise12_AsyncExceptions.RunAsync();
			break;
		case "0":
			return;
		default:
			Console.WriteLine("Invalid exercise selected.");
			break;
	}

	Console.WriteLine();
	Console.WriteLine("Press Enter to return to main menu...");
	Console.ReadLine();
}

static async Task RunMemoryManagementModuleAsync()
{
	Console.Clear();
	Console.WriteLine("Module 2: Memory Management");
	Console.WriteLine("===========================");
	Console.WriteLine("  1. Managed vs Unmanaged Memory");
	Console.WriteLine("  2. Managed Heap Internals");
	Console.WriteLine("  3. Generational GC");
	Console.WriteLine("  4. Object Roots");
	Console.WriteLine("  5. Weak References");
	Console.WriteLine("  6. IDisposable Pattern");
	Console.WriteLine("  7. Dispose vs Finalize");
	Console.WriteLine("  8. Using Blocks");
	Console.WriteLine("  9. Async Data Processing Pipeline (Capstone)");
	Console.WriteLine("  0. Back to main menu");
	Console.WriteLine();
	Console.Write("Select exercise: ");

	switch (Console.ReadLine())
	{
		case "1":
			Exercise13_ManagedVsUnmanagedMemory.Run();
			break;
		case "2":
			Exercise14_ManagedHeapInternals.Run();
			break;
		case "3":
			Exercise15_GenerationalGC.Run();
			break;
		case "4":
			Exercise16_ObjectRoots.Run();
			break;
		case "5":
			Exercise17_WeakReferences.Run();
			break;
		case "6":
			Exercise18_IDisposablePattern.Run();
			break;
		case "7":
			Exercise19_DisposeVsFinalize.Run();
			break;
		case "8":
			Exercise20_UsingBlocks.Run();
			break;
		case "9":
			await Exercise21_AsyncPipelinePerformance.RunAsync();
			break;
		case "0":
			return;
		default:
			Console.WriteLine("Invalid exercise selected.");
			break;
	}

	Console.WriteLine();
	Console.WriteLine("Press Enter to return to main menu...");
	Console.ReadLine();
}

static async Task RunEntityFrameworkCoreModuleAsync()
{
	Console.Clear();
	Console.WriteLine("Module 3: Entity Framework Core");
	Console.WriteLine("===============================");
	Console.WriteLine("  1. EF Core Architecture");
	Console.WriteLine("  2. Database First");
	Console.WriteLine("  3. Code First");
	Console.WriteLine("  4. Change Tracking");
	Console.WriteLine("  5. Tracking vs NoTracking");
	Console.WriteLine("  6. Lazy vs Eager Loading");
	Console.WriteLine("  7. Split Queries");
	Console.WriteLine("  8. Compiled Queries");
	Console.WriteLine("  9. Pagination");
	Console.WriteLine(" 10. EF Core DAL Lab (Capstone)");
	Console.WriteLine("  0. Back to main menu");
	Console.WriteLine();
	Console.Write("Select exercise: ");

	switch (Console.ReadLine())
	{
		case "1":
			await Exercise22_EFCoreArchitecture.RunAsync();
			break;
		case "2":
			await Exercise23_DatabaseFirst.RunAsync();
			break;
		case "3":
			await Exercise24_CodeFirst.RunAsync();
			break;
		case "4":
			await Exercise25_ChangeTracking.RunAsync();
			break;
		case "5":
			await Exercise26_QueryOptimization.RunAsync();
			break;
		case "6":
			await Exercise27_LazyVsEagerLoading.RunAsync();
			break;
		case "7":
			await Exercise28_SplitQueries.RunAsync();
			break;
		case "8":
			await Exercise29_CompiledQueries.RunAsync();
			break;
		case "9":
			await Exercise30_Pagination.RunAsync();
			break;
		case "10":
			await Exercise31_DataAccessLayerLab.RunAsync();
			break;
		case "0":
			return;
		default:
			Console.WriteLine("Invalid exercise selected.");
			break;
	}

	Console.WriteLine();
	Console.WriteLine("Press Enter to return to main menu...");
	Console.ReadLine();
}
