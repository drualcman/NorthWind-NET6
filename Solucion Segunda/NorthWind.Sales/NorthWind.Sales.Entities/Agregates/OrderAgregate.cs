using NorthWind.Sales.Entities.POCOEntities;
using NorthWind.Sales.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Entities.Agregates
{
    /// <summary>
    /// Agrupar la orden y el orden detail
    /// </summary>
    public class OrderAgregate : Order
    {
        readonly List<OrderDetail> OrderDetailsField = new List<OrderDetail>();

        /// <summary>
        /// La unica forma de acceder a los detalles de la orden is desde esta propiedad
        /// No se pueden manejar los detalles directamente
        /// </summary>
        public IReadOnlyCollection<OrderDetail> OrderDetails => OrderDetailsField;

        /// <summary>
        /// Agregar un producto a la orden
        /// </summary>
        /// <param name="orderDetail"></param>
        public void AddDetail(OrderDetail orderDetail)
        {
            //buscar si exsiste
            var existingOrderDetail =
                OrderDetailsField.FirstOrDefault(o => o.ProductId == orderDetail.ProductId);
            if (existingOrderDetail != null)
            {
                //so existe solo agregar la cantidad
                OrderDetailsField.Add(existingOrderDetail with
                {
                    Quantity = (short)(existingOrderDetail.Quantity + orderDetail.Quantity)
                });
                OrderDetailsField.Remove(existingOrderDetail);
            }
            else OrderDetailsField.Add(orderDetail);
        }

        /// <summary>
        /// Sobre carga para poder agregar el procuto directamente con los parametros
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="unitPrice"></param>
        /// <param name="quantity"></param>
        public void AddDetail(int productId, decimal unitPrice, short quantity) =>
            AddDetail(new OrderDetail(productId, unitPrice, quantity));
    }
}
