namespace SCV.Data.Seeding
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    using System;
    using System.Data;
    using System.Threading.Tasks;

    using SCV.GlCommon;
    using SCV.Data.Models;
    using SCV.Data.Seeding.Contracts;
    using SCV.Data.Seeding.DTOs;

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
            //Admin
                ("admin@sportcentervictory.com", "Admin User - Rado", "Admin123!", RoleConstants.Admin),
            //Manager
                ("manager@sportcentervictory.com", "Manager Rado", "Rado123!", RoleConstants.Manager),
            //Trainers
                ("viktornachev@sportcentervictory.com", "Viktor Nachev", "Victor123!", RoleConstants.Trainer),
                ("sofiazlateva@sportcentervictory.com", "Sofia Zlateva", "Sofia123!", RoleConstants.Trainer),
                ("desislaviliev@sportcentervictory.com", "Desislav Iliev", "Desislav123!", RoleConstants.Trainer),
                ("ivandimitrov@sportcentervictory.com", "Ivan Dimitrov", "Ivan123!", RoleConstants.Trainer),
                ("mayaivanova@sportcentervictory.com", "Maya Ivanova", "Maya123!", RoleConstants.Trainer),
                ("georgikolev@sportcentervictory.com", "Georgi Kolev", "Georgi123!", RoleConstants.Trainer),
                ("kristinadimitrova@sportcentervictory.com", "Kristina Dimitrova", "Kristina123!", RoleConstants.Trainer),
                ("stefantodorov@sportcentervictory.com", "Stefan Todorov", "Stefan123!", RoleConstants.Trainer),
            //Users
                ("victoriadimitrova@sportcentervictory.com", "Victoria Dimitrova", "Victoria123!", RoleConstants.User),
                ("ivanpetrov@sportcentervictory.com", "Ivan Petrov", "Ivan123!", RoleConstants.User),
                ("mariastefanova@sportcentervictory.com", "Maria Stefanova", "Maria123!", RoleConstants.User),
                ("stefanivanov@sportcentervictory.com", "Stefan Ivanov", "Stefan123!", RoleConstants.User),
                ("evamateeva@sportcentervictory.com", "Eva Mateeva", "Eva123!", RoleConstants.User),
                ("martindakov@sportcentervictory.com", "Martin Dakov", "Maria123!", RoleConstants.User)
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

                  await SeedTrainerAsync();
            }
        }

        private async Task SeedUserFeedbackAsync()
        {
            //if (await dbContext.UserFeedbacks.AnyAsync())
            //{
            //    return;
            //}

            string jsonPath = Path.Combine(Path.Combine("..", "SCV.Data", "SeedFiles", "UserFeedbacks", "userFeedbackSeed.json"));

            if (!File.Exists(jsonPath))
            {
                return;
            }

            string jsonFile = await File
                                .ReadAllTextAsync(jsonPath);

            UserFeedbackDTO[]? userFeedbacksDTO = JsonConvert
                                        .DeserializeObject<UserFeedbackDTO[]>(jsonFile);

            if (userFeedbacksDTO == null || userFeedbacksDTO.Length == 0)
            {
                return;
            }

            foreach (UserFeedbackDTO userFeedback in userFeedbacksDTO)
            {
                ApplicationUser? user = await dbContext
                                                .Users
                                                .FirstOrDefaultAsync(u => u.UserName == userFeedback.UserName);

                bool alreadySeeded = await dbContext
                                                .UserFeedbacks
                                                .AnyAsync(f => f.UserName == userFeedback.UserName);

                if (user != null && !alreadySeeded)
                {
                    UserFeedback feedback = new UserFeedback
                    {
                        UserName = userFeedback.UserName,
                        FullName = userFeedback.FullName,
                        Feedback = userFeedback.Feedback,
                        Status = userFeedback.Status,
                        ImageUrl = userFeedback.ImageUrl,
                        UserId = user.Id
                    };

                    await dbContext.UserFeedbacks.AddAsync(feedback);
                }
            }

            await dbContext.SaveChangesAsync();
        }

        private async Task SeedTrainerAsync()
        {
            //if (await dbContext.UserFeedbacks.AnyAsync())
            //{
            //    return;
            //}

            string jsonPath = Path.Combine(Path.Combine("..", "SCV.Data", "SeedFiles", "Trainers", "trainersSeed.json"));

            if (!File.Exists(jsonPath))
            {
                return;
            }

            string jsonFile = await File
                                .ReadAllTextAsync(jsonPath);

            TrainerDTO[]? trainersDTO = JsonConvert
                                        .DeserializeObject<TrainerDTO[]>(jsonFile);

            if (trainersDTO == null || trainersDTO.Length == 0)
            {
                return;
            }

            foreach (TrainerDTO trainer in trainersDTO)
            {
                ApplicationUser? user = await dbContext
                                                .Users
                                                .FirstOrDefaultAsync(u => u.Email == trainer.Email);

                bool alreadySeeded = await dbContext
                                                .Trainers
                                                .AnyAsync(f => f.Email == trainer.Email);

                if (user != null && !alreadySeeded)
                {
                    Trainer trainerEntity = new Trainer
                    {
                        FirstName = trainer.FirstName,
                        LastName = trainer.LastName,
                        Email = trainer.Email,
                        PhoneNumber = trainer.PhoneNumber,
                        Bio = trainer.Bio,
                        TrainerSpecialty = trainer.TrainerSpecialty,
                        ImageUrl = trainer.ImageUrl,
                        ApplicationUserId = user.Id
                    };

                    await dbContext.Trainers.AddAsync(trainerEntity);
                }
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
