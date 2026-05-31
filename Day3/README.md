# Advanced .NET Training — Day 3: Testing, Performance & Production Readiness

## Overview

Day 3 completes the advanced .NET curriculum with **quality engineering** and **operational readiness**. Participants write unit and integration tests, measure performance, validate API security, and implement observability patterns used in production systems.

| Module | Focus | Exercises |
| ------ | ----- | --------- |
| **1. Unit Testing** | xUnit, AAA, Moq, FluentAssertions, fixtures, DI testing | 10 |
| **2. Integration Testing** | WebApplicationFactory, in-memory server, test DB | 6 |
| **3. API Performance Testing** | BenchmarkDotNet, k6, load/stress strategies | 7 |
| **4. API Security Testing** | OWASP, rate limiting, security tools | 7 |
| **5. Observability & Monitoring** | Serilog, health checks, OpenTelemetry | 7 |
| **Capstone** | Production readiness checklist | 1 |

**Total: 38 exercises** + real test projects you run with `dotnet test`.

---

## Solution Structure

```text
AdvancedProductionTraining/
├── AdvancedProductionTraining.sln
├── AdvancedProductionTraining.Core/          ← Business services (unit test target)
├── AdvancedProductionTraining.Web/           ← API: Serilog, OTel, rate limit, health
├── AdvancedProductionTraining.Tests/         ← xUnit + Moq + FluentAssertions
├── AdvancedProductionTraining.Benchmarks/    ← BenchmarkDotNet
├── AdvancedProductionTraining.Console/       ← Menu-driven exercises
└── Scripts/k6-load-test.js                   ← Load test script
```

---

## Getting Started

### Prerequisites

- .NET SDK 9.0+
- (Optional) [k6](https://k6.io/) for load testing lab
- (Optional) OWASP ZAP / Postman for security lab
- Days 1–2 recommended

### Exercise Menu

```bash
cd Day3/AdvancedProductionTraining
dotnet restore
dotnet build
dotnet run --project AdvancedProductionTraining.Console
```

### Run All Tests

```bash
dotnet test
```

### Run Production API

```bash
dotnet run --project AdvancedProductionTraining.Web --launch-profile ProductionApi
```

Endpoints:

- Swagger: `https://localhost:7250/swagger`
- Health: `GET /health`, `GET /health/ready`
- Orders: `POST /api/orders`, `GET /api/orders/{id}`

### Load Test (k6)

```bash
# Terminal 1 — start API
dotnet run --project AdvancedProductionTraining.Web

# Terminal 2 — run load test
k6 run Scripts/k6-load-test.js
k6 run -e API_URL=http://localhost:5250 Scripts/k6-load-test.js
```

### Benchmarks

```bash
dotnet run -c Release --project AdvancedProductionTraining.Benchmarks
```

---

# Module 1: Unit Testing in .NET

**Menu:** Main → `1`

| Menu | Exercise | Topic |
| ---- | -------- | ----- |
| 1 | xUnit Introduction | Facts, theories, test project layout |
| 2 | Arrange Act Assert | AAA pattern walkthrough |
| 3 | Writing Unit Tests | Runs `PricingServiceTests` |
| 4 | Moq Basics | Setup, verify, `It.IsAny` |
| 5 | Mocking Dependencies | Runs `OrderServiceTests` |
| 6 | DI Testing | `ServiceCollection` resolution test |
| 7 | Test Fixtures | `IClassFixture<OrderServiceFixture>` |
| 8 | FluentAssertions | Readable assertion style |
| 9 | xUnit vs NUnit vs MSTest | Framework comparison |
| 10 | **Lab** | All unit tests in `Tests/Unit` |

**Test files:** `Tests/Unit/PricingServiceTests.cs`, `OrderServiceTests.cs`, `OrderServiceFixtureTests.cs`, `OrderServiceDiTests.cs`

---

# Module 2: Integration Testing

**Menu:** Main → `2`

| Menu | Exercise | Topic |
| ---- | -------- | ----- |
| 1 | Integration vs Unit | Test pyramid |
| 2 | WebApplicationFactory | Replace services for tests |
| 3 | In-Memory Test Server | `CreateClient()` |
| 4 | Testing ASP.NET Core APIs | `PostAsJsonAsync`, status codes |
| 5 | Test Database Setup | SQLite `:memory:` |
| 6 | **Lab** | Runs integration tests |

**Test files:** `Tests/Integration/TrainingWebApplicationFactory.cs`, `OrdersApiIntegrationTests.cs`

---

# Module 3: API Performance Testing

**Menu:** Main → `3`

| Menu | Exercise | Topic |
| ---- | -------- | ----- |
| 1 | Performance Bottlenecks | Common API issues |
| 2 | Load Testing Strategies | Smoke, load, stress, soak |
| 3 | Stress Testing | Breaking point, 429 behavior |
| 4 | BenchmarkDotNet | Micro-benchmarks |
| 5 | Benchmark Lab | Runs BenchmarkDotNet project |
| 6 | Latency & Throughput | p95, RPS, error rate |
| 7 | **Lab** | k6 script against Web API |

**Tools covered:** BenchmarkDotNet, k6 (script included), JMeter, Postman runner (conceptual)

---

# Module 4: API Security Testing

**Menu:** Main → `4`

| Menu | Exercise | Topic |
| ---- | -------- | ----- |
| 1 | OWASP API Top 10 | Overview |
| 2 | Authentication Attacks | Brute force, token issues |
| 3 | Injection Attacks | SQL/XSS payloads |
| 4 | Rate Limiting | 30 req/min per IP (built into API) |
| 5 | API Throttling | Gateway vs in-app limits |
| 6 | Security Tools | ZAP, Burp, Postman |
| 7 | **Lab** | Hands-on security checklist |

---

# Module 5: Observability & Monitoring

**Menu:** Main → `5`

| Menu | Exercise | Topic |
| ---- | -------- | ----- |
| 1 | Logging Strategies | Levels, centralization |
| 2 | Serilog | `UseSerilog`, request logging |
| 3 | Structured Logging | Templates + correlation scope |
| 4 | Health Checks | `/health`, `/health/ready` |
| 5 | OpenTelemetry | Traces to console |
| 6 | Distributed Tracing | W3C trace context |
| 7 | Application Insights | Azure Monitor integration |
| 8 | **Production Capstone** | Full readiness checklist |

**Built into Web API:** Serilog, OpenTelemetry ASP.NET Core instrumentation, `CorrelationIdMiddleware`, EF Core health check.

---

## Full Exercise Index

| # | File | Module → Menu |
| - | ---- | ------------- |
| 1–10 | `Exercise01` – `Exercise10` | Unit Testing → 1–10 |
| 11–16 | `Exercise11` – `Exercise16` | Integration → 1–6 |
| 17–23 | `Exercise17` – `Exercise23` | Performance → 1–7 |
| 24–30 | `Exercise24` – `Exercise30` | Security → 1–7 |
| 31–38 | `Exercise31` – `Exercise38` | Observability → 1–8 |

---

## 3-Day Course Path

```text
Day 1 — Async, memory, EF Core
Day 2 — ASP.NET Core architecture & enterprise Web APIs
Day 3 — Testing, performance, security, observability (this day)
```

**Capstone flow:** Build API (Day 2) → Test it (Day 3 Modules 1–2) → Load & secure it (Modules 3–4) → Operate it (Module 5).
