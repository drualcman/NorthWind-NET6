using NorthWind.Entities.Interfaces;
using NorthWind.Sales.DTOs.CreateOrder;

namespace NorthWind.Sales.Ports.CreateOrder
{
    /// <summary>
    /// Abstraccion para la entrada de datos
    /// </summary>
    public interface ICreateOrderInputPort : IPort<CreateOrderDto>
    {
    }
}
