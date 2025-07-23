namespace SCV.Data.Seeding
{
    using System;
    using System.Data;
    using System.Threading.Tasks;
    using SCV.GlCommon;
    using SCV.Data.Models;
    using SCV.Data.Seeding.Contracts;
    using SCV.Data.Seeding.DTOs;
    using Newtonsoft.Json;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbInitializer : IApplicationDbInitializer
    {
        private readonly string[] DefaultRoles = new[]
                                   {
                                        RoleConstants.Admin,
                                        RoleConstants.Manager,
                                        RoleConstants.Trainer,
                                        RoleConstants.User
                                    };

        private readonly List<(string, string, string, string)> DefaultUsersToSeed = new List<(string email, string fullName, string password, string role)>
            {
                ("admin@sportcentervictory.com", "Admin User - Rado", "Admin123!", RoleConstants.Admin),

                ("manager@sportcentervictory.com", "Manager Rado", "Rado123!", RoleConstants.Manager),

                ("viktornachev@sportcentervictory.com", "Viktor Nachev", "Victor123!", RoleConstants.Trainer),
                ("sofiazlateva@sportcentervictory.com", "Sofia Zlateva", "Sofia123!", RoleConstants.Trainer),
                ("desislaviliev@sportcentervictory.com", "Desislav Iliev", "Desislav123!", RoleConstants.Trainer),
                ("ivandimitrov@sportcentervictory.com", "Ivan Dimitrov", "Ivan123!", RoleConstants.Trainer),
                ("mayaivanova@sportcentervictory.com", "Maya Ivanova", "Maya123!", RoleConstants.Trainer),
                ("georgikolev@sportcentervictory.com", "Georgi Kolev", "Georgi123!", RoleConstants.Trainer),
                ("kristinadimitrova@sportcentervictory.com", "Kristina Dimitrova", "Kristina123!", RoleConstants.Trainer),
                ("stefantodorov@sportcentervictory.com", "Stefan Todorov", "Stefan123!", RoleConstants.Trainer),

                ("victoriadimitrova@sportcentervictory.com", "Victoria Dimitrova", "Victoria123!", RoleConstants.User),
                ("ivanpetrov@sportcentervictory.com", "Ivan Petrov", "Ivan123!", RoleConstants.User),
                ("mariastefanova@sportcentervictory.com", "Maria Stefanova", "Maria123!", RoleConstants.User)
            };

        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly SportCenterDbContext dbContext;


        public ApplicationDbInitializer(UserManager<ApplicationUser> userManager,RoleManager<ApplicationRole> roleManager, SportCenterDbContext dbContext)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.dbContext = dbContext;
        }

        public async Task SeedUsersAndRolesAsync()
        {

            foreach (string role in this.DefaultRoles)
            {
                if (!await this.roleManager.RoleExistsAsync(role))
                {
                    await this.roleManager.CreateAsync(new ApplicationRole { Name = role });
                }
            }

            foreach (var (email, fullName, password, role) in this.DefaultUsersToSeed)
            {
                ApplicationUser? user = await userManager.FindByEmailAsync(email);

                if (user == null)
                {
                    user = new ApplicationUser
                    {
                        UserName = email,
                        Email = email,
                        FullName = fullName,
                        EmailConfirmed = true,
                        RegisteredOn = DateTime.UtcNow
                    };

                    IdentityResult result = await userManager.CreateAsync(user, password);

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, role);
                    }
                    else
                    {
                        throw new Exception($"Failed to create user {email}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                    }
                }

                  await SeedUserFeedbackAsync();
            }
        }

        private async Task SeedUserFeedbackAsync()
        {
            if (await dbContext.UserFeedbacks.AnyAsync())
            {
                return;
            }

            //string jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "SCV.Data", "SeedFiles", "UserFeedbacks", "userfeedback.json");
            string jsonPath = Path.Combine(Path.Combine("..", "SCV.Data", "SeedFiles", "UserFeedbacks", "userFeedbackSeed.json"));

            if (!File.Exists(jsonPath))
            {
                return;
            }

            string jsonFile = await File
                                .ReadAllTextAsync(jsonPath);

            UserFeedbackDTO[]? userFeedbacksDTO = JsonConvert
                                        .DeserializeObject<UserFeedbackDTO[]>(jsonFile);

            //For the feedbacks, change to this code
             //  T[] genericListEntities = JsonConvert
            //                                 .DeserializeObject<T[]>(jsonFile)!;

            if (userFeedbacksDTO == null || userFeedbacksDTO.Length == 0)
            {
                return;
            }

            foreach (UserFeedbackDTO userFeedback in userFeedbacksDTO)
            {
                ApplicationUser? user = await dbContext
                                                .Users
                                                .FirstOrDefaultAsync(u => u.FullName == userFeedback.UserName);

                if (user != null)
                {
                    UserFeedback feedback = new UserFeedback
                    {
                        UserName = userFeedback.UserName,
                        Feedback = userFeedback.Feedback,
                        ImageUrl = userFeedback.ImageUrl,
                        UserId = user.Id
                    };

                    await dbContext.UserFeedbacks.AddAsync(feedback);
                }
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
