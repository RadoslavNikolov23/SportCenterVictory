namespace SCV.Test.ServiceTests
{
    using MockQueryable.Moq;
    using Moq;
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core;
    using SCV.Services.Core.EventServices.Contracts;
    using SCV.Web.ViewModels.Administration.ReferenceVM;
    using SCV.Web.ViewModels.CommonVM;

    [TestFixture]
    public class EventUserServiceTests
    {
        private Mock<IEventUserRepository> repoMock;
        private IEventUserService eventUserService;

        [SetUp]
        public void Setup()
        {
            repoMock = new Mock<IEventUserRepository>();
            eventUserService = new EventUserService(repoMock.Object);
        }

        [Test]
        public async Task GetEventUserListAsync_ReturnsCorrectData()
        {
            DateTime today = DateTime.Now;
            Guid userId = Guid.NewGuid();
            IQueryable<EventUser> events = new List<EventUser>
            {
                new EventUser
                {
                    ApplicationUserId = userId,
                    Event = new Event
                    {
                        Id = Guid.NewGuid(),
                        Title = "Test Fitness Event",
                        EventType = SportType.Fitness,
                        StartDate = today,
                        Description = "Test Fitness Description",
                        Location = "Ruse",
                        ImageUrl = "fitnessEvent.jpg",
                    }
                }
            }
            .AsQueryable();

            var mockSet = events.BuildMockDbSet();

            repoMock.Setup(r => r.GetAllAttached()).Returns(mockSet.Object);

            IEnumerable<EventUserDetailViewModel> resultEnumerable = await eventUserService
                .GetEventUserListAsync(userId.ToString());

            IList<EventUserDetailViewModel> result = resultEnumerable.ToList();

            Assert.That(result.Count(), Is.EqualTo(1));

            Assert.That(result.First().Title, Is.EqualTo("Test Fitness Event"));
            Assert.That(result.First().EventType, Is.EqualTo(SportType.Fitness));
            Assert.That(result.First().Location, Is.EqualTo("Ruse"));
            Assert.That(result.First().ImageUrl, Is.EqualTo("fitnessEvent.jpg"));

        }

        [Test]
        public async Task AddUserToEvent_AddsNewUserSuccessfully()
        {
            Guid userId = Guid.NewGuid();
            Guid eventId = Guid.NewGuid();

            IQueryable<EventUser> users = new List<EventUser>()
                                    .AsQueryable();
            var mockSet = users.BuildMockDbSet();

            repoMock.Setup(r => r.GetAllAttached()).Returns(mockSet.Object);
            repoMock.Setup(r => r.AddAsync(It.IsAny<EventUser>())).Returns(Task.CompletedTask);

            bool isAdded = await eventUserService
                                    .AddUserToEvent(eventId.ToString(), userId.ToString());

            Assert.IsTrue(isAdded);
        }

        [Test]
        public async Task RemoveUserFromEventAsync_RemovesSuccessfully()
        {
            Guid userId = Guid.NewGuid();
            Guid eventId = Guid.NewGuid();

            IQueryable<EventUser> existing = new List<EventUser>
            {
                new EventUser 
                { 
                    ApplicationUserId = userId, 
                    EventId = eventId, 
                    IsDeleted = false 
                }
            }
            .AsQueryable();

            var mockSet = existing.BuildMockDbSet();
            repoMock.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);
            repoMock.Setup(r => r.DeleteAsync(It.IsAny<EventUser>()))
                    .ReturnsAsync(true);

            bool isRemoved = await eventUserService
                                .RemoveUserFromEventAsync(eventId.ToString(), userId.ToString());

            Assert.IsTrue(isRemoved);
        }

        [Test]
        public async Task IsUserAddedToEventList_ReturnsTrueIfFound()
        {
            Guid userId = Guid.NewGuid();
            Guid eventId = Guid.NewGuid();

            IQueryable<EventUser> eventUserList = new List<EventUser>
            {
                new EventUser
                {
                    ApplicationUserId = userId,
                    EventId = eventId,
                    IsDeleted = false
                }
            }
            .AsQueryable();

            var mockSet = eventUserList.BuildMockDbSet();
            repoMock.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);

            bool isAdded = await eventUserService
                        .IsUserAddedToEventList(eventId.ToString(), userId.ToString());

            Assert.IsTrue(isAdded);
        }

        [Test]
        public async Task ForAdminEventUsersListAsync_ReturnsExpectedList()
        {
            IQueryable<EventUser> data = new List<EventUser>
            {
                new EventUser
                {
                    ApplicationUser = new ApplicationUser
                    {
                        Email = "test@test.com",
                        FullName = "Test User"
                    },
                    Event = new Event
                    {
                        Title = "Test Fitness Event",
                        StartDate = DateTime.UtcNow,
                        EventType = SportType.Fitness,
                        Location = "Test Location - Ruse"
                    }
                }
            }.AsQueryable();

            var mockSet = data.BuildMockDbSet();
            repoMock.Setup(r => r.GetAllAttached()).Returns(mockSet.Object);

            IEnumerable<EventsUserForAdminListViewModel> resultEnumrable = await eventUserService
                                        .ForAdminEventUsersListAsync();

            IList<EventsUserForAdminListViewModel> result = resultEnumrable.ToList();

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().ClientFullName, Is.EqualTo("Test User"));

            Assert.That(result.First().ClientFullName, Is.EqualTo("Test User"));
            Assert.That(result.First().ClientEmail, Is.EqualTo("test@test.com"));
            Assert.That(result.First().EventTitle, Is.EqualTo("Test Fitness Event"));
            Assert.That(result.First().EventLocation, Is.EqualTo("Test Location - Ruse"));
            Assert.That(result.First().EventType, Is.EqualTo(SportType.Fitness));

        }
    }
}
