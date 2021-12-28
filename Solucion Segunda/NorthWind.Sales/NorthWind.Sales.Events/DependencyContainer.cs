using Microsoft.Extensions.DependencyInjection;
using NorthWind.Entities.Interfaces.Events;

namespace NorthWind.Sales.Events
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
        public static IServiceCollection AddEventsHandler(this IServiceCollection services)
        {
            services.AddScoped<IDomainEventHandler<SpecialOrderCreatedEvent>, SpecialOrderCreatedEventHandler>();
            return services;
        }
    }
}
