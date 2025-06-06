﻿namespace NorthWind.Entities.Interfaces.Events
{

    /// <summary>
    /// Mediador para enviar los eventos
    /// </summary>
    /// <typeparam name="EventType"></typeparam>
    public interface IDomainEventHub<EventType> where EventType : IDomainEvent
    {
        /// <summary>
        /// Lanzar el evento
        /// </summary>
        /// <param name="eventTypeInstance"></param>
        void Raise(EventType eventTypeInstance);
    }
}
