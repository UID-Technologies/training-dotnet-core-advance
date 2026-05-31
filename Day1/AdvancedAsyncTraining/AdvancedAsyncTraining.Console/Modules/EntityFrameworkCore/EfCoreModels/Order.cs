namespace AdvancedAsyncTraining.Console.Modules.EntityFrameworkCore.EfCoreModels;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }

    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
}
