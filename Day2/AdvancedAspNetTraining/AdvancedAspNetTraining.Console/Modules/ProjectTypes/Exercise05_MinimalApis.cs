using AdvancedAspNetTraining.Console.Shared;
using Microsoft.AspNetCore.Builder;

namespace AdvancedAspNetTraining.Console.Modules.ProjectTypes;

public static class Exercise05_MinimalApis
{
    public static Task RunAsync() =>
        ExerciseWebHostHelper.RunInteractiveHostAsync(
            _ => { },
            app =>
            {
                var orders = new List<OrderDto>
                {
                    new(1, "Contoso", 99.50m),
                    new(2, "Fabrikam", 250.00m)
                };

                app.MapGet("/api/orders", () => Results.Ok(orders));

                app.MapGet("/api/orders/{id:int}", (int id) =>
                {
                    var order = orders.FirstOrDefault(o => o.Id == id);
                    return order is null ? Results.NotFound() : Results.Ok(order);
                });

                app.MapPost("/api/orders", (OrderCreateDto dto) =>
                {
                    var newOrder = new OrderDto(orders.Count + 1, dto.Customer, dto.Total);
                    orders.Add(newOrder);
                    return Results.Created($"/api/orders/{newOrder.Id}", newOrder);
                });
            },
            "Exercise 5: Minimal APIs");

    private sealed record OrderDto(int Id, string Customer, decimal Total);
    private sealed record OrderCreateDto(string Customer, decimal Total);
}
