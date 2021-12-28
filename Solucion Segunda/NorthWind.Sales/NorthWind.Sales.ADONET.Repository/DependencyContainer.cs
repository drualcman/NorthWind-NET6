using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NorthWind.Sales.UseCases.Common.Interfaces;
using NorthWind.Sales.UseCases.CreateOrder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.ADONET.Repository
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddOrderReadableRepository(
            this IServiceCollection services,
            IConfiguration configuration, string connectionStringName)
        {
            services.AddScoped<IDbConnection>(provider =>
            new SqlConnection(
                configuration.GetConnectionString(connectionStringName)));

            services.AddScoped<IOrderReadableRepository,
                OrderReadableRepository>();

            services.AddScoped<ICreateOrderValidationRepository,
                CreateOrderValidationRepository>();
            return services;
        }
    }

}
