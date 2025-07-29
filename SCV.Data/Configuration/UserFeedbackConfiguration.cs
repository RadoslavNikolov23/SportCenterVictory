namespace SCV.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using SCV.Data.Models;
    using SCV.GlCommon.Enums;

    using static SCV.GlCommon.ModelConstants.EntityConstantsUserFeedback;

    public class UserFeedbackConfiguration : BaseConfiguration, IEntityTypeConfiguration<UserFeedback>
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
                .Property(uf => uf.FullName)
                .IsRequired()
                .HasMaxLength(UserFullNameMaxLength);

            entity
                .Property(uf => uf.Feedback)
                .IsRequired()
                .HasMaxLength(FeedbackMaxLength);

            entity
                .Property(uf => uf.ImageUrl)
                .IsRequired(false)
                .HasMaxLength(ImageUrlMaxLength);

            entity
                .Property(uf => uf.Status)
                .HasDefaultValue(FeedbackStatus.Pending);

            entity
                .HasOne(uf => uf.User)
                .WithMany(au=>au.UserFeedbacks)
                .HasForeignKey(uf => uf.UserId);
        }
    }
}
