namespace SCV.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SCV.Data.Models;

    public class EventUserConfiguration : IEntityTypeConfiguration<EventUser>
    {
        public void Configure(EntityTypeBuilder<EventUser> entity)
        {
            entity
                .HasKey(eu => new { eu.ApplicationUserId, eu.EventId });

            entity
                .HasOne(eu => eu.ApplicationUser)
                .WithMany()
                .HasForeignKey(eu => eu.ApplicationUserId);

            entity
                .HasOne(eu => eu.Event)
                .WithMany(e => e.EventUsers)
                .HasForeignKey(eu => eu.EventId);

            entity
                .HasQueryFilter(eu => !eu.Event.IsDeleted);

        }
    }
}
