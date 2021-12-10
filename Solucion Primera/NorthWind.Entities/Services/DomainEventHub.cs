using NorthWind.Entities.Interfaces.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Services
{

    /// <summary>
    /// Implementacion basica de los eventos de dominio porque es comun para todo.
    /// Solo tiene que lanzar el evento.
    /// </summary>
    /// <typeparam name="EventType"></typeparam>
    public class DomainEventHub<EventType> : IDomainEventHub<EventType>
        where EventType : IDomainEvent
    {
        readonly IEnumerable<IDomainEventHandler<EventType>> EventHandlers;

        /// <summary>
        /// Recibir todos los eventos registrados
        /// </summary>
        /// <param name="eventHandlers"></param>
        public DomainEventHub(IEnumerable<IDomainEventHandler<EventType>> eventHandlers)
        {
            EventHandlers = eventHandlers;
        }


        /// <summary>
        /// Lanzar el evento
        /// </summary>
        /// <param name="eventTypeInstance"></param>
        public void Raise(EventType eventTypeInstance)
        {
            foreach (IDomainEventHandler<EventType> handler in EventHandlers)
            {
                Task.Run(() => handler.Handle(eventTypeInstance));
            }
        }
    }
}
