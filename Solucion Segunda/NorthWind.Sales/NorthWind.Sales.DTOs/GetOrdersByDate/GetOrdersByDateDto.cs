namespace NorthWind.Sales.DTOs.GetOrdersByDate
{
    /// <summary>
    /// Recibir del usuario la fecha
    /// </summary>
    public class GetOrdersByDateDto
    {
        /// <summary>
        /// Fecha de la consulta
        /// </summary>
        public DateTime OrderDate { get; set; }
    }
}
