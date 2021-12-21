using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.WebExceptionHandlerPresenters
{
    /// <summary>
    /// Recoger todos los manejadores de exceptions
    /// </summary>
    public static class ExceptionHandlersPresenters
    {
        /// <summary>
        /// Recoger el aseembly actual para buscar los manejadores de excepion
        /// </summary>
        public static Assembly Assembly => Assembly.GetExecutingAssembly();
    }
}
