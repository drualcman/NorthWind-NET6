using NorthWind.Entities.Interfaces;
using NorthWind.Sales.DTOs.GetOrdersByDate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Ports.GetOrdersByDate
{
    /// <summary>
    /// consultar una order por fecha
    /// </summary>
    public interface IGetOrdersByDateInputPort : IPort<GetOrdersByDateDto>
    {
    }
}
