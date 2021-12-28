using NorthWind.Sales.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.ViewModels
{
    /// <summary>
    /// obtener la orden
    /// </summary>
    public class OrdersViewModel
    {
        /// <summary>
        /// contener la orden
        /// </summary>
        public IEnumerable<OrderDto> Orders { get; }
        /// <summary>
        /// contruir la orden
        /// </summary>
        /// <param name="orders"></param>
        public OrdersViewModel(IEnumerable<OrderDto> orders) =>
            Orders = orders;
    }

}
