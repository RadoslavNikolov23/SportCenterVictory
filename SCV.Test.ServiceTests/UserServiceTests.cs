namespace SCV.Test.ServiceTests
{
    using Microsoft.AspNetCore.Identity;
    using MockQueryable.Moq;
    using Moq;
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.UserServices;
    using SCV.Services.Core.UserServices.Contracts;
    using SCV.Web.ViewModels.Administration.UserManagementVM;
    using System.Linq;
    using System.Linq.Expressions;

    [TestFixture]
    public class UserServiceTests
    {
        private Mock<UserManager<ApplicationUser>> mockUserManager;
        private Mock<RoleManager<ApplicationRole>> mockRoleManager;
        private Mock<ITrainerRepository> mockTrainerRepo;
        private IUserService userService;

        [SetUp]
        public void SetUp()
        {
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            mockUserManager = new Mock<UserManager<ApplicationUser>>(userStore.Object, null!, null!, null!, null!, null!, null!, null!, null!);

            var roleStore = new Mock<IRoleStore<ApplicationRole>>();
            mockRoleManager = new Mock<RoleManager<ApplicationRole>>(roleStore.Object, null!, null!, null!, null!);

            mockTrainerRepo = new Mock<ITrainerRepository>();
            userService = new UserService(mockUserManager.Object, mockRoleManager.Object, mockTrainerRepo.Object);
        }

        [Test]
        public async Task GetUserManagementBoardDataAsync_ReturnsUserListWithoutGivenUser()
        {
            Guid userId = Guid.NewGuid();
            IQueryable<ApplicationUser> users = new List<ApplicationUser>
        {
            new ApplicationUser
            {
                Id = Guid.NewGuid(),
                FullName = "Ivan Ivanov",
                Email = "ivan@example.com"
            },
            new ApplicationUser
            {
                Id = Guid.NewGuid(),
                FullName = "Petur Petrov",
                Email = "petur@example.com"
            }
        }.AsQueryable();

            var mockSet = users.BuildMockDbSet();
            mockUserManager.Setup(m => m.Users)
                            .Returns(mockSet.Object);

            mockUserManager.Setup(m => m.GetRolesAsync(It.IsAny<ApplicationUser>()))
                            .ReturnsAsync(new List<string> { "User" });

            IEnumerable<UserManagementIndexViewModel> result = await userService
                    .GetUserManagementBoardDataAsync(userId.ToString());

            Assert.That(result.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task UserExistsByIdAsync_ReturnsTrue_WhenUserExists()
        {
            mockUserManager.Setup(m => m.FindByIdAsync(It.IsAny<string>()))
                           .ReturnsAsync(new ApplicationUser());

            //Check if this works or not
            bool exists = await userService
                            .UserExistsByIdAsync("123");

            Assert.IsTrue(exists);
        }

        [Test]
        public async Task AssignUserToRoleAsync_AssignsRole_WhenValid()
        {
            ApplicationUser user = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                FullName = "Ivan Ivanov",
                Email = "ivan@example.com"
            };

            mockUserManager.Setup(m => m.FindByIdAsync(It.IsAny<string>()))
                           .ReturnsAsync(user);
            mockRoleManager.Setup(r => r.RoleExistsAsync(It.IsAny<string>()))
                           .ReturnsAsync(true);
            mockUserManager.Setup(m => m.AddToRoleAsync(user, It.IsAny<string>()))
                           .ReturnsAsync(IdentityResult.Success);

            bool isAssaigned = await userService
                                .AssignUserToRoleAsync(user.Id.ToString(), "Trainer");

            Assert.IsTrue(isAssaigned);
        }

        [Test]
        public void AssignUserToRoleAsync_Throws_WhenUserNotFound()
        {
            mockUserManager.Setup(m => m.FindByIdAsync(It.IsAny<string>())).ReturnsAsync((ApplicationUser)null);

            Assert.ThrowsAsync<ArgumentException>(() => userService
                                            .AssignUserToRoleAsync("123", "Manager"));
        }

        [Test]
        public async Task RemoveUserRoleAsync_RemovesRole_WhenUserInRole()
        {
            ApplicationUser user = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                FullName = "Ivan Ivanov",
                Email = "ivan@example.com"
            };

            mockUserManager.Setup(m => m.FindByIdAsync(It.IsAny<string>()))
                           .ReturnsAsync(user);
            mockRoleManager.Setup(r => r.RoleExistsAsync(It.IsAny<string>()))
                           .ReturnsAsync(true);
            mockUserManager.Setup(m => m.IsInRoleAsync(user, It.IsAny<string>()))
                           .ReturnsAsync(true);
            mockUserManager.Setup(m => m.RemoveFromRoleAsync(user, It.IsAny<string>()))
                           .ReturnsAsync(IdentityResult.Success);

            bool isRemovedRole = await userService
                        .RemoveUserRoleAsync(user.Id.ToString(), "User");

            Assert.IsTrue(isRemovedRole);
        }

        [Test]
        public async Task DeleteUserAsync_DeletesUserAndTrainer_WhenExists()
        {
            Guid userId = Guid.NewGuid();
            ApplicationUser user = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                FullName = "Ivan Ivanov",
                Email = "ivan@example.com"
            };

            Trainer trainer = new Trainer
            {
                FirstName = "Maya",
                LastName = "Ivanova",
                Email = "mayaivanova@sportcentervictory.com",
                PhoneNumber = "+359885987654",
                Bio = "CrossFit expert with over 10 years of personal training experience.",
                TrainerSpecialty = SportType.CrossFit,
                ImageUrl = "maya.jpg",
                ApplicationUserId = userId
            };


            mockUserManager.Setup(m => m.FindByIdAsync(userId.ToString()))
                           .ReturnsAsync(user);
            mockTrainerRepo?
                       .Setup(r => r.FirstOrDefaultAsync(It.IsAny<Expression<Func<Trainer, bool>>>()))
                       .ReturnsAsync(trainer);
            mockTrainerRepo!.Setup(r => r.HardDeleteAsync(trainer))
                           .ReturnsAsync(true);
            mockUserManager.Setup(m => m.DeleteAsync(user))
                           .ReturnsAsync(IdentityResult.Success);

            bool isDeleted = await userService.DeleteUserAsync(userId.ToString());

            Assert.IsTrue(isDeleted);
        }
    }
}
