using Microsoft.EntityFrameworkCore;
using NorthWind.Entities.POCOEntities;

namespace NorthWind.EFCore.DataContexts
{
    /// <summary>
    /// Contexto para los logs para produccion
    /// </summary>
    public class NorthWindLogContext : DbContext
    {
        /// <summary>
        /// constructor para recibir las opciones de configuracion
        /// </summary>
        /// <param name="options"></param>
        public NorthWindLogContext(DbContextOptions<NorthWindLogContext> options)
            : base(options) { }

        /// <summary>
        /// Tabla para logs
        /// </summary>
        DbSet<Log> Logs => Set<Log>();  //no necesita desabilitar los nulables
    }
}
