namespace NorthWind.Sales.DTOs.Common
{
    /// <summary>
    /// Representa un detalle de una orden
    /// </summary>
    public class OrderDetailDto
    {
        /// <summary>
        /// product id
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// nombre dle producto
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// precio
        /// </summary>
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// cantidad
        /// </summary>
        public short Quantity { get; set; }
    }
}
