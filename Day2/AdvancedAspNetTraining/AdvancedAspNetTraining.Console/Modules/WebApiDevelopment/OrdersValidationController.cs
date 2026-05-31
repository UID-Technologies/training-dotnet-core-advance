using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedAspNetTraining.Console.Modules.WebApiDevelopment;

[ApiController]
[Route("api/validation/[controller]")]
public sealed class OrdersValidationController : ControllerBase
{
    [HttpPost]
    public IActionResult Create([FromBody] ValidatedOrderRequest request)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        return Created(string.Empty, request);
    }
}

public sealed class ValidatedOrderRequest
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string CustomerName { get; set; } = string.Empty;

    [Range(0.01, 1_000_000)]
    public decimal Total { get; set; }

    [EmailAddress]
    public string? ContactEmail { get; set; }
}
