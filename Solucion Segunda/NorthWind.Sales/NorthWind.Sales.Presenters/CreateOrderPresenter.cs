using NorthWind.Entities.Interfaces;
using NorthWind.Sales.Ports.CreateOrder;
using NorthWind.Sales.ViewModels;

namespace NorthWind.Sales.Presenters
{
    public class CreateOrderPresenter : ICreateOrderOutPort, IPresenter<CreateOrderViewModel>
    {
        /// <summary>
        /// contenido de la orden
        /// </summary>
        public CreateOrderViewModel Content { get; private set; }

        public ValueTask Handle(int orderId)
        {
            Content = new CreateOrderViewModel(orderId);
            return ValueTask.CompletedTask;
        }
    }
}