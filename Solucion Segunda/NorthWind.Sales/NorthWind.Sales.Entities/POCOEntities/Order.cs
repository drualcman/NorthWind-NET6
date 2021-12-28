using NorthWind.Sales.Entities.Enums;

/// <summary>
/// Entidades para el caso de uso
/// </summary>
namespace NorthWind.Sales.Entities.POCOEntities
{
    /// <summary>
    /// Orden
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Identificador de la orden
        /// </summary>
        public int Id { get; set; }
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
        /// Fecha de creacion
        /// </summary>
        public DateTime OrderDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Tipo de descuento
        /// </summary>
        public DiscountType DiscountType { get; set; } = DiscountType.Percentage;
        /// <summary>
        /// Cantidad de descuento
        /// </summary>
        public double Discount { get; set; } = 10;
        /// <summary>
        /// Tipo de envio
        /// </summary>
        public ShippingType ShippingType { get; set; } = ShippingType.Road;

    }
}
