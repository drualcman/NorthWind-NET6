using NorthWind.Sales.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.EFCore.DataContexts.POCOEntities
{
    /// <summary>
    /// Esta entidad es para poder manejar la base de datos.
    /// Esta entidad es para la tabla de detalle de la orden
    /// </summary>
    public class OrderDetail
    {
        /// <summary>
        /// OrderId relacionado
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// Order relacionada
        /// </summary>
        public Order? Order { get; set; }
        /// <summary>
        /// producto seleccionado
        /// </summary>
        public int ProductId { get; }
        /// <summary>
        /// precio del product
        /// </summary>
        public decimal UnitPrice { get; }
        /// <summary>
        /// cantidad ordenada
        /// </summary>
        public short Quantity { get; }
    }
}
