namespace NorthWind.Sales.DTOs.Common
{
    /// <summary>
    /// representa el una orden
    /// </summary>
    public class OrderDto
    {
        /// <summary>
        /// numero de orden
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// identificador del cliente
        /// </summary>
        public string CustomerId { get; set; }
        /// <summary>
        /// nombre del cliente
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// fecha de la orden
        /// </summary>
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// direccion
        /// </summary>
        public string ShipAddress { get; set; }
        /// <summary>
        /// icudad
        /// </summary>
        public string ShipCity { get; set; }
        /// <summary>
        /// pais
        /// </summary>
        public string ShipCountry { get; set; }
        /// <summary>
        /// codigo postal
        /// </summary>
        public string ShipPostalCode { get; set; }
        /// <summary>
        /// detalle de la orden
        /// </summary>
        public List<OrderDetailDto> OrderDetails { get; set; }
    }

}
