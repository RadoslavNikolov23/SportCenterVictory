namespace SCV.Data.Seeding
{
    using Microsoft.AspNetCore.Identity;
    using SCV.Data.Models;
    using SCV.Data.Seeding.Contracts;
    using SCV.GlCommon;
    using System;
    using System.Data;
    using System.Threading.Tasks;

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
                return;

            //string jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "SCV.Data", "SeedFiles", "UserFeedbacks", "userfeedback.json");
            string jsonPath = Path.Combine(Path.Combine("..", "SCV.Data", "SeedFiles", "UserFeedbacks", "userFeedbackSeed.json")));

            if (!File.Exists(jsonPath))
                return;

            string jsonFile = await File.ReadAllTextAsync(jsonPath);
            var feedbacks = JsonSerializer.Deserialize<List<UserFeedbackJsonModel>>(jsonFile);

            //For the feedbacks, change to this code
             //  T[] genericListEntities = JsonConvert
            //                                 .DeserializeObject<T[]>(jsonFile)!;

            if (feedbacks == null || feedbacks.Count == 0)
                return;

            foreach (var feedbackModel in feedbacks)
            {
                var user = await dbContext.Users.FirstOrDefaultAsync(u => u.FullName == feedbackModel.UserName);

                if (user != null)
                {
                    var feedback = new UserFeedback
                    {
                        UserName = feedbackModel.UserName,
                        Feedback = feedbackModel.Feedback,
                        ImageUrl = feedbackModel.ImageUrl,
                        UserId = user.Id
                    };

                    dbContext.UserFeedbacks.Add(feedback);
                }
            }

            await dbContext.SaveChangesAsync();
        }

        //Move to folder DTOs and a sepperated class
        private class UserFeedbackJsonModel
        {
            public int Id { get; set; }
            public string UserName { get; set; } = null!;
            public string Feedback { get; set; } = null!;
            public string ImageUrl { get; set; } = null!;
        }
    
    }
}
