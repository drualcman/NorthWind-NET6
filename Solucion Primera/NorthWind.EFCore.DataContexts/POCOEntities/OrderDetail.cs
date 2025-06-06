﻿using NorthWind.Sales.Entities.POCOEntities;

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
        public int ProductId { get; set; }
        /// <summary>
        /// precio del product
        /// </summary>
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// cantidad ordenada
        /// </summary>
        public short Quantity { get; set; }
    }
}
