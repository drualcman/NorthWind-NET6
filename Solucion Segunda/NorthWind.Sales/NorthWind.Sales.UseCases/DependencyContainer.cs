using Microsoft.Extensions.DependencyInjection;
using NorthWind.Sales.Ports.CreateOrder;
using NorthWind.Sales.Ports.GetOrdersByDate;
using NorthWind.Sales.UseCases.CreateOrder;
using NorthWind.Sales.UseCases.GetOrdersByDate;

namespace NorthWind.Sales.UseCases
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
        public static IServiceCollection AddUseCasesServices(this IServiceCollection services)
        {
            services.AddScoped<CreateOrderService>();
            services.AddScoped<ICreateOrderInputPort, CreateOrderInteractor>();
            services.AddScoped<IGetOrdersByDateInputPort, GetOrdersByDateInteractor>();
            return services;
        }
    }
}
