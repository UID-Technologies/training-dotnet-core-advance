# Advanced C# / .NET Training Content

| | |
|---|---|
| **Duration** | 3 Days (24 Hours) |
| **Target Audience** | Intermediate to advanced .NET developers; backend API developers; software engineers building enterprise systems |

## Prerequisites

- Experience with C#
- Knowledge of OOP
- Basic ASP.NET Core understanding
- SQL Server basics

---

## Day 1: Advanced C# and Asynchronous Programming

### Asynchronous Programming Deep Dive

- Threading model in .NET
- Task Parallel Library (TPL)
- Task vs Thread
- Task scheduling
- Task chaining
- Parallel programming
- Parallel.For / Parallel.ForEach
- Parallel LINQ (PLINQ)

### Async/Await Internals

- Synchronization context
- Async state machines
- ConfigureAwait
- Handling async exceptions
- Best practices for async programming

### Advanced Memory Management

- Managed vs unmanaged memory
- Managed heap internals
- Generational garbage collection
- GC algorithm
- Object roots
- Weak references
- IDisposable pattern
- Dispose vs Finalize
- Using blocks
- Performance considerations

**Hands-on Lab**

- Build async data processing pipeline
- Measure async performance

### Entity Framework Core Advanced

#### EF Core Architecture

- ORM fundamentals
- EF Core pipeline
- Change tracking
- DbContext lifecycle
- LINQ translation

#### Database First Approach

- Reverse engineering database
- Scaffold-DbContext
- Working with existing databases
- Updating models

#### Code First Approach

- Designing entity models
- Fluent API configuration
- Migrations
- Database creation

#### CRUD and Query Optimization

- Tracking vs NoTracking
- Lazy loading vs eager loading
- Split queries
- Compiled queries
- Bulk operations

#### EF Core Performance Optimization

- Query optimization
- N+1 query problem
- Index strategies
- Pagination techniques

**Hands-on Lab**

- Build Data Access Layer using EF Core

**Lab folder:** `Day1/`

---

## Day 2: ASP.NET Core Architecture and Middleware

### ASP.NET Core Runtime Architecture

- Kestrel server
- IIS integration
- Request pipeline
- Hosting models

### ASP.NET Core Project Types

- Minimal APIs
- MVC
- Razor Pages
- Web APIs

### Middleware Pipeline

- Middleware architecture
- Creating custom middleware
- Request/response processing
- Exception middleware

### Dependency Injection

- Built-in DI container
- Service lifetimes
- Scoped vs Singleton vs Transient
- Advanced DI patterns

### Configuration & Logging

- Configuration providers
- appsettings.json
- Environment configuration
- Logging providers
- Structured logging

**Hands-on Lab**

- Create production-ready ASP.NET Core project

### Building Enterprise Web APIs

#### REST API Design

- REST principles
- Resource modeling
- API versioning
- HATEOAS concepts

#### ASP.NET Core Web API Development

- Controllers
- Routing strategies
- Model binding
- Validation

#### API Documentation

- Swagger / OpenAPI
- API documentation standards

#### API Security

- Authentication vs Authorization
- JWT tokens
- Claims-based authorization
- Role-based authorization
- Policy-based authorization

#### API Security Best Practices

- Secure headers
- Input validation
- Preventing injection attacks
- Protecting sensitive data

**Hands-on Lab**

- Build secure REST API with JWT authentication

**Lab folder:** `Day2/`

---

## Day 3: Testing, Performance, and Production Readiness

### Unit Testing in .NET

**Frameworks:** xUnit / NUnit / MSTest

**Topics**

- Writing unit tests
- Arrange / Act / Assert pattern
- Mocking dependencies
- Dependency injection testing
- Test fixtures

**Tools**

- Moq
- FluentAssertions

**Lab:** Write unit tests for business services

### Integration Testing

**Topics**

- Integration vs unit testing
- Testing ASP.NET Core APIs
- WebApplicationFactory
- In-memory test server
- Test database setup

**Lab:** Test complete API endpoints

### API Performance Testing

**Topics**

- Performance bottlenecks
- Load testing strategies
- Stress testing
- Benchmarking

**Tools**

- k6
- Apache JMeter
- Postman load runner
- BenchmarkDotNet

**Metrics**

- Latency
- Throughput
- Error rate

**Lab:** Run load test on Web API

### API Security Testing

**Topics**

- OWASP Top 10
- Authentication attacks
- Injection attacks
- Rate limiting
- API throttling

**Tools**

- OWASP ZAP
- Burp Suite
- Postman security testing

### Observability and Monitoring

**Topics**

- Logging strategies
- Structured logging
- Distributed tracing
- Health checks

**Tools**

- Serilog
- Application Insights
- OpenTelemetry

**Lab folder:** `Day3/`

---

## Final Capstone Project

**Build Production-ready ASP.NET Core API**

**Features**

- EF Core
- Authentication (JWT)
- Logging
- Unit tests
- Integration tests
- Performance test

---

## Repository Map

| Day | Folder | Solution |
|-----|--------|----------|
| 1 | `Day1/` | `AdvancedAsyncTraining` |
| 2 | `Day2/` | `AdvancedAspNetTraining` |
| 3 | `Day3/` | `AdvancedProductionTraining` |
