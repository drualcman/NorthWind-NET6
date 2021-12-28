using Microsoft.EntityFrameworkCore;
using NorthWind.EFCore.DataContexts.POCOEntities;
using NorthWind.Entities.POCOEntities;
using NorthWind.Sales.Entities.POCOEntities;
using System.Reflection;

namespace NorthWind.EFCore.DataContexts
{
    //eliminar el aviso de los nulables a nivel clase
#nullable disable
    /// <summary>
    /// El contexto de datos a utilizar en diseño
    /// Esto es exclusivamente para adminsitrar la base de datos
    /// add-migration InitialCreate -p NorthWind.EFCore.DataContexts -s NorthWind.EFCore.DataContexts -c NorthWindContext -o Migrations
    /// update-database -p NorthWind.EFCore.DataContexts -s NorthWind.EFCore.DataContexts -context NorthWindContext
    /// </summary>
    internal class NorthWindContext : DbContext
    {
        /// <summary>
        /// sobre escribir la configuracion
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=NorthWinDB");
            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// Tabla para logs
        /// </summary>
        public DbSet<Log> Logs => Set<Log>();
        /// <summary>
        /// Tabla para ordenes
        /// </summary>
        public DbSet<Order> Orders => Set<Order>();
        /// <summary>
        /// Tabla para detalles de las ordenes
        /// </summary>
        public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();
        /// <summary>
        /// tabla de clientes
        /// </summary>
        public DbSet<Customer> Customers => Set<Customer>();
        /// <summary>
        /// tabla de productos
        /// </summary>
        public DbSet<Product> Products => Set<Product>();


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
