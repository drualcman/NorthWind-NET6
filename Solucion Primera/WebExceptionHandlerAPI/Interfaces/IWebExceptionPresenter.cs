using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExceptionHandlerAPI.Interfaces
{
    /// <summary>
    /// Abstraer la presentacion del error
    /// </summary>
    public interface IWebExceptionPresenter
    {
        /// <summary>
        /// El contenido de la excepcion
        /// </summary>
        ProblemDetails Content { get; }

        /// <summary>
        /// Manejar la excepcion a presentar
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="includeDetails"></param>
        /// <returns></returns>
        ValueTask Handle(Exception ex, bool includeDetails);
    }
}
