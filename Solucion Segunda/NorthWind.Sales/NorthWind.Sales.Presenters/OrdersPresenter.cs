using NorthWind.Entities.Interfaces;
using NorthWind.Sales.DTOs.Common;
using NorthWind.Sales.Ports.Common;
using NorthWind.Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Presenters
{
    /// <summary>
    /// devolver la orden
    /// </summary>
    public class OrdersPresenter :
        IGetOrdersOutputPort, IPresenter<OrdersViewModel>
    {
        /// <summary>
        /// orden consultada
        /// </summary>
        public OrdersViewModel Content { get; private set; }

        /// <summary>
        /// Manejar el contenido
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public ValueTask Handle(IEnumerable<OrderDto> orders)
        {
            Content = new OrdersViewModel(orders);
            return ValueTask.CompletedTask;
        }
    }

}
