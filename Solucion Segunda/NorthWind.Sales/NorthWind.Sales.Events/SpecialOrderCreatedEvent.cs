using NorthWind.Entities.Interfaces.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Events
{
    /// <summary>
    /// Implementacion del evento para enviar una notificacion
    /// Esto es como un EventArgs en un evento de WindowsForm
    /// </summary>
    public class SpecialOrderCreatedEvent : IDomainEvent
    {
        /// <summary>
        /// Identificador de la orden creada
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// Cuenta de los productos de la order
        /// </summary>
        public int ProductsCount { get; set; }

        /// <summary>
        /// Constructor para la creacion del evento
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="productsCount"></param>
        public SpecialOrderCreatedEvent(int orderId, int productsCount)
        {
            OrderId = orderId;
            ProductsCount = productsCount;
        }
    }
}
