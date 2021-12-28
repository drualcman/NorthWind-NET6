/// <summary>
/// DTOs para crear la orden
/// </summary>
namespace NorthWind.Sales.DTOs.CreateOrder
{
    /// <summary>
    /// Detalle de la orden
    /// </summary>
    public class CreateOrderDetailDto
    {
        /// <summary>
        /// Identificador del producto
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Precio
        /// </summary>
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// Cantidad
        /// </summary>
        public short Quantity { get; set; }
    }
}
