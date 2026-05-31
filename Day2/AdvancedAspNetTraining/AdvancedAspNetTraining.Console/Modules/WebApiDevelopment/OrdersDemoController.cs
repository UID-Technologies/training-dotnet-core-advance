using Microsoft.AspNetCore.Mvc;

namespace AdvancedAspNetTraining.Console.Modules.WebApiDevelopment;

[ApiController]
[Route("api/demo/[controller]")]
public sealed class OrdersDemoController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() =>
        Ok(new[] { new { Id = 1, Customer = "Contoso" }, new { Id = 2, Customer = "Fabrikam" } });

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id) =>
        Ok(new { Id = id, Customer = "Sample" });

    [HttpGet("search")]
    public IActionResult Search([FromQuery] string status) =>
        Ok(new { status, results = 2 });
}
