namespace AdvancedAsyncTraining.Console.Modules.EntityFrameworkCore.EfCoreModels;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
