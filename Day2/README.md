# Advanced .NET Training — Day 2: ASP.NET Core & Enterprise Web APIs

## Overview

Day 2 builds on runtime fundamentals from Day 1 and focuses on **building production-ready HTTP services** with ASP.NET Core. Participants learn how requests flow through Kestrel and middleware, how to configure dependency injection and logging, and how to design and secure enterprise REST APIs.

| Module | Focus | Exercises |
| ------ | ----- | --------- |
| **1. ASP.NET Core Architecture & Middleware** | Runtime, project types, pipeline, DI, configuration | 19 |
| **2. Building Enterprise Web APIs** | REST design, controllers, Swagger, JWT security | 18 |

**Hands-on labs (capstone):**

- **Exercise 36** — Production-ready ASP.NET Core project structure (`AdvancedAspNetTraining.Web`)
- **Exercise 37** — Secure REST API with JWT authentication

---

## Getting Started

### Project Structure

```text
AdvancedAspNetTraining/
├── AdvancedAspNetTraining.sln
├── AdvancedAspNetTraining.Console/     ← Menu-driven exercises (like Day 1)
│   ├── Program.cs
│   └── Modules/
│       ├── AspNetCoreRuntime/          ← Exercises 1–4
│       ├── ProjectTypes/               ← Exercises 5–8
│       ├── MiddlewarePipeline/         ← Exercises 9–12
│       ├── DependencyInjection/        ← Exercises 13–16
│       ├── ConfigurationLogging/       ← Exercises 17–19
│       ├── RestApiDesign/              ← Exercises 20–23
│       ├── WebApiDevelopment/          ← Exercises 24–26
│       ├── ApiDocumentation/           ← Exercises 27–28
│       ├── ApiSecurity/                ← Exercises 29–31
│       ├── ApiSecurityBestPractices/   ← Exercises 32–35
│       └── Capstone/                   ← Exercises 36–37
└── AdvancedAspNetTraining.Web/       ← Production-ready capstone API
    ├── Program.cs
    ├── Controllers/
    ├── Middleware/
    ├── Auth/
    └── Services/
```

### Prerequisites

- .NET SDK 9.0+
- Visual Studio 2022 or VS Code
- REST client (Swagger UI, Postman, or `curl`)
- Day 1 recommended (async, configuration concepts)

### Running the Exercise Menu

```bash
cd Day2/AdvancedAspNetTraining
dotnet restore
dotnet build
dotnet run --project AdvancedAspNetTraining.Console
```

1. Select **module 1 or 2**.
2. Select an **exercise**.
3. For web exercises, a temporary Kestrel host starts — use the printed URL, then press **Enter** to stop.
4. For capstone labs (36–37), run the Web project separately (see below).

### Running the Capstone API

```bash
cd Day2/AdvancedAspNetTraining
dotnet run --project AdvancedAspNetTraining.Web --launch-profile CapstoneApi
```

Open **https://localhost:7150/swagger**

**Test users:**

| Username | Password | Roles | Permissions |
| -------- | -------- | ----- | ------------- |
| admin | Admin@123 | Admin | orders:read, orders:write |
| reader | Reader@123 | User | orders:read |
| writer | Writer@123 | User | orders:read, orders:write |

---

# Module 1: ASP.NET Core Architecture & Middleware

**Menu:** Main → `1`

## Section A — Runtime Architecture (Exercises 1–4)

| Menu | Exercise | Topic |
| ---- | -------- | ----- |
| 1 | Kestrel Server | Cross-platform web server, limits, health endpoint |
| 2 | Request Pipeline | Middleware order, before/after `next` |
| 3 | Hosting Models | In-process / out-of-process IIS, self-hosted Kestrel |
| 4 | IIS Integration | ANCM, `web.config`, reverse proxy concepts |

## Section B — Project Types (Exercises 5–8)

| Menu | Exercise | Topic |
| ---- | -------- | ----- |
| 5 | Minimal APIs | `MapGet` / `MapPost` lightweight endpoints |
| 6 | MVC Pattern | Model-View-Controller for server-rendered apps |
| 7 | Razor Pages | Page-focused UI pattern |
| 8 | Web API Project Types | Enterprise API folder layout |

## Section C — Middleware Pipeline (Exercises 9–12)

| Menu | Exercise | Topic |
| ---- | -------- | ----- |
| 9 | Middleware Architecture | Pipeline stages, response headers |
| 10 | Custom Middleware | `CustomHeaderMiddleware`, request items |
| 11 | Request/Response Processing | Timing header, echo POST body |
| 12 | Exception Middleware | Centralized error handling (`GET /fail`) |

## Section D — Dependency Injection (Exercises 13–16)

| Menu | Exercise | Topic |
| ---- | -------- | ----- |
| 13 | Built-in DI Container | Register and resolve services with scopes |
| 14 | Service Lifetimes | Transient, Scoped, Singleton theory |
| 15 | Lifetimes Comparison | Live instance identity demo |
| 16 | Advanced DI Patterns | Keyed services, factory registration |

## Section E — Configuration & Logging (Exercises 17–19)

| Menu | Exercise | Topic |
| ---- | -------- | ----- |
| 17 | Configuration Providers | JSON, environment, in-memory, command line |
| 18 | appsettings & Environment | `ASPNETCORE_ENVIRONMENT`, layered config |
| 19 | Structured Logging | `ILogger<T>` with semantic placeholders |

---

# Module 2: Building Enterprise Web APIs

**Menu:** Main → `2`

## Section A — REST API Design (Exercises 20–23)

| Menu | Exercise | Topic |
| ---- | -------- | ----- |
| 1 | REST Principles | Verbs, statelessness, uniform interface |
| 2 | Resource Modeling | Nouns, nested resources, DTOs |
| 3 | API Versioning | URL path versioning (`/api/v1`, `/api/v2`) |
| 4 | HATEOAS Concepts | Hypermedia links in responses |

## Section B — Web API Development (Exercises 24–26)

| Menu | Exercise | Topic |
| ---- | -------- | ----- |
| 5 | Controllers & Routing | `[ApiController]`, route templates |
| 6 | Model Binding | Query, route, header, body binding |
| 7 | Validation | Data annotations, `ValidationProblem` |

## Section C — API Documentation (Exercises 27–28)

| Menu | Exercise | Topic |
| ---- | -------- | ----- |
| 8 | Swagger / OpenAPI | Swashbuckle, interactive `/swagger` |
| 9 | API Documentation Standards | Enterprise documentation checklist |

## Section D — API Security (Exercises 29–31)

| Menu | Exercise | Topic |
| ---- | -------- | ----- |
| 10 | Authentication vs Authorization | Concepts and pipeline order |
| 11 | JWT Authentication | Login endpoint, Bearer token |
| 12 | Claims, Roles & Policies | Policy-based authorization demo |

## Section E — Security Best Practices (Exercises 32–35)

| Menu | Exercise | Topic |
| ---- | -------- | ----- |
| 13 | Secure Headers | `X-Content-Type-Options`, `X-Frame-Options`, etc. |
| 14 | Input Validation Security | Allow-list validation |
| 15 | Injection Prevention | SQL/command injection mitigation |
| 16 | Sensitive Data Protection | Secrets, HTTPS, DTOs |

## Capstone Labs (Exercises 36–37)

| Menu | Exercise | Topic |
| ---- | -------- | ----- |
| 17 | Production-Ready Project | Layered Web project walkthrough |
| 18 | Secure REST API with JWT | End-to-end lab with Swagger + policies |

---

## Full Exercise Index

| # | File | Module Menu |
| - | ---- | ----------- |
| 1 | `Exercise01_KestrelServer.cs` | 1 → 1 |
| 2 | `Exercise02_RequestPipeline.cs` | 1 → 2 |
| 3 | `Exercise03_HostingModels.cs` | 1 → 3 |
| 4 | `Exercise04_IisIntegration.cs` | 1 → 4 |
| 5 | `Exercise05_MinimalApis.cs` | 1 → 5 |
| 6 | `Exercise06_MvcPattern.cs` | 1 → 6 |
| 7 | `Exercise07_RazorPages.cs` | 1 → 7 |
| 8 | `Exercise08_WebApiProjectTypes.cs` | 1 → 8 |
| 9 | `Exercise09_MiddlewareArchitecture.cs` | 1 → 9 |
| 10 | `Exercise10_CustomMiddleware.cs` | 1 → 10 |
| 11 | `Exercise11_RequestResponseProcessing.cs` | 1 → 11 |
| 12 | `Exercise12_ExceptionMiddleware.cs` | 1 → 12 |
| 13 | `Exercise13_BuiltInDiContainer.cs` | 1 → 13 |
| 14 | `Exercise14_ServiceLifetimes.cs` | 1 → 14 |
| 15 | `Exercise15_LifetimesComparison.cs` | 1 → 15 |
| 16 | `Exercise16_AdvancedDiPatterns.cs` | 1 → 16 |
| 17 | `Exercise17_ConfigurationProviders.cs` | 1 → 17 |
| 18 | `Exercise18_AppSettingsEnvironment.cs` | 1 → 18 |
| 19 | `Exercise19_StructuredLogging.cs` | 1 → 19 |
| 20 | `Exercise20_RestPrinciples.cs` | 2 → 1 |
| 21 | `Exercise21_ResourceModeling.cs` | 2 → 2 |
| 22 | `Exercise22_ApiVersioning.cs` | 2 → 3 |
| 23 | `Exercise23_HateoasConcepts.cs` | 2 → 4 |
| 24 | `Exercise24_ControllersRouting.cs` | 2 → 5 |
| 25 | `Exercise25_ModelBinding.cs` | 2 → 6 |
| 26 | `Exercise26_Validation.cs` | 2 → 7 |
| 27 | `Exercise27_SwaggerOpenApi.cs` | 2 → 8 |
| 28 | `Exercise28_ApiDocumentationStandards.cs` | 2 → 9 |
| 29 | `Exercise29_AuthenticationVsAuthorization.cs` | 2 → 10 |
| 30 | `Exercise30_JwtAuthentication.cs` | 2 → 11 |
| 31 | `Exercise31_ClaimsRolePolicyAuthorization.cs` | 2 → 12 |
| 32 | `Exercise32_SecureHeaders.cs` | 2 → 13 |
| 33 | `Exercise33_InputValidationSecurity.cs` | 2 → 14 |
| 34 | `Exercise34_InjectionPrevention.cs` | 2 → 15 |
| 35 | `Exercise35_SensitiveDataProtection.cs` | 2 → 16 |
| 36 | `Exercise36_ProductionReadyProject.cs` | 2 → 17 |
| 37 | `Exercise37_SecureRestApiWithJwt.cs` | 2 → 18 |

---

## Recommended Learning Path

```text
Module 1 (sections A→E)  →  Module 2 (sections A→E)  →  Capstone Web API
```

Run exercises **36–37** after completing security exercises (29–35).
