using AdvancedAspNetTraining.Console.Modules.ApiDocumentation;
using AdvancedAspNetTraining.Console.Modules.ApiSecurity;
using AdvancedAspNetTraining.Console.Modules.ApiSecurityBestPractices;
using AdvancedAspNetTraining.Console.Modules.AspNetCoreRuntime;
using AdvancedAspNetTraining.Console.Modules.Capstone;
using AdvancedAspNetTraining.Console.Modules.ConfigurationLogging;
using AdvancedAspNetTraining.Console.Modules.DependencyInjection;
using AdvancedAspNetTraining.Console.Modules.MiddlewarePipeline;
using AdvancedAspNetTraining.Console.Modules.ProjectTypes;
using AdvancedAspNetTraining.Console.Modules.RestApiDesign;
using AdvancedAspNetTraining.Console.Modules.WebApiDevelopment;

while (true)
{
    Console.Clear();
    Console.WriteLine("Advanced ASP.NET Core Training — Day 2");
    Console.WriteLine("======================================");
    Console.WriteLine();
    Console.WriteLine("Select a module:");
    Console.WriteLine("  1. ASP.NET Core Architecture & Middleware (19 exercises)");
    Console.WriteLine("  2. Building Enterprise Web APIs (18 exercises)");
    Console.WriteLine("  0. Exit");
    Console.WriteLine();
    Console.Write("Select module: ");

    switch (Console.ReadLine())
    {
        case "1":
            await RunArchitectureModuleAsync();
            break;
        case "2":
            await RunEnterpriseApiModuleAsync();
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

static async Task RunArchitectureModuleAsync()
{
    Console.Clear();
    Console.WriteLine("Module 1: ASP.NET Core Architecture & Middleware");
    Console.WriteLine("================================================");
    Console.WriteLine("  1. Kestrel Server");
    Console.WriteLine("  2. Request Pipeline");
    Console.WriteLine("  3. Hosting Models");
    Console.WriteLine("  4. IIS Integration");
    Console.WriteLine("  5. Minimal APIs");
    Console.WriteLine("  6. MVC Pattern");
    Console.WriteLine("  7. Razor Pages");
    Console.WriteLine("  8. Web API Project Types");
    Console.WriteLine("  9. Middleware Architecture");
    Console.WriteLine(" 10. Custom Middleware");
    Console.WriteLine(" 11. Request/Response Processing");
    Console.WriteLine(" 12. Exception Middleware");
    Console.WriteLine(" 13. Built-in DI Container");
    Console.WriteLine(" 14. Service Lifetimes");
    Console.WriteLine(" 15. Scoped vs Singleton vs Transient");
    Console.WriteLine(" 16. Advanced DI Patterns");
    Console.WriteLine(" 17. Configuration Providers");
    Console.WriteLine(" 18. appsettings & Environment");
    Console.WriteLine(" 19. Structured Logging");
    Console.WriteLine("  0. Back to main menu");
    Console.WriteLine();
    Console.Write("Select exercise: ");

    switch (Console.ReadLine())
    {
        case "1": await Exercise01_KestrelServer.RunAsync(); break;
        case "2": await Exercise02_RequestPipeline.RunAsync(); break;
        case "3": await Exercise03_HostingModels.RunAsync(); break;
        case "4": await Exercise04_IisIntegration.RunAsync(); break;
        case "5": await Exercise05_MinimalApis.RunAsync(); break;
        case "6": await Exercise06_MvcPattern.RunAsync(); break;
        case "7": await Exercise07_RazorPages.RunAsync(); break;
        case "8": await Exercise08_WebApiProjectTypes.RunAsync(); break;
        case "9": await Exercise09_MiddlewareArchitecture.RunAsync(); break;
        case "10": await Exercise10_CustomMiddleware.RunAsync(); break;
        case "11": await Exercise11_RequestResponseProcessing.RunAsync(); break;
        case "12": await Exercise12_ExceptionMiddleware.RunAsync(); break;
        case "13": await Exercise13_BuiltInDiContainer.RunAsync(); break;
        case "14": await Exercise14_ServiceLifetimes.RunAsync(); break;
        case "15": await Exercise15_LifetimesComparison.RunAsync(); break;
        case "16": await Exercise16_AdvancedDiPatterns.RunAsync(); break;
        case "17": await Exercise17_ConfigurationProviders.RunAsync(); break;
        case "18": await Exercise18_AppSettingsEnvironment.RunAsync(); break;
        case "19": await Exercise19_StructuredLogging.RunAsync(); break;
        case "0": return;
        default: Console.WriteLine("Invalid exercise selected."); break;
    }

    Console.WriteLine();
    Console.WriteLine("Press Enter to return to main menu...");
    Console.ReadLine();
}

static async Task RunEnterpriseApiModuleAsync()
{
    Console.Clear();
    Console.WriteLine("Module 2: Building Enterprise Web APIs");
    Console.WriteLine("======================================");
    Console.WriteLine("  1. REST Principles");
    Console.WriteLine("  2. Resource Modeling");
    Console.WriteLine("  3. API Versioning");
    Console.WriteLine("  4. HATEOAS Concepts");
    Console.WriteLine("  5. Controllers & Routing");
    Console.WriteLine("  6. Model Binding");
    Console.WriteLine("  7. Validation");
    Console.WriteLine("  8. Swagger / OpenAPI");
    Console.WriteLine("  9. API Documentation Standards");
    Console.WriteLine(" 10. Authentication vs Authorization");
    Console.WriteLine(" 11. JWT Authentication");
    Console.WriteLine(" 12. Claims, Roles & Policies");
    Console.WriteLine(" 13. Secure Headers");
    Console.WriteLine(" 14. Input Validation Security");
    Console.WriteLine(" 15. Injection Prevention");
    Console.WriteLine(" 16. Sensitive Data Protection");
    Console.WriteLine(" 17. Lab: Production-Ready Project");
    Console.WriteLine(" 18. Lab: Secure REST API with JWT");
    Console.WriteLine("  0. Back to main menu");
    Console.WriteLine();
    Console.Write("Select exercise: ");

    switch (Console.ReadLine())
    {
        case "1": await Exercise20_RestPrinciples.RunAsync(); break;
        case "2": await Exercise21_ResourceModeling.RunAsync(); break;
        case "3": await Exercise22_ApiVersioning.RunAsync(); break;
        case "4": await Exercise23_HateoasConcepts.RunAsync(); break;
        case "5": await Exercise24_ControllersRouting.RunAsync(); break;
        case "6": await Exercise25_ModelBinding.RunAsync(); break;
        case "7": await Exercise26_Validation.RunAsync(); break;
        case "8": await Exercise27_SwaggerOpenApi.RunAsync(); break;
        case "9": await Exercise28_ApiDocumentationStandards.RunAsync(); break;
        case "10": await Exercise29_AuthenticationVsAuthorization.RunAsync(); break;
        case "11": await Exercise30_JwtAuthentication.RunAsync(); break;
        case "12": await Exercise31_ClaimsRolePolicyAuthorization.RunAsync(); break;
        case "13": await Exercise32_SecureHeaders.RunAsync(); break;
        case "14": await Exercise33_InputValidationSecurity.RunAsync(); break;
        case "15": await Exercise34_InjectionPrevention.RunAsync(); break;
        case "16": await Exercise35_SensitiveDataProtection.RunAsync(); break;
        case "17": await Exercise36_ProductionReadyProject.RunAsync(); break;
        case "18": await Exercise37_SecureRestApiWithJwt.RunAsync(); break;
        case "0": return;
        default: Console.WriteLine("Invalid exercise selected."); break;
    }

    Console.WriteLine();
    Console.WriteLine("Press Enter to return to main menu...");
    Console.ReadLine();
}
