﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NorthWind.Entities.Interfaces.Events;
using NorthWind.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.EFCore.DataContexts
{
    /// <summary>
    /// Helper para injectar los servicios implementados dentro del projecto
    /// </summary>
    public static class DependencyContainer
    {
        /// <summary>
        /// Agregar los contextos de datos
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <param name="connectionStrincName"></param>
        /// <returns></returns>
        public static IServiceCollection AddDataContexts(this IServiceCollection services
            , IConfiguration configuration, string connectionStrincName)
        {
            services.AddDbContext<NorthWindLogContext>(o=>
                o.UseSqlServer(configuration.GetConnectionString(connectionStrincName)));
            services.AddDbContext<NorthWindOrderContext>(o=>
                o.UseSqlServer(configuration.GetConnectionString(connectionStrincName)));
            return services;
        }
    }
}
