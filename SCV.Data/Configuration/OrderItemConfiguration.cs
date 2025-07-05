namespace SCV.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SCV.Data.Models;
    using static SCV.GlCommon.ApplicationConstants;


    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> entity)
        {
            entity
                .HasKey(oi => new { oi.OrderId, oi.ProductId });

            entity
                .Property(oi => oi.Quantity)
                .IsRequired();

            entity
               .Property(oi => oi.Price)
               .IsRequired()
               .HasColumnType(PriceSqlType);

            entity
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            entity
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId);

            entity
                .HasQueryFilter(oi => oi.Order.IsDeleted == false);

            entity
                .HasQueryFilter(oi => oi.Product.IsDeleted == false);
        }
    }
}
