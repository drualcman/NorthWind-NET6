using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWind.EFCore.DataContexts.POCOEntities;

namespace NorthWind.EFCore.DataContexts.Configurations
{
    /// <summary>
    /// configurar la tabla de orderdetails
    /// </summary>
    internal class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(d => new { d.OrderId, d.ProductId });

            builder.Property(d => d.UnitPrice)
                .HasPrecision(8, 2);
        }
    }
}
