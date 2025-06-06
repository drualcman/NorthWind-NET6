﻿using NorthWind.Entities.POCOEntities;

namespace NorthWind.Entities.Interfaces
{
    /// <summary>
    /// Escribir en un registro de errores
    /// </summary>
    public interface ILogWritableRepository : IUnitOfWork
    {
        /// <summary>
        /// agregar un registro por medio de clase
        /// </summary>
        /// <param name="log"></param>
        void Add(Log log);
        /// <summary>
        /// agregar un registro directamente como texto
        /// </summary>
        /// <param name="message"></param>
        void Add(string message);
    }
}
