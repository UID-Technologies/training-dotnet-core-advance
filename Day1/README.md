# Advanced .NET Training — Async, Memory & Entity Framework Core

## Overview

Modern .NET applications must be **scalable**, **performant**, and **resource-efficient**. Enterprise systems — APIs, distributed services, streaming platforms, financial systems, and batch processors — handle thousands of concurrent requests while keeping memory use under control and data access fast.

This training covers three advanced areas of .NET development:

| Module | Focus | Exercises |
| ------ | ----- | --------- |
| **1. Asynchronous Programming** | Non-blocking, concurrent execution with Task, TPL, and async/await | 12 |
| **2. Memory Management** | GC internals, resource cleanup, and memory-efficient patterns | 9 |
| **3. Entity Framework Core** | Data access architecture, query optimization, and DAL patterns | 10 |

By the end of this training, participants will understand how asynchronous execution works internally, how the Garbage Collector manages memory, how to avoid common performance pitfalls, and how to build efficient data access layers with EF Core.

---

## Getting Started

### Project Structure

The lab uses **one console project** organized into three module folders:

```text
AdvancedAsyncTraining/
├── AdvancedAsyncTraining.sln
└── AdvancedAsyncTraining.Console/
    ├── Program.cs                              ← Module menu → exercise menu
    └── Modules/
        ├── AsynchronousProgramming/            ← Exercises 1–12 + Models
        ├── MemoryManagement/                   ← Exercises 13–21
        └── EntityFrameworkCore/                ← Exercises 22–31 + Data + EfCoreModels
```

### Prerequisites

- .NET SDK 9.0+
- Visual Studio or VS Code
- Basic C# knowledge

### Running the Lab

```bash
cd AdvancedAsyncTraining
dotnet restore
dotnet build
dotnet run --project AdvancedAsyncTraining.Console
```

1. Select a **module** (1–3) from the main menu.
2. Select an **exercise** within that module.
3. Press Enter to return to the main menu after each exercise.

### Recommended Learning Path

```text
Module 1 (Async)  →  Module 2 (Memory)  →  Module 3 (EF Core)
```

Module 3 assumes familiarity with async/await from Module 1. Exercise 21 (Memory capstone) reuses async patterns from Module 1.

---

# Module 1: Asynchronous Programming

**Folder:** `Modules/AsynchronousProgramming/`  
**Menu:** Main menu → `1`

Asynchronous programming lets applications continue working while waiting for I/O — database calls, API requests, file access, message queues, and network communication — without blocking threads.

## Why Asynchronous Programming?

Synchronous code blocks the thread until work completes:

```csharp
Thread.Sleep(5000);   // Thread is blocked — cannot do other work
```

Asynchronous code releases the thread back to the ThreadPool:

```csharp
await Task.Delay(5000);   // Thread is free while waiting
```

In enterprise applications, blocking threads reduces scalability and throughput.

---

## Topics & Exercises

| Menu | Exercise | Topic | What You Will Learn |
| ---- | -------- | ----- | ------------------- |
| 1 | Threading Model | Threading model in .NET | Main thread vs ThreadPool; blocking (`Thread.Sleep`) vs non-blocking (`Task.Delay`) |
| 2 | TPL Order Processing | Task Parallel Library | Fan-out/fan-in with `Task.WhenAll`; concurrent order validation pipeline |
| 3 | Task vs Thread | Task vs Thread | OS threads are expensive; Tasks are lightweight abstractions; bounded concurrency |
| 4 | Task Scheduling | Task scheduling | `TaskScheduler.Default`; how the runtime assigns work to ThreadPool threads |
| 5 | Task Chaining | Task chaining | `ContinueWith` vs modern `async/await`; readable async pipelines |
| 6 | Parallel Programming | CPU-bound parallelism | `Parallel.ForEach` for CPU-intensive work; when **not** to parallelize I/O |
| 7 | Parallel.ForEach | Parallel iteration | `Parallel.ForEach` and `Parallel.ForEachAsync` with concurrency limits |
| 8 | PLINQ | Parallel LINQ | `AsParallel()` for in-memory analytics; overhead and ordering trade-offs |
| 9 | Sync Over Async | Sync-over-async anti-patterns | Risks of `.Result`, `.Wait()`, and blocking async code |
| 10 | Async State Machine | Async/await internals | Compiler-generated state machines; async does **not** always create a new thread |
| 11 | ConfigureAwait | ConfigureAwait | Synchronization context; when to use `ConfigureAwait(false)` in libraries |
| 12 | Async Exceptions | Async exception handling | Exceptions stored in `Task`; handling failures in `Task.WhenAll` workflows |

---

## Key Concepts

### Threading Model

.NET uses a **ThreadPool-based execution model**. Threads are expensive — creating too many increases memory use, context switching, and CPU overhead. The ThreadPool reuses worker threads instead of creating one per operation.

| Concept | Description |
| ------- | ----------- |
| Main thread | Application entry thread |
| Worker thread | Background thread from the ThreadPool |
| Blocking operation | Keeps a thread occupied (e.g. `Thread.Sleep`) |
| Non-blocking operation | Releases the thread while waiting (e.g. `await Task.Delay`) |

### Task Parallel Library (TPL)

TPL provides high-level APIs for async and parallel work:

```text
Task, Task<T>, Task.Run(), Task.WhenAll(), Task.WhenAny()
Parallel.For(), Parallel.ForEach(), Parallel.ForEachAsync()
```

| Thread | Task |
| ------ | ---- |
| Low-level OS resource | High-level CLR abstraction |
| Expensive to create | Lightweight |
| Manually managed | Runtime managed |

Prefer `Task` for modern applications.

### Parallel Programming vs Async

| Pattern | Best for | Example |
| ------- | -------- | ------- |
| **Async/await** | I/O-bound work (DB, HTTP, files) | `await httpClient.GetAsync(...)` |
| **Parallel / PLINQ** | CPU-bound work (math, encryption) | `Parallel.ForEach`, `AsParallel()` |

Do not parallelize database or network calls unnecessarily — use async instead.

### Async/Await Internals

The compiler transforms `async` methods into **state machines**:

```text
Start execution → Pause at await → Return control → Resume when complete
```

**Async does not automatically create a new thread** — it creates resumable execution.

### Synchronization Context & ConfigureAwait

Synchronization context controls where execution resumes after `await`:

| Platform | Behavior |
| -------- | -------- |
| WinForms / WPF | Returns to UI thread |
| ASP.NET (legacy) | Synchronization context exists |
| ASP.NET Core | No traditional sync context — better scalability |

`ConfigureAwait(false)` tells the runtime not to capture the synchronization context. Recommended in **library code**; usually unnecessary in ASP.NET Core app code.

### Async Best Practices

```text
Use async all the way through the call stack
Avoid blocking async code (.Result, .Wait())
Prefer Task.WhenAll for independent I/O work
Avoid async void (except event handlers)
Use CancellationToken for cancellable operations
Avoid unnecessary Task.Run() for I/O-bound work
Control concurrency — do not unbounded fan-out
```

---

# Module 2: Memory Management

**Folder:** `Modules/MemoryManagement/`  
**Menu:** Main menu → `2`

Even with automatic garbage collection, developers must understand how .NET manages memory to build efficient, stable enterprise systems.

Poor memory usage causes high GC pressure, memory leaks, slow response times, excessive CPU usage, and `OutOfMemoryException`.

---

## Topics & Exercises

| Menu | Exercise | Topic | What You Will Learn |
| ---- | -------- | ----- | ------------------- |
| 1 | Managed vs Unmanaged Memory | Managed vs unmanaged memory | CLR-managed objects vs OS/native resources requiring explicit release |
| 2 | Managed Heap Internals | Managed heap internals | Gen 0, Gen 1, Gen 2, LOH, POH; how objects are allocated |
| 3 | Generational GC | Generational garbage collection | "Most objects die young"; promotion between generations |
| 4 | Object Roots | Object roots | Static fields, locals, and roots that keep objects alive — accidental retention |
| 5 | Weak References | Weak references | Memory-sensitive caches without preventing GC |
| 6 | IDisposable Pattern | IDisposable pattern | Deterministic cleanup for connections, streams, and handles |
| 7 | Dispose vs Finalize | Dispose vs finalize | Prefer `Dispose()`; finalizers are slow and expensive |
| 8 | Using Blocks | Using blocks | `using` / `await using` for guaranteed cleanup |
| 9 | Async Pipeline (Capstone) | Async + memory lab | High-throughput pipeline with `Parallel.ForEachAsync`, timing, and GC metrics |

---

## Key Concepts

### Managed vs Unmanaged Memory

**Managed memory** — controlled by the CLR and GC:

```text
Objects, arrays, collections, strings, custom classes
```

**Unmanaged memory** — outside GC control; must be released explicitly:

```text
Database connections, file handles, streams, sockets, native libraries
```

Use `IDisposable`, `using`, and the dispose pattern for unmanaged resources.

### Generational Garbage Collection

| Generation | Purpose |
| ---------- | ------- |
| Gen 0 | Short-lived objects |
| Gen 1 | Intermediate lifetime |
| Gen 2 | Long-lived objects |
| LOH | Large objects (typically > 85 KB) |

Frequent Gen 2 collections often indicate memory inefficiency. Avoid calling `GC.Collect()` in production code.

### GC Algorithm (Simplified)

```text
Mark   → Identify reachable objects
Compact → Reduce fragmentation
Sweep  → Release unused memory
```

### Object Roots & Memory Leaks

Common roots that keep objects alive:

```text
Static fields, local variables, method parameters, active threads, finalizer queue
```

Example of accidental retention:

```csharp
private static List<Customer> Cache = new();   // Objects stay alive until removed
```

### Weak References

Allow GC to collect an object even when referenced — useful for caches and temporary metadata:

```csharp
var weakRef = new WeakReference<Customer>(customer);
```

### IDisposable & Using

```csharp
using var connection = new SqlConnection(connectionString);
// Dispose() called automatically, even on exceptions
```

Guidelines:

```text
Prefer Dispose over finalizers
Call GC.SuppressFinalize() when implementing both
Use await using for async disposable resources (e.g. DbContext)
```

### Memory Performance Best Practices

```text
Reduce unnecessary allocations
Dispose resources promptly
Avoid loading entire datasets into memory
Prefer streaming (IAsyncEnumerable) over ToListAsync for large result sets
Avoid memory leaks from static collections and event handlers
Use Span<T> in performance-sensitive code
Monitor memory consumption under load
```

Poor approach:

```csharp
var data = await db.Orders.ToListAsync();   // Loads everything into memory
```

Better approach:

```csharp
await foreach (var order in db.Orders.AsAsyncEnumerable())
{
    Process(order);   // Processes one at a time
}
```

### Capstone: Async Data Processing Pipeline (Exercise 21)

Combines async patterns from Module 1 with memory monitoring:

```text
Load records → Transform → Validate → Persist → Measure throughput & memory
```

Uses `Parallel.ForEachAsync`, `ConcurrentBag`, `Stopwatch`, and `GC.GetTotalMemory`.

---

# Module 3: Entity Framework Core

**Folder:** `Modules/EntityFrameworkCore/`  
**Menu:** Main menu → `3`

Entity Framework Core (EF Core) is the modern ORM for .NET. This module covers architecture, modeling approaches, change tracking, query optimization, and building a reusable data access layer.

The lab uses **SQLite** with seeded sample data (`Customer`, `Order`, `OrderItem`, `Product`).

---

## Topics & Exercises

| Menu | Exercise | Topic | What You Will Learn |
| ---- | -------- | ----- | ------------------- |
| 1 | EF Core Architecture | EF Core architecture | `DbContext` lifecycle, provider model, logging, `AsNoTracking` reads |
| 2 | Database First | Database First | Scaffold models from an existing database schema |
| 3 | Code First | Code First | Migrations workflow when the application owns the schema |
| 4 | Change Tracking | Change tracking | Entity states: Added, Unchanged, Modified, Deleted |
| 5 | Tracking vs NoTracking | Query optimization | Performance difference between tracked and read-only queries |
| 6 | Lazy vs Eager Loading | Loading strategies | N+1 problem; `.Include()` / `.ThenInclude()` for eager loading |
| 7 | Split Queries | Split queries | Avoid cartesian explosion with `AsSplitQuery()` |
| 8 | Compiled Queries | Compiled queries | `EF.CompileAsyncQuery` for repeated query performance |
| 9 | Pagination | Pagination | Efficient paging with `Skip` / `Take` |
| 10 | DAL Lab (Capstone) | Data access layer | Generic repository pattern with `IRepository<T>` and EF Core |

---

## Key Concepts

### EF Core Architecture

EF Core sits between your application and the database:

```text
Application → DbContext → Change Tracker → Provider (SQLite/SQL Server) → Database
```

Core components:

| Component | Role |
| --------- | ---- |
| `DbContext` | Session with the database; tracks changes |
| `DbSet<T>` | Represents a table/collection |
| Change Tracker | Detects entity modifications for `SaveChanges` |
| Provider | Translates LINQ to SQL for the target database |

Always dispose `DbContext` — use `await using var db = new AppDbContext();`.

### Database First vs Code First

| Approach | When to use | Workflow |
| -------- | ----------- | -------- |
| **Database First** | Schema owned by DBAs or legacy database | Scaffold models from existing DB |
| **Code First** | Application owns the schema | Define models → create migrations → update database |

Database First scaffold command (Exercise 2):

```bash
dotnet ef dbcontext scaffold "Data Source=advanced-efcore.db" Microsoft.EntityFrameworkCore.Sqlite -o DatabaseFirstModels -c DatabaseFirstDbContext --force
```

Code First workflow (Exercise 3):

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### Change Tracking

EF Core tracks entity state automatically:

| State | Meaning |
| ----- | ------- |
| `Added` | New entity, not yet in database |
| `Unchanged` | Loaded from DB, no changes |
| `Modified` | Properties changed since load |
| `Deleted` | Marked for deletion |

Changes are persisted with `await db.SaveChangesAsync()`.

Inspect state: `db.Entry(entity).State`

### Tracking vs NoTracking

| Mode | Use case |
| ---- | -------- |
| **Tracking** (default) | Updates, deletes — EF watches for changes |
| **NoTracking** | Read-only queries — faster, lower memory |

```csharp
var customers = await db.Customers.AsNoTracking().ToListAsync();
```

Use `AsNoTracking()` for reports, APIs that only read data, and list/search endpoints.

### Lazy Loading vs Eager Loading

**Lazy loading** — related data loaded on first access (requires proxies; can cause N+1 queries):

```csharp
// Each customer.Orders access may trigger a separate query
```

**Eager loading** — related data loaded upfront with `.Include()`:

```csharp
var customers = await db.Customers
    .Include(x => x.Orders)
    .ThenInclude(x => x.Items)
    .ToListAsync();
```

Prefer explicit eager loading in APIs and services to avoid N+1 performance problems.

### Split Queries

When multiple `.Include()` calls join large tables, a single SQL query can produce a **cartesian explosion** (duplicate rows).

`AsSplitQuery()` runs separate SQL queries per included collection — often faster for graphs with multiple collections:

```csharp
var customers = await db.Customers
    .Include(x => x.Orders)
    .ThenInclude(x => x.Items)
    .AsSplitQuery()
    .ToListAsync();
```

### Compiled Queries

For hot-path queries executed repeatedly, compile once and reuse:

```csharp
private static readonly Func<AppDbContext, int, IAsyncEnumerable<Customer>> GetById =
    EF.CompileAsyncQuery((AppDbContext db, int id) =>
        db.Customers.AsNoTracking().Where(x => x.Id == id));
```

Avoids re-parsing LINQ expressions on every call.

### Pagination

Standard offset pagination:

```csharp
var page = await db.Customers
    .AsNoTracking()
    .OrderBy(x => x.Id)
    .Skip((pageNumber - 1) * pageSize)
    .Take(pageSize)
    .ToListAsync();
```

For very large datasets, consider **keyset pagination** (cursor-based) over deep `Skip` values.

### Capstone: Data Access Layer Lab (Exercise 31)

Builds a generic repository abstraction:

```text
IRepository<T>  →  EfRepository<T>  →  AppDbContext
```

Demonstrates separation of concerns — business logic depends on `IRepository<T>`, not EF Core directly.

---

## EF Core Best Practices

```text
Use async methods (ToListAsync, SaveChangesAsync) throughout
Dispose DbContext per unit of work (scoped in DI for web apps)
Use AsNoTracking for read-only queries
Eager-load related data explicitly with Include
Use AsSplitQuery for multi-collection graphs
Avoid loading entire tables — paginate and filter
Use compiled queries for frequently executed hot paths
Keep DbContext lifetime short — do not make it singleton
```

---

## Full Exercise Index

| # | Module | Exercise File | Menu |
| - | ------ | ------------- | ---- |
| 1 | Async | `Exercise01_ThreadingModel.cs` | Module 1 → 1 |
| 2 | Async | `Exercise02_TPLOrderProcessing.cs` | Module 1 → 2 |
| 3 | Async | `Exercise03_TaskVsThread.cs` | Module 1 → 3 |
| 4 | Async | `Exercise04_TaskScheduling.cs` | Module 1 → 4 |
| 5 | Async | `Exercise05_TaskChaining.cs` | Module 1 → 5 |
| 6 | Async | `Exercise06_ParallelProgramming.cs` | Module 1 → 6 |
| 7 | Async | `Exercise07_ParallelForEach.cs` | Module 1 → 7 |
| 8 | Async | `Exercise08_PLINQ.cs` | Module 1 → 8 |
| 9 | Async | `Exercise09_SyncOverAsync.cs` | Module 1 → 9 |
| 10 | Async | `Exercise10_AsyncStateMachine.cs` | Module 1 → 10 |
| 11 | Async | `Exercise11_ConfigureAwait.cs` | Module 1 → 11 |
| 12 | Async | `Exercise12_AsyncExceptions.cs` | Module 1 → 12 |
| 13 | Memory | `Exercise13_ManagedVsUnmanagedMemory.cs` | Module 2 → 1 |
| 14 | Memory | `Exercise14_ManagedHeapInternals.cs` | Module 2 → 2 |
| 15 | Memory | `Exercise15_GenerationalGC.cs` | Module 2 → 3 |
| 16 | Memory | `Exercise16_ObjectRoots.cs` | Module 2 → 4 |
| 17 | Memory | `Exercise17_WeakReferences.cs` | Module 2 → 5 |
| 18 | Memory | `Exercise18_IDisposablePattern.cs` | Module 2 → 6 |
| 19 | Memory | `Exercise19_DisposeVsFinalize.cs` | Module 2 → 7 |
| 20 | Memory | `Exercise20_UsingBlocks.cs` | Module 2 → 8 |
| 21 | Memory | `Exercise21_AsyncPipelinePerformance.cs` | Module 2 → 9 |
| 22 | EF Core | `Exercise22_EFCoreArchitecture.cs` | Module 3 → 1 |
| 23 | EF Core | `Exercise23_DatabaseFirst.cs` | Module 3 → 2 |
| 24 | EF Core | `Exercise24_CodeFirst.cs` | Module 3 → 3 |
| 25 | EF Core | `Exercise25_ChangeTracking.cs` | Module 3 → 4 |
| 26 | EF Core | `Exercise26_QueryOptimization.cs` | Module 3 → 5 |
| 27 | EF Core | `Exercise27_LazyVsEagerLoading.cs` | Module 3 → 6 |
| 28 | EF Core | `Exercise28_SplitQueries.cs` | Module 3 → 7 |
| 29 | EF Core | `Exercise29_CompiledQueries.cs` | Module 3 → 8 |
| 30 | EF Core | `Exercise30_Pagination.cs` | Module 3 → 9 |
| 31 | EF Core | `Exercise31_DataAccessLayerLab.cs` | Module 3 → 10 |

---

## Additional Resources

Trainer materials are in `AdvancedAsyncTraining/docs/`:

- `student-handout.md` — exercise instructions and reflection questions
- `trainer-answer-key.md` — expected outputs and discussion points
- `workshop-timing-plan-3-hours.md` — async module timing (extend for full-day delivery)
