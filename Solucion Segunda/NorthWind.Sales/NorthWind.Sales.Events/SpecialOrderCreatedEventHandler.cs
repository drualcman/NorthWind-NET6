using NorthWind.Entities.Interfaces;
using NorthWind.Entities.Interfaces.Events;

namespace NorthWind.Sales.Events
{
    /// <summary>
    /// Manejador de la implementacion del evento del dominio
    /// </summary>
    public class SpecialOrderCreatedEventHandler : IDomainEventHandler<SpecialOrderCreatedEvent>
    {

        readonly IMailService MailService;

        public SpecialOrderCreatedEventHandler(IMailService mailService)
        {
            MailService = mailService;
        }


        /// <summary>               
        /// recibir los datos para enviar el correo de la orden especial
        /// </summary>
        /// <param name="orderCreated"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Handle(SpecialOrderCreatedEvent orderCreated)
        {
            MailService.Send($"Ordern {orderCreated.OrderId} con {orderCreated.ProductsCount} productos ha sido creada");
        }
    }
}
