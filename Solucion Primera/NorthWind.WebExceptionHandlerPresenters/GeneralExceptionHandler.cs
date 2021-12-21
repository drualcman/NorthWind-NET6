using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthWind.Entities.Exceptions;
using WebExceptionHandlerAPI.Interfaces;

namespace NorthWind.WebExceptionHandlerPresenters
{
    /// <summary>
    /// Manejador de exceptiones generales
    /// </summary>
    public class GeneralExceptionHandler : IExceptionHandler<GeneralException>
    {
        /// <summary>
        /// Manejar una excepcion general
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public ValueTask<ProblemDetails> Handle(GeneralException exception)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = "https://datatracker.ieft.org/doc/html/rfc7231#section-6.6.1",
                Title = exception.Message,
                Detail = exception.Detail
            };
            return ValueTask.FromResult(problemDetails);
        }
    }
}