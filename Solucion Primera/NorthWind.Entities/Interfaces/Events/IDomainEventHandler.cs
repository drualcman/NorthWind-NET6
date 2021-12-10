using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Interfaces.Events
{
    /// <summary>
    /// Manejador del evento de dominio
    /// </summary>
    /// <typeparam name="EventType">Clase que imlpementara el evento de dominio</typeparam>
    public interface IDomainEventHandler<EventType> where EventType : IDomainEvent
    {
        /// <summary>
        /// Manejador del evento
        /// </summary>
        /// <param name="eventTypeInstance"></param>
        void Handle(EventType eventTypeInstance);
    }
}
