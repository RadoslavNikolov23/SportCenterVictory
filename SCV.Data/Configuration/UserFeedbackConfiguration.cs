namespace SCV.Data.Configuration
{
    using SCV.Data.Models;
    using SCV.GlCommon.Enums;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
                .WithMany()
                .HasForeignKey(uf => uf.UserId);

            //For deletion, because their are seeded dynamically to the database
            //entity.HasData(SeedFromJson<UserFeedback>(Path.Combine("..", "SCV.Data", "SeedFiles", "UserFeedbacks", "userFeedbackSeed.json")));
        }
    }
}
