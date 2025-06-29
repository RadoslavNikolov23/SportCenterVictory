namespace SportCenterVictory.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SVC.Data.Models;
    using System.Reflection;

    public class SportCenterDbContext : IdentityDbContext
    {
        public SportCenterDbContext(DbContextOptions<SportCenterDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Exercise> Exercises { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
