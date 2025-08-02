using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SCV.Data;
namespace SportCenterVictory
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using SCV.Data;
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.Data.Seeding;
    using SCV.Data.Seeding.Contracts;
    using SCV.Services.Common;
    using SCV.Services.Core.Contracts;
    using SCV.Web.Infrastructure;

    public class Program
    {
        public static async Task Main(string[] args)
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

                            /*For production, you should set the following options to true:
                             * 
                                options.Password.RequireDigit = true;
                                options.Password.RequireNonAlphanumeric = true;
                                options.Password.RequireUppercase = true;
                                options.Password.RequireLowercase = true;
                                options.Password.RequiredLength = 8;
                                options.Password.RequiredUniqueChars = 1;
                             */
                        })
                    .AddEntityFrameworkStores<SportCenterDbContext>()
                    .AddDefaultTokenProviders();

            builder.Services.AddScoped<IApplicationDbInitializer, ApplicationDbInitializer>();

            builder.Services.Configure<EmailSettings>(builder.Configuration
                                                                .GetSection("EmailSettings"));

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
                     .AddControllersWithViews()
                     .AddMvcOptions(options =>
                        {
                            options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
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

            await app.SeedDatabaseAsync();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
              name: "Administration",
              pattern: "{area}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            await app.RunAsync();
        }
    }
}
