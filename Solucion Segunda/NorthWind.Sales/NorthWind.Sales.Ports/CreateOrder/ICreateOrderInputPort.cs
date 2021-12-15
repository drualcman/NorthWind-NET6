using NorthWind.Entities.Interfaces;
using NorthWind.Sales.DTOs.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Ports.CreateOrder
{
    /// <summary>
    /// Abstraccion para la entrada de datos
    /// </summary>
    public interface ICreateOrderInputPort : IPort<CreateOrderDto>
    {
    }
}
