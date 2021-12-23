using Microsoft.Extensions.DependencyInjection;
using NorthWind.Sales.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWInd.Sales.ConsoleClient
{
    /// <summary>
    /// configurar la aplicacion
    /// </summary>
    public static class IoC
    {
        /// <summary>
        /// agregar los servicios necesarios
        /// </summary>
        public static void AddApplicationServices()
        {
            ServiceContainer.ConfigureServices(services =>
            {
                services.AddNorthwindSalesServices(ServiceContainer.Configuration, "NorthWinDB")
                    //.AddConsoleControllers()
                    .AddScoped<CreateOrderService>();
            });
        }
    }
}
