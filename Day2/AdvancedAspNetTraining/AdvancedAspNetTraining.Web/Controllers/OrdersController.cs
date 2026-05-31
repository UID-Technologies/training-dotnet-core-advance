using AdvancedAspNetTraining.Web.Models;
using AdvancedAspNetTraining.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedAspNetTraining.Web.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public sealed class OrdersController : ControllerBase
{
    private readonly IOrderStore _store;

    public OrdersController(IOrderStore store)
    {
        _store = store;
    }

    [HttpGet]
    [Authorize(Policy = "OrdersRead")]
    public async Task<ActionResult<IReadOnlyList<OrderResource>>> GetAll()
    {
        var orders = await _store.GetAllAsync();
        return Ok(orders);
    }

    [HttpGet("{id:int}")]
    [Authorize(Policy = "OrdersRead")]
    public async Task<ActionResult<OrderResource>> GetById(int id)
    {
        var order = await _store.GetByIdAsync(id);
        return order is null ? NotFound() : Ok(order);
    }

    [HttpPost]
    [Authorize(Policy = "OrdersWrite")]
    public async Task<ActionResult<OrderResource>> Create([FromBody] CreateOrderRequest request)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var created = await _store.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    [Authorize(Policy = "OrdersWrite")]
    public async Task<ActionResult<OrderResource>> Update(int id, [FromBody] UpdateOrderRequest request)
    {
        var updated = await _store.UpdateAsync(id, request);
        return updated is null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id:int}")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _store.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
