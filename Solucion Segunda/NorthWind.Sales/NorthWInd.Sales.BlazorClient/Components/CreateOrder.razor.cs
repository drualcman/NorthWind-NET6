using Microsoft.AspNetCore.Components;
using NorthWind.Sales.DTOs.CreateOrder;
using NorthWind.Sales.WebApiGateway;

namespace NorthWInd.Sales.BlazorClient.Components
{
    public partial class CreateOrder
    {
        [Inject]
        public NorthwindApiClient Client { get; set; }

        [Parameter]
        public CreateOrderDto Order { get; set; }

        string Message;

        void AddNewOrderDetailItem()
        {
            Order.OrderDetails.Add(new CreateOrderDetailDto());
        }

        async Task Send()
        {
            Message = "";
            var orderId = await Client.CreateOrderAsync(Order);
            Message = $"Orden {orderId} creada.";
        }
    }
}
