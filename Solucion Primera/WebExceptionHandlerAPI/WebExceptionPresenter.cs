using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WebExceptionHandlerAPI.Interfaces;

namespace WebExceptionHandlerAPI
{
#nullable disable
    /// <summary>
    /// Implementacion parala presentacion de los errores
    /// </summary>
    public class WebExceptionPresenter : IWebExceptionPresenter
    {
        /// <summary>
        /// para que no se este creando en cada instancia, 
        /// lo dejamos como estatico y asi solo se hace una vez
        /// </summary>
        static readonly Dictionary<Type, Type> ExceptionHandlers = new Dictionary<Type, Type>();

        /// <summary>
        /// Constructor que recibe el asembly para obtener o buscar todos los manejadores de excepcion
        /// </summary>
        /// <param name="exceptionHandlerAssembly"></param>
        public WebExceptionPresenter(Assembly exceptionHandlerAssembly)
        {
            Type[] types = exceptionHandlerAssembly.GetTypes();
            foreach (Type t in types)
            {
                var handlers = t.GetInterfaces()
                    .Where(i => i.IsGenericType
                             && i.GetGenericTypeDefinition() == typeof(IExceptionHandler<>));
                foreach (Type i in handlers)
                {
                    var exceptionType = i.GetGenericArguments()[0];
                    ExceptionHandlers.TryAdd(exceptionType, t);
                }
            }
        }

        /// <summary>
        /// Contenido de la excepcion
        /// </summary>
        public ProblemDetails Content { get; private set; }

        /// <summary>
        /// Formatear el contenido para mostrar el problem details desde la excepcion recibida
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="includeDetails"></param>
        /// <returns></returns>
        public async ValueTask Handle(Exception ex, bool includeDetails)
        {
            ProblemDetails problem;
            if (ExceptionHandlers.TryGetValue(ex.GetType(), out Type handlerType))
            {
                var handler = Activator.CreateInstance(handlerType);

                problem = await (ValueTask<ProblemDetails>)handlerType.GetMethod("Handle")
                    .Invoke(handler, new object[] { ex });
            }
            else
            {
                string title;
                string detail;

                if (includeDetails)
                {
                    title = $"Un error ocurrio: {ex.Message}";
                    detail = ex.ToString();
                }
                else
                {
                    title = "Ha ocurrido un error al procesar la respuesta";
                    detail = "Consulte al administrador";
                }
                problem = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Type = "https://datatracker.ietf.org/doc/html/rfc7231#section6.6.1",
                    Title = title,
                    Detail = detail
                };
            }
            Content = problem;
        }
    }
}
