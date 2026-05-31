namespace AdvancedAspNetTraining.Web.Models;

public sealed class OrderResource
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public decimal Total { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}

public sealed class CreateOrderRequest
{
    public string CustomerName { get; set; } = string.Empty;
    public decimal Total { get; set; }
}

public sealed class UpdateOrderRequest
{
    public string Status { get; set; } = string.Empty;
}
