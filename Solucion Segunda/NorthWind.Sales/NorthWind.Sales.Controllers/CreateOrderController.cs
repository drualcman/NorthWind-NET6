using NorthWind.Entities.Interfaces;
using NorthWind.Sales.DTOs.CreateOrder;
using NorthWind.Sales.Ports.CreateOrder;
using NorthWind.Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Controllers
{
    /// <summary>
    /// implementacion de crear orden
    /// </summary>
    public class CreateOrderController : ICreateOrderController
    {
        readonly ICreateOrderInputPort InputPort;
        readonly ICreateOrderOutPort OutPort;

        /// <summary>
        /// inicializacion del controllador
        /// </summary>
        /// <param name="inputPort"></param>
        /// <param name="outPort"></param>
        public CreateOrderController(ICreateOrderInputPort inputPort, ICreateOrderOutPort outPort)
        {
            InputPort = inputPort;
            OutPort = outPort;
        }

        /// <summary>
        /// crear la orden
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async ValueTask<CreateOrderViewModel> CreateOrder(CreateOrderDto order)
        {
            await InputPort.Handle(order);
            return ((IPresenter<CreateOrderViewModel>)OutPort).Content;
        }
    }
}
