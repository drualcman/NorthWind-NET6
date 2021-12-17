using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExceptionHandlerAPI.Interfaces
{
    /// <summary>
    /// Abstraccion para la abstraccion
    /// </summary>
    public interface IExceptionHandler<ExceptionType> where ExceptionType : Exception
    {
        /// <summary>
        /// Manejar la excepcion
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        ValueTask<ProblemDetails> Handle(ExceptionType exception);
    }
}
