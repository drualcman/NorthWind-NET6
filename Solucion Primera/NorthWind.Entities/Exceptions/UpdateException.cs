using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Exceptions
{
    /// <summary>
    /// Excepciones de actualizacion
    /// </summary>
    public class UpdateException : Exception
    {
        /// <summary>
        /// Nombre de las entidades con error
        /// </summary>
        public IReadOnlyList<string> Entries { get; set; } = null!;

        /// <summary>
        /// Consuctor base
        /// </summary>
        public UpdateException() { }

        /// <summary>
        /// Constructor con mensaje
        /// </summary>
        /// <param name="message"></param>
        public UpdateException(string message) : base(message) { }

        /// <summary>
        /// Constructor con mensaje y excepcion ocurrida
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public UpdateException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Constructor con mensaje y las propiedades con error
        /// </summary>
        /// <param name="message"></param>
        /// <param name="entries"></param>
        public UpdateException(string message, IReadOnlyList<string> entries):base(message) =>
            Entries = entries;
    }
}
