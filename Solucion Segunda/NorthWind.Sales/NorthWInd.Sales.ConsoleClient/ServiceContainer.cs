using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWInd.Sales.ConsoleClient
{
    /// <summary>
    /// Contenedor de los servicios para la injeccion de dependencias
    /// </summary>
    public static class ServiceContainer
    {
        static IServiceProvider ServiceProvider;

        /// <summary>
        /// Configurar los servicios de la aplicacion
        /// </summary>
        /// <param name="configureServices"></param>
        public static void ConfigureServices(Action<IServiceCollection> configureServices)
        {
            IServiceCollection services = new ServiceCollection();
            configureServices(services);

            ServiceProvider = services.BuildServiceProvider();
        }

        /// <summary>
        /// Para pedir el servicio requerido
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetService<T>() => ServiceProvider.GetService<T>()!;

        /// <summary>
        /// Obtener la configuracion desde un archivo de configuracion
        /// </summary>
        public static IConfiguration Configuration => new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
    }
}
