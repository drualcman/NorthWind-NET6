using NorthWind.Entities.Exceptions;
using NorthWind.Entities.Interfaces;
using NorthWind.Entities.Interfaces.Validation;
using NorthWind.Sales.DTOs.GetOrdersByDate;
using NorthWind.Sales.UseCases.Common.Interfaces;
using NorthWind.Sales.Ports.Common;
using NorthWind.Sales.Ports.GetOrdersByDate;

namespace NorthWind.Sales.UseCases.GetOrdersByDate
{
    /// <summary>
    /// Caso de uso para consultar ordenes por fecha
    /// </summary>
    public class GetOrdersByDateInteractor : IGetOrdersByDateInputPort
    {
        readonly IValidator<GetOrdersByDateDto> Validator;
        readonly IOrderReadableRepository OrderRepository;
        readonly ILogWritableRepository ActivityRepository;
        readonly IGetOrdersOutputPort OutputPort;

        /// <summary>
        /// contruir la clase
        /// </summary>
        /// <param name="validator"></param>
        /// <param name="orderRepository"></param>
        /// <param name="activityRepository"></param>
        /// <param name="outputPort"></param>
        public GetOrdersByDateInteractor(
            IValidator<GetOrdersByDateDto> validator,
            IOrderReadableRepository orderRepository,
            ILogWritableRepository activityRepository,
            IGetOrdersOutputPort outputPort)
        {
            Validator = validator;
            OrderRepository = orderRepository;
            ActivityRepository = activityRepository;
            OutputPort = outputPort;
        }

        /// <summary>
        /// manejar el caso de uso
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        public async ValueTask Handle(GetOrdersByDateDto order)
        {
            if (!Validator.Validate(order))
            {
                throw new ValidationException(Validator.Failures);
            }

            var Orders = OrderRepository.GetOrdersWithDetailsBySpecification(new OrderDateSpecification(order.OrderDate));

            ActivityRepository.Add("Obtener listado de órdenes de compra");
            ActivityRepository.SaveChanges();

            await OutputPort.Handle(Orders);
        }
    }

}
