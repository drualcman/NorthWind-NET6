using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthWind.Entities.Exceptions;
using WebExceptionHandlerAPI.Interfaces;

namespace NorthWind.WebExceptionHandlerPresenters
{
    /// <summary>
    /// manejador de excepciones de validacion
    /// </summary>
    public class ValidationExceptionHandler : IExceptionHandler<ValidationException>
    {
        /// <summary>
        /// Manejar la excepcion
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public ValueTask<ProblemDetails> Handle(ValidationException exception)
        {
            Dictionary<string, string> extensions =
                new Dictionary<string, string>();

            foreach (var failure in exception.Failures)
            {
                if (extensions.ContainsKey(failure.PropertyName))
                {
                    extensions[failure.PropertyName] += " " + failure.ErrorMessage;
                }
                else
                {
                    extensions.Add(failure.PropertyName, failure.ErrorMessage);
                }
            }
            var ProblemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                Title = "Error en los datos de entrada.",
                Detail = "Se encontró uno o más errores de validación de datos."
            };
            ProblemDetails.Extensions.Add("invalid-params", extensions);
            return ValueTask.FromResult(ProblemDetails);
        }
    }
}
