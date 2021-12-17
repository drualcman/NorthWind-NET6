using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebExceptionHandlerAPI.Interfaces;

namespace WebExceptionHandlerAPI
{
    /// <summary>
    /// Helper para injectar los servicios implementados dentro del projecto
    /// </summary>
    public static class DependencyContainer
    {
        /// <summary>
        /// Agregar todos servicios del projecto de entities
        /// </summary>
        /// <param name="services"></param>
        /// <param name="exceptionHandlersAssembly"></param>
        /// <returns></returns>
        public static IServiceCollection AddWebExceptionsHandlerPresenter(this IServiceCollection services,
            Assembly exceptionHandlersAssembly)
        {
            services.AddSingleton<IWebExceptionPresenter>(provicer => new WebExceptionPresenter(exceptionHandlersAssembly));
            return services;
        }
    }
}
