namespace SCV.Data
{
    using SCV.Data.Models;
    using System.Reflection;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class SportCenterDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public SportCenterDbContext(DbContextOptions<SportCenterDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;

        public virtual DbSet<CrossfitClass> CrossfitClasses { get; set; } = null!;

        public virtual DbSet<CrossfitClassUser> CrossfitClassUsers { get; set; } = null!;

        public virtual DbSet<CrossfitWorkoutOfTheDay> CrossfitWorkoutOfTheDays { get; set; } = null!;

        public virtual DbSet<Event> Events { get; set; } = null!;   

        public virtual DbSet<Exercise> Exercises { get; set; } = null!;

        public virtual DbSet<Membership> Memberships { get; set; } = null!;

        public virtual DbSet<MembershipUser> MembershipUsers { get; set; } = null!;

        public virtual DbSet<Order> Orders { get; set; } = null!;

        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;

        public virtual DbSet<Product> Products { get; set; } = null!;

        public virtual DbSet<Trainer> Trainers { get; set; } = null!;

        public virtual DbSet<TrainerUser> TrainerUsers { get; set; } = null!;

        public virtual DbSet<UserFeedback> UserFeedbacks { get; set; } = null!;

        public virtual DbSet<WorkoutPlan> WorkoutPlans { get; set; } = null!;

        public virtual DbSet<WorkoutPlanExercise> WorkoutPlanExercises { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
