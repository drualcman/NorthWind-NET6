using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Manejar las excepciones personalizadas
/// </summary>
namespace NorthWind.Entities.Exceptions
{
    /// <summary>
    /// Excepcion generica
    /// </summary>
    public class GeneralException : Exception
    {
        /// <summary>
        /// Almacenar los detalles de la excepcion
        /// </summary>
        public string? Detail { get; set; }

        /// <summary>
        /// Consuctor base
        /// </summary>
        public GeneralException() { }

        /// <summary>
        /// Constructor con mensaje
        /// </summary>
        /// <param name="message"></param>
        public GeneralException(string message) : base(message) { }

        /// <summary>
        /// Constructor con mensaje y excepcion ocurrida
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public GeneralException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Constructor con mi mensaje personalizado como titulo y mensaje
        /// </summary>
        /// <param name="title"></param>
        /// <param name="detail"></param>
        public GeneralException(string title, string detail):base(title)=> Detail = detail;
    }
}
