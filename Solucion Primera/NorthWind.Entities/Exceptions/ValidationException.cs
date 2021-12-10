using NorthWind.Entities.Interfaces.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Exceptions
{
    /// <summary>
    /// Excepciones en la validacion
    /// </summary>
    public class ValidationException : Exception
    {
        /// <summary>
        /// Nombre de las entidades con error
        /// </summary>
        public IReadOnlyList<IFailure> Failures { get; } = null!;

        /// <summary>
        /// Consuctor base
        /// </summary>
        public ValidationException() { }

        /// <summary>
        /// Constructor con mensaje
        /// </summary>
        /// <param name="message"></param>
        public ValidationException(string message) : base(message) { }

        /// <summary>
        /// Constructor con mensaje y excepcion ocurrida
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ValidationException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Constructor los errores
        /// </summary>
        /// <param name="failures"></param>
        public ValidationException(IReadOnlyList<IFailure> failures) =>
            Failures = failures;
    }
}
