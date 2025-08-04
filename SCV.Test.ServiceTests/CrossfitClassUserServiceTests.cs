namespace SCV.Test.ServiceTests
{
    using Microsoft.EntityFrameworkCore;
    // using Microsoft.EntityFrameworkCore;
    // using Microsoft.EntityFrameworkCore.Query;

    using MockQueryable.Moq;
    using Moq;
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.Administration.ReferenceVM;
    using SCV.Web.ViewModels.CrossfitVM;

    [TestFixture]
    public class CrossfitClassUserServiceTests
    {
        private Mock<ICrossfitClassUserRepository> mockRepo;
        private ICrossfitClassUserService crossfitClassUserService;
        private List<CrossfitClassUser> mockData;
        private Guid userId;
        private Guid classId;

        [SetUp]
        public void SetUp()
        {
            userId = Guid.NewGuid();
            classId = Guid.NewGuid();

            mockData = new List<CrossfitClassUser>
            {
                new CrossfitClassUser
                {
                    ApplicationUserId = userId,
                    CrossfitClassId = classId,
                    IsActive = true,
                    JoinedAt = DateTime.UtcNow,
                    CrossfitClass = new CrossfitClass
                    {
                        Name = "WOD: Hero Workout",
                        Description = "A high-intensity Hero WOD.",
                        DayOfWeek = DayOfWeek.Monday, //Use Enums!!
                        StartTime = "Monday at 17:00",
                        TrainerName = "Ivan Dimitrov"
                    },
                    ApplicationUser = new ApplicationUser
                    {
                        FullName = "Rado Petrov",
                        Email = "rado@test.com"
                    }
                }
            };

            mockRepo = new Mock<ICrossfitClassUserRepository>();
            crossfitClassUserService = new CrossfitClassUserService(mockRepo.Object);
        }

        [Test]
        public async Task GetCrossfitClassUserListAsync_ReturnsCorrectData()
        {
            var mockSet = mockData.AsQueryable().BuildMockDbSet();
            mockRepo.Setup(r => r.GetAllAttached())
                                    .Returns(mockSet.Object);

            IEnumerable<CrossfitClassUserDetailViewModel> result = await crossfitClassUserService
                                    .GetCrossfitClassUserListAsync(userId.ToString());

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().Name, Is.EqualTo("WOD: Hero Workout"));
        }

        [Test]
        public async Task AddUserToCrossfitClass_AddsNewEntry_ReturnsTrue()
        {
            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(new List<CrossfitClassUser>()
                    .AsQueryable()
                    .BuildMockDbSet().Object);

            mockRepo.Setup(r => r.AddAsync(It.IsAny<CrossfitClassUser>()))
                            .Returns(Task.CompletedTask);

            bool isAdded = await crossfitClassUserService
                                .AddUserToCrossfitClass(classId.ToString(), userId.ToString());

            Assert.IsTrue(isAdded);
        }

        [Test]
        public async Task AddUserToCrossfitClass_ReactivatesExistingEntry_ReturnsTrue()
        {
            CrossfitClassUser existingCrossfitClassUser = mockData.First();
            existingCrossfitClassUser.IsActive = false;

            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(new List<CrossfitClassUser> 
                                { 
                                    existingCrossfitClassUser 
                                }
                    .AsQueryable()
                    .BuildMockDbSet().Object);

            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<CrossfitClassUser>()))
                    .ReturnsAsync(true);

            bool isAdded = await crossfitClassUserService
                                    .AddUserToCrossfitClass(classId.ToString(), userId.ToString());

            Assert.IsTrue(isAdded);
        }

        [Test]
        public async Task RemoveUserFromCrossfitClassAsync_RemovesSuccessfully()
        {
            CrossfitClassUser crossfitClassUser = mockData.First();

            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(new List<CrossfitClassUser> 
                                        { 
                                            crossfitClassUser 
                                        }
                    .AsQueryable()
                    .BuildMockDbSet().Object);

            mockRepo.Setup(r => r.DeleteAsync(It.IsAny<CrossfitClassUser>()))
                    .ReturnsAsync(true);

            bool isRemoved = await crossfitClassUserService
                              .RemoveUserFromCrossfitClassAsync(classId.ToString(), userId.ToString());

            Assert.IsTrue(isRemoved);
        }

        [Test]
        public async Task IsUserAddedToCrossfitClassList_ActiveEntryExists_ReturnsTrue()
        {
            CrossfitClassUser crossfitClassUser = mockData.First();

            mockRepo.Setup(r => r.GetAllAttached())
                      .Returns(new List<CrossfitClassUser>
                                          {
                                            crossfitClassUser
                                          }
                      .AsQueryable()
                      .BuildMockDbSet().Object);

            bool isAdded = await crossfitClassUserService
                            .IsUserAddedToCrossfitClassList(classId.ToString(), userId.ToString());

            Assert.IsTrue(isAdded);
        }

        [Test]
        public async Task ForAdminCrossfitClassClientsListAsync_ReturnsCorrectList()
        {
            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(mockData.AsQueryable().BuildMockDbSet().Object);

            IEnumerable<UserCrossfitClassesForAdminListViewModel> result = await crossfitClassUserService
                                    .ForAdminCrossfitClassClientsListAsync();

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().ClientEmail, Is.EqualTo("rado@test.com"));
        }
    }

}
