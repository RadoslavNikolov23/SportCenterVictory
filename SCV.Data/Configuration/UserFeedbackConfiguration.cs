namespace SCV.Data.Configuration
{
    using SCV.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static SCV.Data.Common.EntityConstraintsUserFeedback;

    public class UserFeedbackConfiguration : IEntityTypeConfiguration<UserFeedback>
    {
        public void Configure(EntityTypeBuilder<UserFeedback> entity)
        {
            entity
                .HasKey(uf => uf.Id);

            entity
                .Property(uf => uf.UserName)
                .IsRequired()
                .HasMaxLength(UserNameMaxLength);

            entity
                .Property(uf => uf.Feedback)
                .IsRequired()
                .HasMaxLength(FeedbackMaxLength);

            entity
                .Property(uf => uf.UserId)
                .IsRequired();

            entity
                .HasOne(uf => uf.User)
                .WithMany()
                .HasForeignKey(uf => uf.UserId);

            //entity
            //    .HasData();
        }
    }
}
