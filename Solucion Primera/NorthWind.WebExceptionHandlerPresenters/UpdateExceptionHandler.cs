using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthWind.Entities.Exceptions;
using WebExceptionHandlerAPI.Interfaces;

namespace NorthWind.WebExceptionHandlerPresenters
{
    /// <summary>
    /// Manejar las excepciones de actualizacion
    /// </summary>
    public class UpdateExceptionHandler : IExceptionHandler<UpdateException>
    {
        /// <summary>
        /// Maneja la excepcion the actualizacion
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public ValueTask<ProblemDetails> Handle(UpdateException exception)
        {
            Dictionary<string, string> exceptions = new Dictionary<string, string>
            {
                { "entities", string.Join(",", exception.Entries) }
            };
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "https://datatracker.irtf.org/doc/html/rtfc7231@section-6.5.1",
                Title = "Error de actualizacion",
                Detail = exception.Message
            };
            problemDetails.Extensions.Add("invalid-params", exceptions);
            return ValueTask.FromResult(problemDetails);
        }
    }
}
