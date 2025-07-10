namespace SCV.Data.Configuration
{
    using SCV.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CrossfitClassUserConfiguration : IEntityTypeConfiguration<CrossfitClassUser>
    {
        public void Configure(EntityTypeBuilder<CrossfitClassUser> entity)
        {
            entity
                .HasKey(ccu => new { ccu.CrossfitClassId, ccu.ApplicationUserId });

            entity.Property(ccu => ccu.JoinedAt)
                .IsRequired();

            entity
                .HasOne(ccu => ccu.ApplicationUser)
                .WithMany()
                .HasForeignKey(ccu => ccu.ApplicationUserId);

            entity
                .HasOne(ccu => ccu.CrossfitClass)
                .WithMany(cc => cc.CrossfitClassUsers)
                .HasForeignKey(ccu => ccu.CrossfitClassId);

            entity
                .HasQueryFilter(ccu => ccu.CrossfitClass.IsActive == true);

            //entity
            //    .HasQueryFilter(ccu => ccu.CrossfitClass.IsActive == true);

        }
    }
}
