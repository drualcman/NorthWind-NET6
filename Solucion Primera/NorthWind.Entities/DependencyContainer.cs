using Microsoft.Extensions.DependencyInjection;
using NorthWind.Entities.Interfaces.Events;
using NorthWind.Entities.Services;

namespace NorthWind.Entities
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
        public static IServiceCollection AddEntitiesServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IDomainEventHub<>), typeof(DomainEventHub<>));
            return services;
        }
    }
}
