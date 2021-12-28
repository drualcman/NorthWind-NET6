using NorthWind.Sales.DTOs.CreateOrder;
using System.Net.Http.Json;
using System.Text.Json;

namespace NorthWind.Sales.WebApiGateway
{
    public class NorthwindApiClient
    {
        const string CreateOrderEndpoint = "create";
        readonly HttpClient Client;

        public NorthwindApiClient(HttpClient client)
        {
            Client = client;
        }

        public async Task<int> CreateOrderAsync(CreateOrderDto order)
        {
            int orderId = 0;
            var response = await Client.PostAsJsonAsync(CreateOrderEndpoint, order);
            if (response.IsSuccessStatusCode)
            {
                orderId = await response.Content.ReadFromJsonAsync<int>();
            }
            else
            {
                var jsonResponse = await response.Content.ReadFromJsonAsync<JsonElement>();
                throw new ProblemDetailsException(jsonResponse);
            }
            return orderId;
        }
    }
}