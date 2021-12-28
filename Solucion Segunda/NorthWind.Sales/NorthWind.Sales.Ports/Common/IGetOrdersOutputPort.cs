using NorthWind.Entities.Interfaces;
using NorthWind.Sales.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Ports.Common
{
    /// <summary>
    /// Salida con la orden
    /// </summary>
    public interface IGetOrdersOutputPort : IPort<IEnumerable<OrderDto>>
    {
    }
}
