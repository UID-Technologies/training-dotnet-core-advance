using System.Net;
using System.Net.Http.Json;
using AdvancedProductionTraining.Web.Controllers;
using FluentAssertions;

namespace AdvancedProductionTraining.Tests.Integration;

public sealed class OrdersApiIntegrationTests : IClassFixture<TrainingWebApplicationFactory>
{
    private readonly HttpClient _client;

    public OrdersApiIntegrationTests(TrainingWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task PostOrder_ReturnsCreated_WithValidPayload()
    {
        var response = await _client.PostAsJsonAsync("/api/orders", new CreateOrderRequest
        {
            CustomerName = "Integration Corp",
            Total = 500m,
            CustomerTier = "SILVER"
        });

        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var order = await response.Content.ReadFromJsonAsync<Core.Models.Order>();
        order!.CustomerName.Should().Be("Integration Corp");
        order.Total.Should().Be(450m);
    }

    [Fact]
    public async Task HealthEndpoint_ReturnsHealthy()
    {
        var response = await _client.GetAsync("/health");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
