using NorthWind.Sales.DTOs.CreateOrder;
using NorthWind.Sales.ViewModels;

namespace NorthWind.Sales.Controllers
{
    /// <summary>
    /// abstraccion para poder injectar facilmente el controllador
    /// </summary>
    public interface ICreateOrderController
    {
        ValueTask<CreateOrderViewModel> CreateOrder(CreateOrderDto order);
    }
}