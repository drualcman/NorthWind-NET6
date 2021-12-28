using Microsoft.EntityFrameworkCore;
using NorthWind.EFCore.DataContexts.POCOEntities;
using NorthWind.Sales.Entities.POCOEntities;
using System.Reflection;

namespace NorthWind.EFCore.DataContexts
{
    /// <summary>
    /// contexto de datosm para las ordenes en produccion
    /// </summary>
    public class NorthWindOrderContext : DbContext
    {
        /// <summary>
        /// constructor para recibir las opciones de configuracion
        /// </summary>
        /// <param name="options"></param>
        public NorthWindOrderContext(DbContextOptions<NorthWindOrderContext> options)
            : base(options) { }

        /// <summary>
        /// Tabla para ordenes
        /// </summary>
        public DbSet<Order> Orders => Set<Order>();
        /// <summary>
        /// Tabla para detalles de las ordenes
        /// </summary>
        public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();

        /// <summary>
        /// sobre escribir como configurar las tablas al crear los modelos
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // buscara las clases que implemente IEntityTypeConfiguration para configurar las entidades
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
