namespace SCV.Test.ServiceTests
{
    using MockQueryable.Moq;
    using Moq;
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.StoreServices;
    using SCV.Services.Core.StoreServices.Contracts;
    using SCV.Web.ViewModels.Administration.ReferenceVM;
    using SCV.Web.ViewModels.CommonVM;

    [TestFixture]
    public class MembershipUserServiceTests
    {
        private Mock<IMembershipUserRepository> repoMock;
        private IMembershipUserService membershipUserService;

        [SetUp]
        public void SetUp()
        {
            repoMock = new Mock<IMembershipUserRepository>();
            membershipUserService = new MembershipUserService(repoMock.Object);
        }

        [Test]
        public async Task GetMembershipUserListAsync_ReturnsCorrectData()
        {
            Guid userId = Guid.NewGuid();
            IQueryable<MembershipUser> membershipUsers = new List<MembershipUser>
            {
                new MembershipUser
                {
                    ApplicationUserId = userId,
                    MembershipId = Guid.NewGuid(),
                    PurchasedOn = new DateTime(2025, 8, 1),
                    Membership = new Membership
                    {
                        Name = "Fitness Standard",
                        MembershipType  = SportType.Fitness,
                        Description = "Basic access to gym equipment and cardio area. Includes 1 trainer session/month.",
                        Price  = 39.99m,
                        DurationText = "1 Month",
                        Duration  = 31
                    }
                }
            }.AsQueryable();

            var mockSet = membershipUsers.BuildMockDbSet();

            repoMock.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);

            IEnumerable<MembershipUserDetailViewModel> result = await membershipUserService
                            .GetMembershipUserListAsync(userId.ToString());

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().Name, Is.EqualTo("Fitness Standard"));
            Assert.That(result.First().MembershipType, Is.EqualTo(SportType.Fitness));

        }

        [Test]
        public async Task AddUserToMembership_AddsWhenNotExists()
        {
            string membershipId = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();

            IQueryable<MembershipUser> data = new List<MembershipUser>()
                                                    .AsQueryable();
            var mockSet = data.BuildMockDbSet();

            repoMock.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);
            repoMock.Setup(r => r.AddAsync(It.IsAny<MembershipUser>()))
                    .Returns(Task.CompletedTask);

            bool isAdded = await membershipUserService
                            .AddUserToMembership(membershipId, userId);

            Assert.IsTrue(isAdded);
        }

        [Test]
        public async Task RemoveUserFromMembershipAsync_RemovesWhenCanBeRemoved()
        {
            Guid membershipId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();

            MembershipUser membershipUser = new MembershipUser
            {
                MembershipId = membershipId,
                ApplicationUserId = userId,
                PurchasedOn = DateTime.UtcNow,
                IsDeleted = false
            };

            IQueryable<MembershipUser> data = new List<MembershipUser> 
                                            { 
                                                membershipUser 
                                            }
                                            .AsQueryable();
            var mockSet = data.BuildMockDbSet();

            repoMock.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);
            repoMock.Setup(r => r.DeleteAsync(It.IsAny<MembershipUser>()))
                    .ReturnsAsync(true);

            bool isRemoved = await membershipUserService
                        .RemoveUserFromMembershipAsync(membershipId.ToString(), userId.ToString());

            Assert.IsTrue(isRemoved);
        }

        [Test]
        public async Task IsUserAddedToMembershipList_ReturnsTrueIfUserExists()
        {
            Guid membershipId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();

            IQueryable<MembershipUser> data = new List<MembershipUser>
            {
                new MembershipUser
                {
                    MembershipId = membershipId,
                    ApplicationUserId = userId,
                    IsDeleted = false
                }
            }.AsQueryable();

            var mockSet = data.BuildMockDbSet();
            repoMock.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);

            bool isAdded = await membershipUserService
                        .IsUserAddedToMembershipList(membershipId.ToString(), userId.ToString());

            Assert.IsTrue(isAdded);
        }

        [Test]
        public async Task ForAdminMembershipClientsListAsync_ReturnsClientsCorrectly()
        {
            IQueryable<MembershipUser> data = new List<MembershipUser>
            {
                new MembershipUser
                {
                    Membership = new Membership
                    {   Name = "Fitness Standard",
                        MembershipType  = SportType.Fitness,
                        Description = "Basic access to gym equipment and cardio area. Includes 1 trainer session/month.",
                        Price  = 39.99m,
                        DurationText = "1 Month",
                        Duration  = 31
                    },
                    ApplicationUser = new ApplicationUser
                    {
                        FullName = "Rado Petrov",
                        Email = "rado@test.com"
                    },
                    PurchasedOn = new DateTime(2025, 8, 4)
                }
            }.AsQueryable();

            var mockSet = data.BuildMockDbSet();
            repoMock.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);

            IEnumerable<UserMembershipForAdminListViewModel> result = await membershipUserService
                    .ForAdminMembershipClientsListAsync();

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().ClientFullName, Is.EqualTo("Rado Petrov"));
            Assert.That(result.First().ClientEmail, Is.EqualTo("rado@test.com"));
            Assert.That(result.First().MembershipName, Is.EqualTo("Fitness Standard"));
            Assert.That(result.First().MembershipType, Is.EqualTo(SportType.Fitness));
        }

        [Test]
        public async Task CanUserRemovedIt_ReturnsTrueIfRemovable()
        {
            Guid membershipId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();
            MembershipUser membershipUser = new MembershipUser
            {
                MembershipId = membershipId,
                ApplicationUserId = userId,
                IsDeleted = false,
                PurchasedOn = DateTime.UtcNow
            };

            IQueryable<MembershipUser> data = new List<MembershipUser> 
                                                    { 
                                                        membershipUser 
                                                    }
                                                    .AsQueryable();
            var mockSet = data.BuildMockDbSet();
            repoMock.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);

            bool canBeRemoved = await membershipUserService
                                .CanUserRemovedIt(membershipId.ToString(), userId.ToString());

            Assert.IsTrue(canBeRemoved);
        }

        [Test]
        public async Task IsExpired_ReturnsTrueIfExpired()
        {
            Guid membershipId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();

            MembershipUser membershipUser = new MembershipUser
            {
                MembershipId = membershipId,
                ApplicationUserId = userId,
                IsDeleted = false,
                PurchasedOn = DateTime.UtcNow.AddDays(-31),
                Membership = new Membership 
                                    { 
                                        Duration = 30 
                                    }
            };

            IQueryable<MembershipUser> data = new List<MembershipUser> 
                                                    { 
                                                        membershipUser 
                                                    }
                                                    .AsQueryable();
            var mockSet = data.BuildMockDbSet();
            repoMock.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);

            bool isExpired = await membershipUserService
                                .IsExpired(membershipId.ToString(), userId.ToString());

            Assert.IsTrue(isExpired);
        }
    }
}
