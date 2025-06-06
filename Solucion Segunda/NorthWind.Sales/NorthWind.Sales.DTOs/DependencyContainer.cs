﻿using Microsoft.Extensions.DependencyInjection;
using NorthWind.Entities.Interfaces.Validation;
using NorthWind.Sales.DTOs.CreateOrder;
using NorthWind.Sales.DTOs.GetOrdersByDate;

namespace NorthWind.Sales.DTOs
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
        public static IServiceCollection AddDtoValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateOrderDetailDto>, CreateOrderDetailDtoValidator>();
            services.AddScoped<IValidator<CreateOrderDto>, CreateOrderDtoValidator>();
            services.AddScoped<IValidator<GetOrdersByDateDto>, GetOrdersByDateDtoValidator>();
            return services;
        }
    }
}
