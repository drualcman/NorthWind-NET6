using Microsoft.Extensions.DependencyInjection;
using NorthWind.Entities.Interfaces.Events;
using NorthWind.Entities.Interfaces.Validation;
using NorthWind.Entities.Services;
using NorthWind.Sales.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Controllers
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
        /// <returns></returns>
        public static IServiceCollection AddNorthWindSalesControlers(this IServiceCollection services)
        {
            services.AddScoped<ICreateOrderController, CreateOrderController>();
            return services;
        }
    }
}
