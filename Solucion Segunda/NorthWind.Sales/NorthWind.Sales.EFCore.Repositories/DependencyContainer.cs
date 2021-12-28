using Microsoft.Extensions.DependencyInjection;
using NorthWind.Sales.UseCases.CreateOrder;

namespace NorthWind.Sales.EFCore.Repositories
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
        public static IServiceCollection AddCreateOrderRepository(this IServiceCollection services)
        {
            services.AddScoped<ICreateOrderRepository, CreateOrderRepository>();
            return services;
        }
    }
}
