namespace SCV.Test.ServiceTests
{
    using Moq;
    using MockQueryable.Moq;

    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.EventServices;
    using SCV.Web.ViewModels.Administration.EventVM;
    using SCV.Web.ViewModels.CommonVM;
    using SCV.Services.Core.EventServices.Contracts;

    [TestFixture]
    public class EventServiceTests
    {
        private Mock<IEventRepository> mockRepo;
        private IEventService eventService;

        [SetUp]
        public void Setup()
        {
            mockRepo = new Mock<IEventRepository>();
            eventService = new EventService(mockRepo.Object);
        }

        [Test]
        public async Task GetAllEventByEventTypeAsync_ReturnsFilteredEvents()
        {
            DateTime today = DateTime.Today;
            IQueryable<Event> data = new List<Event>
            {
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Crossfit Open Night",
                    EventType = SportType.CrossFit,
                    StartDate = today,
                    Location = "Gym - Ruse",
                    Description = "Test"
                    },
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Running Fitness Event",
                    EventType = SportType.Fitness,
                    StartDate = today.AddDays(10),
                    Description = "Sport Center Victory - Ruse"
                }
             }
             .AsQueryable();

            var mockSet = data.BuildMockDbSet();
            mockRepo.Setup(r => r.GetAllAttached())
                                .Returns(mockSet.Object);

            IEnumerable<EventDetailViewModel> resultEnumerable = await eventService.GetAllEventByEventTypeAsync(SportType.CrossFit);

            IList<EventDetailViewModel> result = resultEnumerable.ToList();

            Assert.That(result.Count(), Is.EqualTo(1));

            Assert.That(result[0].Title, Is.EqualTo("Crossfit Open Night"));
            Assert.That(result[0].EventType, Is.EqualTo(SportType.CrossFit));
            Assert.That(result[0].Location, Is.EqualTo("Gym - Ruse"));
            Assert.That(result[0].Description, Is.EqualTo("Test"));

        }

        [Test]
        public async Task GetAllEventForAdminAsync_ReturnsAllEvents()
        {
            IQueryable<Event> data = new List<Event>
            {
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Crossfit Open Night",
                    EventType = SportType.CrossFit,
                    StartDate = DateTime.Now,
                    Location = "Gym - Ruse",
                    Description = "Test"
                },
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Running Fitness Event",
                    EventType = SportType.Fitness,
                    StartDate = DateTime.Now.AddDays(10),
                    Location = "Sport Center Victory - Ruse",
                    Description = "Test Ruse"
                }
            }
            .AsQueryable();

            var mockSet = data.BuildMockDbSet();
            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);

            IEnumerable<EventAdminDetailViewModel> resultEnumerable = await eventService
                                        .GetAllEventForAdminAsync();

            IList<EventAdminDetailViewModel> result = resultEnumerable.ToList();

            Assert.That(result.Count(), Is.EqualTo(2));

            Assert.That(result[0].Title, Is.EqualTo("Crossfit Open Night"));
            Assert.That(result[1].Title, Is.EqualTo("Running Fitness Event"));
  
        }

        [Test]
        public async Task AddEventAsync_AddsEvent_WhenModelIsValid()
        {
            EventAddViewModel eventViewModel = new EventAddViewModel
            {
                Title = "Test Fitness Event",
                EventType = SportType.Fitness,
                StartDate = DateTime.UtcNow,
                Description = "Test Fitness Description",
                Location = "Ruse",
                ImageUrl = "fitnessEvent.jpg"
            };

            mockRepo.Setup(r => r.AddAsync(It.IsAny<Event>())).Returns(Task.CompletedTask);

            bool isAdded = await eventService.AddEventAsync(eventViewModel);

            Assert.IsTrue(isAdded);

        }

        [Test]
        public async Task GetEventByIdAsync_ReturnsEvent_WhenExists()
        {
            Guid eventId = Guid.NewGuid();
            DateTime starDate= DateTime.UtcNow;

            IQueryable<Event> data = new List<Event>
                {
                    new Event
                    {
                        Id = eventId,
                        Title = "Test Fitness Event",
                        EventType = SportType.Fitness,
                        StartDate = starDate,
                        Location = "Ruse",
                        Description = "Test Fitness Description",
                        ImageUrl = "fitnessEvent.jpg"
                    }
                }
                .AsQueryable();

            var mockSet = data.BuildMockDbSet();
            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);

            EventEditViewModel? result = await eventService
                                .GetEventByIdAsync(eventId.ToString());

            Assert.IsNotNull(result);
            Assert.That(result.Title, Is.EqualTo("Test Fitness Event"));
            Assert.That(result.EventType, Is.EqualTo(SportType.Fitness));
            Assert.That(result.StartDate, Is.EqualTo(starDate));
            Assert.That(result.Location, Is.EqualTo("Ruse"));
            Assert.That(result.Description, Is.EqualTo("Test Fitness Description"));
            Assert.That(result.ImageUrl, Is.EqualTo("fitnessEvent.jpg"));
        }

        [Test]
        public async Task EditEventAsync_UpdatesEvent_WhenExists()
        {
            Guid id = Guid.NewGuid();
            Event entity = new Event
            {
                Id = id,
                Title = "Test Fitness Event",
                EventType = SportType.Fitness,
                StartDate = DateTime.UtcNow,
                Location = "Ruse",
                Description = "Test Fitness Description",
                ImageUrl = "fitnessEvent.jpg"
            };

            IQueryable<Event> eventList = new List<Event> { entity }.AsQueryable();
            var mockSet = eventList.BuildMockDbSet();

            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);
            mockRepo.Setup(r => r.UpdateAsync(entity))
                .   ReturnsAsync(true);

            EventEditViewModel eventEditViewModel = new EventEditViewModel 
                                { 
                                    Id = id.ToString(), 
                                    Title = "New Test Title" 
                                };

            bool isEdit = await eventService.EditEventAsync(eventEditViewModel);

            Assert.IsTrue(isEdit);
        }

        [Test]
        public async Task GetAllEventForDeletingAsync_ReturnsAllWithDeletedStatus()
        {

            IQueryable<Event> data = new List<Event>
            {
                 new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Crossfit Open Night",
                    EventType = SportType.CrossFit,
                    StartDate = DateTime.Now,
                    Location = "Gym - Ruse",
                    Description = "Test",
                        IsDeleted = false
                },
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Running Fitness Event",
                    EventType = SportType.Fitness,
                    StartDate = DateTime.Now.AddDays(10),
                    Location = "Sport Center Victory - Ruse",
                    Description = "Test Ruse",
                        IsDeleted = true
                }
            }
            .AsQueryable();

            var mockSet = data.BuildMockDbSet();
            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);

            IEnumerable<EventDeleteViewModel> result = await eventService
                                    .GetAllEventForDeletingAsync();

            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.IsTrue(result.Any(e => e.IsDeleted));
        }

        [Test]
        public async Task DeleteOrRestoreEventAsync_TogglesIsDeletedFlag()
        {
            Guid eventId = Guid.NewGuid();
            Event entity = new Event
            {
                Id = eventId,
                Title = "Crossfit Open Night",
                EventType = SportType.CrossFit,
                StartDate = DateTime.Now,
                Location = "Gym - Ruse",
                Description = "Test",
                IsDeleted = false
            };

            IQueryable<Event> data = new List<Event> 
                                        { 
                                            entity 
                                        }
                                        .AsQueryable();

            var mockSet = data.BuildMockDbSet();

            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);
            mockRepo.Setup(r => r.UpdateAsync(entity))
                    .ReturnsAsync(true);

            (bool result, bool restored) = await eventService
                                    .DeleteOrRestoreEventAsync(eventId.ToString());

            Assert.IsTrue(result);
            Assert.IsTrue(restored);
            Assert.IsTrue(entity.IsDeleted);
        }
    }
}
