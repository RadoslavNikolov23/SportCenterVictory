namespace SCV.Data.Configuration
{
    using SCV.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static SCV.Data.Common.EntityConstantsUserFeedback;

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
                .Property(uf => uf.UserId)
                .IsRequired();

            entity
                .HasOne(uf => uf.User)
                .WithMany()
                .HasForeignKey(uf => uf.UserId);

            // Create a userFeedbackSeed.json file in the SeedFiles/UserFeedbacks directory
            //entity.HasData(SeedFromJson<Exercise>(Path.Combine("..", "SeedFiles", "UserFeedbacks", "userFeedbackSeed.json")));
        }
    }
}
