using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWind.Sales.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.EFCore.DataContexts.Configurations
{
    /// <summary>
    /// clase para configurar la tabla order
    /// </summary>
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.CustomerId)
                .IsRequired()
                .HasMaxLength(5)
                .IsFixedLength();
            builder.Property(o => o.ShipAddress)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(o => o.ShipCity)
                .HasMaxLength(15);

            builder.Property(o => o.ShipCountry)
                .HasMaxLength(15);

            builder.Property(o => o.ShipPostalCode)
                .HasMaxLength(10);
        }
    }
}
