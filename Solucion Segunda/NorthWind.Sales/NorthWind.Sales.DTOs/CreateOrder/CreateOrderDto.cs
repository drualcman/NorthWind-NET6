namespace NorthWind.Sales.DTOs.CreateOrder
{
    /// <summary>
    /// Crear la orden
    /// </summary>
    public class CreateOrderDto
    {

        /// <summary>
        /// Identificador del cliente
        /// </summary>
        public string CustomerId { get; set; }
        /// <summary>
        /// direccion de envio
        /// </summary>
        public string ShipAddress { get; set; }
        /// <summary>
        /// Ciudad de envio
        /// </summary>
        public string ShipCity { get; set; }
        /// <summary>
        /// Pais de envio
        /// </summary>
        public string ShipCountry { get; set; }
        /// <summary>
        /// Codigo postal de envio
        /// </summary>
        public string ShipPostalCode { get; set; }
        /// <summary>
        /// List de productos
        /// </summary>
        public List<CreateOrderDetailDto> OrderDetails { get; set; }
    }
}
