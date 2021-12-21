using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExceptionHandlerAPI.Interfaces;

namespace WebExceptionHandlerAPIMiddleWare
{
    /// <summary>
    /// injectar el middleware
    /// </summary>
    public static class MiddleWareContainer
    {
        /// <summary>
        /// Injectar los servicios manejadores de excepciones
        /// </summary>
        /// <param name="app"></param>
        /// <param name="enviroment"></param>
        /// <param name="presenter"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseWebExceptionHandlerPresenter(this IApplicationBuilder app, 
            IHostEnvironment enviroment, IWebExceptionPresenter presenter)
        {
            app.Use((context, next) => MiddleWare.WriteResponse(context, 
                enviroment.IsDevelopment(), presenter));

            return app;
        }
    }
}
