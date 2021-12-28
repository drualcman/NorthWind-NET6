using NorthWind.Entities.Interfaces;
using NorthWind.Sales.DTOs.GetOrdersByDate;
using NorthWind.Sales.Ports.Common;
using NorthWind.Sales.Ports.GetOrdersByDate;
using NorthWind.Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Controllers
{
    /// <summary>
    /// controlador para consultar una orden por fecha
    /// </summary>
    public class GetOrdersByDateController : IGetOrdersByDateController
    {
        readonly IGetOrdersByDateInputPort InputPort;
        readonly IGetOrdersOutputPort OutputPort;
        /// <summary>
        /// contruir el controlador
        /// </summary>
        /// <param name="inputPort"></param>
        /// <param name="outputPort"></param>
        public GetOrdersByDateController(IGetOrdersByDateInputPort inputPort,
            IGetOrdersOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);
        /// <summary>
        /// ejecutar la consulta de una orden por fecha
        /// </summary>
        /// <param name="orderDate"></param>
        /// <returns></returns>
        public async Task<OrdersViewModel> GetOrdersByDate(DateTime orderDate)
        {
            await InputPort.Handle(new GetOrdersByDateDto { OrderDate = orderDate });
            return ((IPresenter<OrdersViewModel>)OutputPort).Content;
        }
    }

}
