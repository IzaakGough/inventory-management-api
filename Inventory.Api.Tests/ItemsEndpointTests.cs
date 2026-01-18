using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace Inventory.Api.Tests
{

    public class ItemsEndpointTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public ItemsEndpointTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Post_then_GetById_returns_created_item()
        {
            // Arrange
            var createRequest = new
            {
                sku = "SKU-TEST-001",
                name = "Test Item",
                quantity = 5,
                location = "A1",
            };

            // Act: create
            var postResponse = await _client.PostAsJsonAsync("/api/items", createRequest);

            // Assert: created
            Assert.Equal(HttpStatusCode.Created, postResponse.StatusCode);

            var created = await postResponse.Content.ReadFromJsonAsync<ItemResponse>();

            Assert.NotNull(created);
            Assert.NotEqual(Guid.Empty, created.Id);

            // Act: fetch by id
            var getResponse = await _client.GetAsync($"/api/items/{created.Id}");
            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

            var fetched = await getResponse.Content.ReadFromJsonAsync<ItemResponse>();

            Assert.Equal("SKU-TEST-001", fetched!.Sku);
            Assert.Equal("Test Item", fetched.Name);
            Assert.Equal(5, fetched.Quantity);
            Assert.Equal("A1", fetched.Location);

        }

        private sealed class ItemResponse
        {
            public Guid Id { get; set; }
            public string Sku { get; set; } = "";
            public string Name { get; set; } = "";
            public int Quantity { get; set; }
            public string? Location { get; set; }
        }
    }

}
 

