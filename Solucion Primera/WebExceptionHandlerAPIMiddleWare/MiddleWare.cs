using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using WebExceptionHandlerAPI.Interfaces;

namespace WebExceptionHandlerAPIMiddleWare
{
    /// <summary>
    /// Se va a incrustar en las transaciones
    /// </summary>
    class MiddleWare
    {
        /// <summary>
        /// recuperar la excepcion del contexto y presentar el error correspondiente formateado
        /// </summary>
        /// <param name="context"></param>
        /// <param name="includeDetails"></param>
        /// <param name="presenter"></param>
        /// <returns></returns>
        public static async Task WriteResponse(HttpContext context,
            bool includeDetails, IWebExceptionPresenter presenter)
        {
            IExceptionHandlerFeature exceptionDetail = context.Features.Get<IExceptionHandlerFeature>();
            Exception exception = exceptionDetail.Error;

            if (exception != null)
            {
                await presenter.Handle(exception, includeDetails);
                context.Response.ContentType = "application/problem+json";
                context.Response.StatusCode = presenter.Content.Status.Value;
                var stream = context.Response.Body;
                await JsonSerializer.SerializeAsync(stream, presenter.Content);
            }
        }
    }
}