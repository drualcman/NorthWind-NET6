using NorthWind.Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Controllers
{
    /// <summary>
    /// abstraccion para consultar una orden por fecha
    /// </summary>
    public interface IGetOrdersByDateController
    {
        /// <summary>
        /// ejecutar la consulta de una orden por fecha
        /// </summary>
        /// <param name="orderDate"></param>
        /// <returns></returns>
        public Task<OrdersViewModel> GetOrdersByDate(DateTime orderDate);
    }

}
