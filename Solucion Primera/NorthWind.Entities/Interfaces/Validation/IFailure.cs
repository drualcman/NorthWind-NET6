using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Interfaces.Validation
{
    /// <summary>
    /// Define el error de validacion generado y su mensaje de error
    /// </summary>
    public interface IFailure
    {
        /// <summary>
        /// Propiedad en fallo
        /// </summary>
        string PropertyName { get; }
        /// <summary>
        /// Mensaje a mostrar
        /// </summary>
        string ErrorMessage { get; }
    }
}
