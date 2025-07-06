namespace SCV.Data.Configuration
{
    using SCV.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static SCV.GlCommon.ApplicationConstants;

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity
                .HasKey(o => o.Id);

            entity
                .Property(o => o.OrderDate)
                .IsRequired();

            entity
                .Property(o => o.TotalPrice)
                .IsRequired()
                .HasColumnType(PriceSqlType);

            entity
                .Property(o => o.OrderStatus)
                .IsRequired();

            entity
                .Property(o => o.PaymentMethod)
                .IsRequired();

            entity
                .Property(o => o.IsDeleted)
                .HasDefaultValue(false);

            entity
                .Property(o => o.CustomerId)
                .IsRequired();

            entity
                .HasOne(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.CustomerId);
        }
    }
}
