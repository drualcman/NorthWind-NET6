using NorthWind.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Ports.CreateOrder
{
    /// <summary>
    /// Abstraccion para la devolucion de datos
    /// </summary>
    public interface ICreateOrderOutPort : IPort<int>
    {
    }
}
