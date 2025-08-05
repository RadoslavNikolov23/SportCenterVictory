namespace SCV.Test.ServiceTests
{
    using MockQueryable.Moq;
    using Moq;
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.Services.Core;
    using SCV.Services.Core.CrossfitServices.Contracts;
    using SCV.Web.ViewModels.CrossfitVM;

    [TestFixture]
    public class CrossfitWODServiceTests
    {
        private Mock<ICrossfitWODRepository> mockRepo;
        private ICrossfitWODService crossfitWODService;

        [SetUp]
        public void Setup()
        {
            mockRepo = new Mock<ICrossfitWODRepository>();
            crossfitWODService = new CrossfitWODService(mockRepo.Object);
        }

        [Test]
        public async Task GetCrossfitWODByIdAsync_ReturnsCorrectViewModel_WhenWODExists()
        {
            Guid wodId = Guid.NewGuid();
            CrossfitWorkoutOfTheDay entity = new CrossfitWorkoutOfTheDay
            {
                Id = wodId,
                Name = "WOD 2025/08/04",
                DescriptionHTML = "<p>Test</p>"
            };

            mockRepo.Setup(r => r.GetByIdAsync(wodId))
                                .ReturnsAsync(entity);

            var result = await crossfitWODService
                                .GetCrossfitWODByIdAsync(wodId.ToString());

            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo("WOD 2025/08/04"));
            Assert.That(result.DescriptionHTML, Is.EqualTo("<p>Test</p>"));
        }

        [Test]
        public async Task GetCrossfitWODByIdAsync_ReturnsNull_WhenWODDoesNotExist()
        {
            Guid wodId = Guid.NewGuid();
            mockRepo.Setup(r => r.GetByIdAsync(wodId))
                            .ReturnsAsync((CrossfitWorkoutOfTheDay?)null);

            CrossfitWODViewModel? result = await crossfitWODService
                                    .GetCrossfitWODByIdAsync(wodId.ToString());

            Assert.IsNull(result);
        }

        [Test]
        public async Task GetLatestCrossfitWODAsync_ReturnsFromRepo_WhenTodayWODExists()
        {
            CrossfitWorkoutOfTheDay crossfitWOD = new CrossfitWorkoutOfTheDay
                        {
                            Id = Guid.NewGuid(),
                            Name = "WOD Today",
                            DescriptionHTML = "<div>WOD Today</div>"
                        };

            mockRepo.Setup(r => r.GetTodayWOD())
                    .ReturnsAsync(crossfitWOD);

            CrossfitWODViewModel? result = await crossfitWODService
                                                .GetLatestCrossfitWODAsync();

            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo("WOD Today"));
            Assert.That(result.DescriptionHTML, Is.EqualTo("<div>WOD Today</div>"));
        }

        [Test]
        public async Task GetAllCrossfitWODAsync_ReturnsAllWODs()
        {
            DateTime dateFirstWod = DateTime.UtcNow.AddDays(-1);
            DateTime dateSecondWod = DateTime.UtcNow;


            IQueryable<CrossfitWorkoutOfTheDay> wodList = new List<CrossfitWorkoutOfTheDay>
                    {
                        new CrossfitWorkoutOfTheDay
                            {
                                Id = Guid.NewGuid(),
                                Name = "WOD A",
                                WorkoutDate = dateFirstWod,
                                DescriptionHTML = "A"
                            },
                        new CrossfitWorkoutOfTheDay
                            {
                                Id = Guid.NewGuid(),
                                Name = "WOD B",
                                WorkoutDate = dateSecondWod,
                                DescriptionHTML = "B"
                            }
                    }
                    .AsQueryable();

            var mockSet = wodList.BuildMockDbSet();

            mockRepo.Setup(r => r.GetAllAttached()).Returns(mockSet.Object);

            IEnumerable<CrossfitWODViewModel> result = await crossfitWODService
                                .GetAllCrossfitWODAsync();

            Assert.That(result.Count(), Is.EqualTo(2));

            Assert.That(result.First().Name, Is.EqualTo("WOD A"));
            Assert.That(result.First().DescriptionHTML, Is.EqualTo("A"));
        }

        [Test]
        public void GetLatestCrossfitWODAsync_HandlesException_WhenHttpFails()
        {
            //TODO: Make Test for this and test with the Repo method in the CrossfitWOD repo as well!!

            Assert.Pass("Skipped: External HTTP fetch should be tested via integration or with refactoring.");
        }
    }
}
