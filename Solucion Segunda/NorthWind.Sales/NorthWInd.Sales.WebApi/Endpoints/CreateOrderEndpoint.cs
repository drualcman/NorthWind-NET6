using NorthWind.Sales.Controllers;
using NorthWind.Sales.DTOs.CreateOrder;

namespace NorthWInd.Sales.WebApi.Endpoints
{
    public class CreateOrderEndpoint
    {
        public async Task<IResult> CreateOrder(CreateOrderDto order, 
            ICreateOrderController controller)
        {
            var createOrderViewModel = await controller.CreateOrder(order);
            return Results.Ok(createOrderViewModel.OrderId);
        }
    }
}
