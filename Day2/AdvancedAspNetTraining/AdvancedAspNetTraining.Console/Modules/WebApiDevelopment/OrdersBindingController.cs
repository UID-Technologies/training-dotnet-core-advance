using Microsoft.AspNetCore.Mvc;

namespace AdvancedAspNetTraining.Console.Modules.WebApiDevelopment;

[ApiController]
[Route("api/binding/[controller]")]
public sealed class OrdersBindingController : ControllerBase
{
    [HttpGet]
    public IActionResult FromQuery([FromQuery] string status, [FromQuery] int page = 1) =>
        Ok(new { source = "query", status, page });

    [HttpPost]
    public IActionResult FromBody([FromBody] CreateOrderBindingModel model) =>
        Ok(new { source = "body", model });

    [HttpGet("{id:int}")]
    public IActionResult FromRoute([FromRoute] int id, [FromHeader(Name = "X-Correlation-Id")] string? correlationId) =>
        Ok(new { source = "route+header", id, correlationId });
}

public sealed class CreateOrderBindingModel
{
    public string CustomerName { get; set; } = string.Empty;
    public decimal Total { get; set; }
}
