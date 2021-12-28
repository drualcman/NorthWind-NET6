using NorthWind.Sales.Controllers;

namespace NorthWInd.Sales.WebApi.Endpoints
{
    public class GetOrdersByDateEndpoint
    {
        public async Task<IResult> GetOrdersByDate(DateTime orderDate,IGetOrdersByDateController controller)
        {
            var GetOrdersByDateViewModel = await controller.GetOrdersByDate(orderDate);
            return Results.Ok(GetOrdersByDateViewModel.Orders);
        }
    }

}
