namespace NorthWind.Sales.ViewModels
{
    /// <summary>
    /// mostrar la orden creada
    /// </summary>
    public class CreateOrderViewModel
    {
        /// <summary>
        /// numero de orden
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// constructor 
        /// </summary>
        /// <param name="orderId"></param>
        public CreateOrderViewModel(int orderId)
        {
            OrderId = orderId;
        }
    }
}