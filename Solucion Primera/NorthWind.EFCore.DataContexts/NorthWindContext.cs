using Microsoft.EntityFrameworkCore;
using NorthWind.EFCore.DataContexts.POCOEntities;
using NorthWind.Entities.POCOEntities;
using NorthWind.Sales.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.EFCore.DataContexts
{
    //eliminar el aviso de los nulables a nivel clase
#nullable disable
    /// <summary>
    /// El contexto de datos a utilizar en diseño
    /// Esto es exclusivamente para adminsitrar la base de datos
    /// add-migration InitialCreate -p NorthWind.EFCore.DataContexts -s NorthWind.EFCore.DataContexts -c NorthWindContext -o Migrations
    ///  update-database -p NorthWind.EFCore.DataContexts -s NorthWind.EFCore.DataContexts -context NorthWindContext
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
        public DbSet<Log> Logs { get; set; }
        /// <summary>
        /// Tabla para ordenes
        /// </summary>
        public DbSet<Order> Orders { get; set; }
        /// <summary>
        /// Tabla para detalles de las ordenes
        /// </summary>
        public DbSet<OrderDetail> OrderDetails { get; set; }

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
