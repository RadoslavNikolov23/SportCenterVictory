namespace SCV.Data.Configuration
{
    using SCV.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EventUserConfiguration : IEntityTypeConfiguration<EventUser>
    {
        public void Configure(EntityTypeBuilder<EventUser> entity)
        {
            entity
                .HasKey(eu => new { eu.ApplicationUserId, eu.EventId });

            entity
                .HasOne(eu => eu.ApplicationUser)
                .WithMany(au=>au.EventUsers)
                .HasForeignKey(eu => eu.ApplicationUserId);

            entity
                .HasOne(eu => eu.Event)
                .WithMany(e => e.EventUsers)
                .HasForeignKey(eu => eu.EventId);

            entity
                .HasQueryFilter(eu =>eu.Event.IsDeleted == false);

        }
    }
}
