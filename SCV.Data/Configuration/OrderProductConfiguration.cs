namespace SCV.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using SCV.Data.Models;

    using static SCV.GlCommon.ApplicationConstants;


    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> entity)
        {
            entity
                .HasKey(op => new { op.OrderId, op.ProductId });

            entity
                .Property(op => op.Quantity)
                .IsRequired();

            entity
               .Property(op => op.Price)
               .IsRequired()
               .HasColumnType(PriceSqlType);

            entity
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId);

            entity
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.ProductId);

            entity
                .HasQueryFilter(op => op.Order.IsDeleted == false &&
                                      op.Product.IsDeleted == false);
        }
    }
}
