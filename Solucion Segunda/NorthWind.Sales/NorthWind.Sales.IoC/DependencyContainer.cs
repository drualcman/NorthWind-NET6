using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NorthWind.EFCore.DataContexts;
using NorthWind.EFCore.Repositories;
using NorthWind.Entities;
using NorthWind.Entities.Interfaces.Events;
using NorthWind.Entities.Interfaces.Validation;
using NorthWind.Entities.Services;
using NorthWind.Loggers;
using NorthWind.Mail;
using NorthWind.Sales.Controllers;
using NorthWind.Sales.DTOs;
using NorthWind.Sales.EFCore.Repositories;
using NorthWind.Sales.Events;
using NorthWind.Sales.Ports.CreateOrder;
using NorthWind.Sales.Presenters;
using NorthWind.Sales.UseCases;
using NorthWind.ValidationService;
using NorthWind.WebExceptionHandlerPresenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebExceptionHandlerAPI;

namespace NorthWind.Sales.IoC
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
        public static IServiceCollection AddNorthwindSalesServices(this IServiceCollection services,
            IConfiguration configuration, string connectionStringName)
        {

            services
                .AddEntitiesServices()
                .AddLoggers()
                .AddEventsHandler()
                .AddMailService()
                .AddDataContexts(configuration, connectionStringName)
                .AddLogRespository()
                .AddCreateOrderRepository()
                .AddUseCasesServices()
                .AddDtoValidators()
                .AddPresenters()
                .AddNorthWindSalesControlers()
                .AddWebExceptionsHandlerPresenter(ExceptionHandlersPresenters.Assembly)
                .AddValidationService();

            return services;
        }
    }
}
