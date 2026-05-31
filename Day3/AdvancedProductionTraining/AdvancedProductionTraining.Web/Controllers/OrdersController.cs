using AdvancedProductionTraining.Core.Models;
using AdvancedProductionTraining.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace AdvancedProductionTraining.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
[EnableRateLimiting("fixed")]
public sealed class OrdersController : ControllerBase
{
    private readonly OrderService _orderService;

    public OrdersController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<ActionResult<Order>> Create([FromBody] CreateOrderRequest request, CancellationToken cancellationToken)
    {
        var order = await _orderService.PlaceOrderAsync(
            request.CustomerName,
            request.Total,
            request.CustomerTier ?? "BRONZE",
            cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Order>> GetById(int id, [FromServices] Core.Abstractions.IOrderRepository repository, CancellationToken cancellationToken)
    {
        var order = await repository.GetByIdAsync(id, cancellationToken);
        return order is null ? NotFound() : Ok(order);
    }

    [HttpPost("{id:int}/cancel")]
    public async Task<IActionResult> Cancel(int id, CancellationToken cancellationToken)
    {
        try
        {
            var cancelled = await _orderService.CancelOrderAsync(id, cancellationToken);
            return cancelled ? NoContent() : NotFound();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}

public sealed class CreateOrderRequest
{
    public string CustomerName { get; set; } = string.Empty;
    public decimal Total { get; set; }
    public string? CustomerTier { get; set; }
}
