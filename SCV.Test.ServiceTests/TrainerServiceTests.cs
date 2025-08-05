namespace SCV.Test.ServiceTests
{
    using Microsoft.AspNetCore.Identity;
    using MockQueryable.Moq;
    using Moq;

    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core;
    using SCV.Services.Core.TrainerServices.Contracts;
    using SCV.Web.ViewModels.Administration.TrainerBioVM;
    using SCV.Web.ViewModels.TrainerVM;

    using static SCV.GlCommon.RoleConstants;

    public class TrainerServiceTests
    {
        private Mock<ITrainerRepository> trainerRepoMock;
        private Mock<UserManager<ApplicationUser>> userManagerMock;
        private ITrainerService trainerService;

        [SetUp]
        public void Setup()
        {
            var store = new Mock<IUserStore<ApplicationUser>>();
            userManagerMock = new Mock<UserManager<ApplicationUser>>(store.Object, null!, null!, null!, null!, null!, null!, null!, null!);
            trainerRepoMock = new Mock<ITrainerRepository>();
            trainerService = new TrainerService(trainerRepoMock.Object, userManagerMock.Object);
        }

        [Test]
        public async Task GetAllTrainerBySpecialtiesAsync_ReturnsTrainers()
        {
            IQueryable<Trainer> trainers = new List<Trainer>
            {
                new Trainer
                    {

                        FirstName = "Viktor",
                        LastName = "Nachev",
                        Email = "viktornachev@sportcentervictory.com",
                        PhoneNumber = null,
                        Bio = "Certified fitness instructor and personal coach with a focus on fat loss and cardio endurance.",
                        TrainerSpecialty = SportType.Fitness,
                        ImageUrl = "viktor.jpg"
                    },
                new Trainer
                    {

                        FirstName = "Maya",
                        LastName = "Ivanova",
                        Email = "mayaivanova@sportcentervictory.com",
                        PhoneNumber = "+359885987654",
                        Bio = "CrossFit expert with over 10 years of personal training experience.",
                        TrainerSpecialty = SportType.CrossFit,
                        ImageUrl = "maya.jpg"
                    }

            }.AsQueryable();

            var mockSet = trainers.BuildMockDbSet();
            trainerRepoMock.Setup(r => r.GetAllAttached())
                           .Returns(mockSet.Object);

            IEnumerable<TrainerDetailViewModel> result = await trainerService
                                    .GetAllTrainerBySpecialtiesAsync(SportType.CrossFit);

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().FirstName, Is.EqualTo("Maya"));
            Assert.That(result.First().LastName, Is.EqualTo("Ivanova"));
            Assert.That(result.First().Email, Is.EqualTo("mayaivanova@sportcentervictory.com"));
        }

        [Test]
        public async Task GetAllTrainersForAdminAsync_ReturnsTrainers()
        {
            IQueryable<ApplicationUser> users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = Guid.NewGuid(),
                    FullName = "Rado Trainer",
                    Email = "trainer@demo.com"
                }
            }.AsQueryable();

            var mockUserSet = users.BuildMockDbSet();
            userManagerMock.Setup(u => u.Users)
                            .Returns(mockUserSet.Object);

            IEnumerable<TrainerAdminDetailViewModel> result = await trainerService
                                .GetAllTrainersForAdminAsync();

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().Email, Is.EqualTo("trainer@demo.com"));
        }

        [Test]
        public async Task AddTrainerBioAsync_WithValidInput_AddsTrainer()
        {
            TrainerBioAddViewModel model = new TrainerBioAddViewModel
            {
                FirstName = "Viktor",
                LastName = "Nachev",
                Email = "viktornachev@sportcentervictory.com",
                PhoneNumber = null,
                Bio = "Certified fitness instructor and personal coach with a focus on fat loss and cardio endurance.",
                TrainerSpecialty = SportType.Fitness,
                ImageUrl = "viktor.jpg",
                ApplicationUserId = Guid.NewGuid().ToString()
            };

            trainerRepoMock.Setup(r => r.AddAsync(It.IsAny<Trainer>()))
                            .Returns(Task.CompletedTask);

            bool isAdded = await trainerService
                            .AddTrainerBioAsync(model);

            Assert.IsTrue(isAdded);
        }

        [Test]
        public async Task GetTrainerBioByIdAsync_ReturnsTrainer()
        {
            Guid appUserId = Guid.NewGuid();
            Trainer trainer = new Trainer
            {
                Id = Guid.NewGuid(),
                FirstName = "Viktor",
                LastName = "Nachev",
                Email = "viktornachev@sportcentervictory.com",
                PhoneNumber = null,
                Bio = "Certified fitness instructor and personal coach with a focus on fat loss and cardio endurance.",
                TrainerSpecialty = SportType.Fitness,
                ImageUrl = "viktor.jpg",
                ApplicationUserId = appUserId,
                ApplicationUser = new ApplicationUser
                {
                    Id = appUserId
                }
            };

            IQueryable<Trainer> data = new List<Trainer>
                                            {
                                                trainer
                                            }
                                            .AsQueryable();
            var mockSet = data.BuildMockDbSet();

            trainerRepoMock.Setup(r => r.GetAllAttached())
                           .Returns(mockSet.Object);

            TrainerBioEditViewModel? result = await trainerService
                            .GetTrainerBioByIdAsync(appUserId.ToString());

            Assert.IsNotNull(result);
            Assert.That(result.FirstName, Is.EqualTo("Viktor"));
            Assert.That(result.LastName, Is.EqualTo("Nachev"));
            Assert.That(result.Email, Is.EqualTo("viktornachev@sportcentervictory.com"));
        }

        [Test]
        public async Task EditTrainerBioAsync_WithPermission_EditsTrainer()
        {
            Guid trainerId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();

            Trainer trainer = new Trainer
            {
                Id = trainerId,
                ApplicationUserId = userId
            };

            TrainerBioEditViewModel trainerBioVM = new TrainerBioEditViewModel
            {
                Id = trainerId.ToString(),
                FirstName = "Demo"
            };

            IQueryable<Trainer> trainers = new List<Trainer>
                                            {
                                                trainer
                                            }
                                            .AsQueryable();
            var mockSet = trainers.BuildMockDbSet();

            trainerRepoMock.Setup(r => r.GetAllAttached())
                           .Returns(mockSet.Object);
            trainerRepoMock.Setup(r => r.UpdateAsync(It.IsAny<Trainer>()))
                           .ReturnsAsync(true);

            ApplicationUser user = new ApplicationUser
            {
                Id = userId
            };

            userManagerMock.Setup(u => u.FindByIdAsync(userId.ToString()))
                           .ReturnsAsync(user);
            userManagerMock.Setup(u => u.GetRolesAsync(user))
                            .ReturnsAsync(new List<string>
                                                    {
                                                        Admin
                                                    });

            bool isEdited = await trainerService
                                    .EditTrainerBioAsync(trainerBioVM, userId.ToString());

            Assert.IsTrue(isEdited);
        }

        [Test]
        public async Task GetAllTrainerBiosForDeletingAsync_ReturnsTrainers()
        {
            Guid trainerId = Guid.NewGuid();
            Trainer trainer = new Trainer
            {
                Id = trainerId,
                FirstName = "Viktor",
                LastName = "Nachev",
                Email = "viktornachev@sportcentervictory.com",
                PhoneNumber = null,
                Bio = "Certified fitness instructor and personal coach with a focus on fat loss and cardio endurance.",
                TrainerSpecialty = SportType.Fitness,
                ImageUrl = "viktor.jpg",
                IsDeleted = false
            };

            IQueryable<Trainer> trainers = new List<Trainer>
                                                {
                                                    trainer
                                                }
                                               .AsQueryable();

            var mockSet = trainers.BuildMockDbSet();
            trainerRepoMock.Setup(r => r.GetAllAttached())
                           .Returns(mockSet.Object);

            IEnumerable<TrainerBioDeleteViewModel> result = await trainerService
                            .GetAllTrainerBiosForDeletingAsync();

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().FirstName, Is.EqualTo("Viktor"));
            Assert.That(result.First().LastName, Is.EqualTo("Nachev"));
            Assert.That(result.First().Email, Is.EqualTo("viktornachev@sportcentervictory.com"));
        }

        [Test]
        public async Task DeleteOrRestoreTrainerBioAsync_TogglesDeleteStatus()
        {
            Guid trainerId = Guid.NewGuid();
            Trainer trainer = new Trainer
            {
                Id = trainerId,
                FirstName = "Viktor",
                LastName = "Nachev",
                Email = "viktornachev@sportcentervictory.com",
                PhoneNumber = null,
                Bio = "Certified fitness instructor and personal coach with a focus on fat loss and cardio endurance.",
                TrainerSpecialty = SportType.Fitness,
                ImageUrl = "viktor.jpg",
                IsDeleted = false
            };

            IQueryable<Trainer> trainers = new List<Trainer>
                                                {
                                                    trainer
                                                }
                                                   .AsQueryable();
            var mockSet = trainers.BuildMockDbSet();

            trainerRepoMock.Setup(r => r.GetAllAttached())
                            .Returns(mockSet.Object);
            trainerRepoMock.Setup(r => r.UpdateAsync(It.IsAny<Trainer>()))
                            .ReturnsAsync(true);

            (bool success, bool isRestored) = await trainerService
                                .DeleteOrRestoreTrainerBioAsync(trainerId.ToString());

            Assert.That(success, Is.True);
            Assert.That(isRestored, Is.True);
        }
    }

}
