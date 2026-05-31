namespace AdvancedAsyncTraining.Console.Modules.EntityFrameworkCore.EfCoreModels;

public class Customer
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
