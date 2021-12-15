using NorthWind.Sales.DTOs.CreateOrder;
using NorthWind.Sales.Ports.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.UseCases.CreateOrder
{
    /// <summary>
    /// Este es el manejador que va a procesar la orden
    /// </summary>
    public class CreateOrderInteractor : ICreateOrderInputPort
    {
        readonly ICreateOrderOutPort OutputPort;
        readonly CreateOrderService Service;

        /// <summary>
        /// recibir el output port y el servicio para poder crear la orden y devolver los datos
        /// </summary>
        /// <param name="outputPort"></param>
        /// <param name="service"></param>
        public CreateOrderInteractor(ICreateOrderOutPort outputPort, CreateOrderService service)
        {
            OutputPort = outputPort;
            Service = service;
        }

        /// <summary>
        /// Manejar la creacion de la orden
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public ValueTask Handle(CreateOrderDto order)
        {
            Service.RunValidationGuard(order);
            var orderAgregate = Service.RunCreateOrderGuard(order);
            Service.RaiseEventIfSpecialOrder(orderAgregate);
            return OutputPort.Handle(orderAgregate.Id);
        }
    }
}
