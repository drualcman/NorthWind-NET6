using Microsoft.Extensions.DependencyInjection;
using NorthWind.Entities.Interfaces.Validation;

namespace NorthWind.ValidationService
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
        public static IServiceCollection AddValidationService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IValidationService<>), typeof(ValidatorWrapper<>));
            return services;
        }
    }
}
