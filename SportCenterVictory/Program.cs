namespace SportCenterVictory
{
    using SCV.Data;
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.Services.Core.Contracts;
    using SCV.Web.Infrastructure;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                ?? 
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services
                    .AddDbContext<SportCenterDbContext>(options=>
                        {
                            options.UseSqlServer(connectionString);
                        });

            builder.Services
                    .AddDatabaseDeveloperPageExceptionFilter();

            builder.Services
                    .AddIdentity<ApplicationUser, ApplicationRole>(options =>
                        {
                            options.SignIn.RequireConfirmedAccount = false;
                            options.Password.RequireDigit = false;
                            options.Password.RequireNonAlphanumeric = false;
                            options.Password.RequireUppercase = false;
                            options.Password.RequireLowercase = false;
                        })
                    .AddEntityFrameworkStores<SportCenterDbContext>()
                    .AddDefaultTokenProviders();

            builder.Services.AddProjectRepositories(typeof(IExerciseRepository).Assembly);
            builder.Services.AddProjectServices(typeof(IExerciseService).Assembly);

            builder.Services
                    .ConfigureApplicationCookie(options =>
                        {
                            options.LoginPath = "/Identity/Account/Login";
                            options.AccessDeniedPath = "/Home/Error?statusCode=403";
                            options.SlidingExpiration = true;
                            options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                        });

            builder.Services
                     .AddControllersWithViews(options =>
                        {
                            options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                         });

            builder.Services
                     .AddRazorPages();

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error?statusCode=500");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //For the area routing, uncomment the following lines and adjust as needed
            //app.MapControllerRoute(
            //  name: "MyArea",
            //  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}
