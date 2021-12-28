using Microsoft.Extensions.DependencyInjection;
using NorthWind.Sales.Ports.CreateOrder;

namespace NorthWind.Sales.Presenters
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
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<ICreateOrderOutPort, CreateOrderPresenter>();
            return services;
        }
    }
}
