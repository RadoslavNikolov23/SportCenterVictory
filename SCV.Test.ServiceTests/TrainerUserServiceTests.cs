namespace SCV.Test.ServiceTests
{
    using MockQueryable.Moq;
    using Moq;
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.TrainerServices;
    using SCV.Services.Core.TrainerServices.Contracts;
    using SCV.Web.ViewModels.Administration.ReferenceVM;
    using SCV.Web.ViewModels.TrainerVM;
    using System;
    using System.Linq;

    [TestFixture]
    public class TrainerUserServiceTests
    {
        private Mock<ITrainerUserRepository> mockRepo;
        private ITrainerUserService trainerUserService;

        [SetUp]
        public void SetUp()
        {
            mockRepo = new Mock<ITrainerUserRepository>();
            trainerUserService = new TrainerUserService(mockRepo.Object);
        }

        [Test]
        public async Task GetTrainerUserListAsync_ReturnsCorrectViewModels()
        {
            Guid userId = Guid.NewGuid();
            Guid trainerId = Guid.NewGuid();

            IQueryable<TrainerUser> data = new List<TrainerUser>
            {
                new TrainerUser
                {
                    ApplicationUserId = userId,
                    TrainerId = trainerId,
                    Trainer = new Trainer
                    {
                        Id = trainerId,
                        FirstName = "Maya",
                        LastName = "Ivanova",
                        Email = "mayaivanova@sportcentervictory.com",
                        PhoneNumber = "+359885987654",
                        Bio = "CrossFit expert with over 10 years of personal training experience.",
                        TrainerSpecialty = SportType.CrossFit,
                        ImageUrl = "maya.jpg"
                    }
                }
            }.AsQueryable();

            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(data.BuildMockDbSet().Object);

            IEnumerable<TrainerUserDetailViewModel> result = await trainerUserService
                            .GetTrainerUserListAsync(userId.ToString());

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().TrainerId, Is.EqualTo(trainerId.ToString()));
            Assert.That(result.First().FirstName, Is.EqualTo("Maya"));
            Assert.That(result.First().LastName, Is.EqualTo("Ivanova"));
            Assert.That(result.First().Email, Is.EqualTo("mayaivanova@sportcentervictory.com"));
            Assert.That(result.First().ImageUrl, Is.EqualTo("maya.jpg"));
        }

        [Test]
        public async Task AllClientsTrainerListAsync_ReturnsClientList()
        {
            Guid trainerId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();


            ApplicationUser userRado = new ApplicationUser
            {
                Id = userId,
                Email = "rado@test.com",
                FullName = "Rado Georgiev"
            };

            Trainer trainerRado = new Trainer
            {
                Id = trainerId,
                ApplicationUserId = userId
            };

            IQueryable<TrainerUser> data = new List<TrainerUser>
            {
                new TrainerUser
                {
                    ApplicationUserId = userId,
                    ApplicationUser = userRado,
                    TrainerId = trainerId,
                    Trainer = trainerRado
                }
            }.AsQueryable();

            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(data.BuildMockDbSet().Object);

            var result = await trainerUserService
                                .AllClientsTrainerListAsync(userId.ToString());

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().FullName, Is.EqualTo("Rado Georgiev"));
        }

        [Test]
        public async Task AddUserToTrainer_AddsWhenNotExisting()
        {
            Guid trainerId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();

            IQueryable<TrainerUser> emptyData = new List<TrainerUser>()
                                                       .AsQueryable();

            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(emptyData.BuildMockDbSet().Object);
            mockRepo.Setup(r => r.AddAsync(It.IsAny<TrainerUser>()))
                    .Returns(Task.CompletedTask);

            bool isAdded = await trainerUserService
                                .AddUserToTrainer(trainerId.ToString(), userId.ToString());

            Assert.That(isAdded, Is.True);
        }

        [Test]
        public async Task AddUserToTrainer_UpdatesWhenExisting()
        {
            Guid trainerId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();


            IQueryable<TrainerUser> data = new List<TrainerUser>
            {
                new TrainerUser
                {
                    ApplicationUserId = userId,
                    TrainerId = trainerId,
                    IsDeleted = true
                }
            }.AsQueryable();

            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(data.BuildMockDbSet().Object);
            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<TrainerUser>()))
                    .ReturnsAsync(true);

            bool isAdded = await trainerUserService
                        .AddUserToTrainer(trainerId.ToString(), userId.ToString());

            Assert.That(isAdded, Is.True);
        }

        [Test]
        public async Task RemoveTrainerFromUserAsync_RemovesIfExists()
        {
            Guid trainerId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();


            IQueryable<TrainerUser> data = new List<TrainerUser>
            {
                new TrainerUser
                {
                    ApplicationUserId = userId,
                    TrainerId = trainerId,
                    IsDeleted = false
                }
            }.AsQueryable();

            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(data.BuildMockDbSet().Object);
            mockRepo.Setup(r => r.DeleteAsync(It.IsAny<TrainerUser>()))
                    .ReturnsAsync(true);

            bool isRemoved = await trainerUserService
                        .RemoveTrainerFromUserAsync(trainerId.ToString(), userId.ToString());

            Assert.That(isRemoved, Is.True);
        }

        [Test]
        public async Task IsTrainerAddedToUserList_ReturnsTrueIfExists()
        {
            Guid trainerId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();

            IQueryable<TrainerUser> data = new List<TrainerUser>
            {
                new TrainerUser
                {
                    ApplicationUserId = userId,
                    TrainerId = trainerId,
                    IsDeleted = false
                }
            }.AsQueryable();

            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(data.BuildMockDbSet().Object);

            bool isTrainerAdded = await trainerUserService
                        .IsTrainerAddedToUserList(trainerId.ToString(), userId.ToString());

            Assert.That(isTrainerAdded, Is.True);
        }

        [Test]
        public async Task ForAdminTrainerClientsListAsync_ReturnsList()
        {
            Guid trainerId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();

            IQueryable<TrainerUser> data = new List<TrainerUser>
            {
                new TrainerUser
                {
                    ApplicationUser = new ApplicationUser
                    {
                        FullName = "Rado Georgiev",
                        Email = "rado@test.com"
                    },
                    Trainer = new Trainer
                    {
                        FirstName = "Maya",
                        LastName = "Ivanova",
                        Email = "mayaivanova@sportcentervictory.com",
                        PhoneNumber = "+359885987654",
                        Bio = "CrossFit expert with over 10 years of personal training experience.",
                        TrainerSpecialty = SportType.CrossFit,
                        ImageUrl = "maya.jpg"
                    }
                }
            }.AsQueryable();

            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(data.BuildMockDbSet().Object);

            IEnumerable<TrainerUserForAdminListViewModel> result = await trainerUserService
                    .ForAdminTrainerClientsListAsync();

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().ClientEmail, Is.EqualTo("rado@test.com"));
            Assert.That(result.First().ClientFullName, Is.EqualTo("Rado Georgiev"));
            Assert.That(result.First().TrainerFullName, Is.EqualTo("Maya Ivanova"));
            Assert.That(result.First().TrainerEmail, Is.EqualTo("mayaivanova@sportcentervictory.com"));
        }
    }
}
