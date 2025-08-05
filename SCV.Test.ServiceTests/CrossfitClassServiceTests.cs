namespace SCV.Test.ServiceTests
{
    using MockQueryable.Moq;
    using Moq;
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.CrossfitServices;
    using SCV.Services.Core.CrossfitServices.Contracts;
    using SCV.Web.ViewModels.Administration.CrossfitClassesVM;
    using SCV.Web.ViewModels.CrossfitVM;
    using System.Linq;

    [TestFixture]
    public class CrossfitClassServiceTests
    {
        private Mock<ICrossfitClassRepository> crossfitClassRepoMock = null!;

        private ICrossfitClassService crossfitClassService = null!;

        [SetUp]
        public void SetUp()
        {
            crossfitClassRepoMock = new Mock<ICrossfitClassRepository>();
            crossfitClassService = new CrossfitClassService(crossfitClassRepoMock.Object);
        }

        [Test]
        public async Task GetAllCrossfitClassesAsync_ReturnsSortedList()
        {
            IQueryable<CrossfitClass> crossfitClasses = new List<CrossfitClass>
            {
                new CrossfitClass
                {
                    Id = Guid.NewGuid(),
                    Name = "WOD: Hero Workout",
                    Description = "A high-intensity Hero WOD designed to test endurance and mental toughness.",
                    DayOfWeek = DayOfWeek.Monday,
                    StartTime = "Monday at 17:00",
                    TrainerName = "Ivan Dimitrov"
                },
                new CrossfitClass
                {
                    Id = Guid.NewGuid(),
                    Name = "CrossFit Team Challenge",
                    Description = "Team-based workout to build camaraderie and competitive spirit.",
                    DayOfWeek = DayOfWeek.Wednesday,
                    StartTime = "Wednesday at 17:00",
                    TrainerName = "Georgi Kolev"
                }
            }.AsQueryable();

            var mockDbSet = crossfitClasses.BuildMockDbSet();

            crossfitClassRepoMock.Setup(repo => repo.GetAllAttached())
                                                .Returns(mockDbSet.Object);

            IEnumerable<CrossfitClassDetailViewModel> result = await crossfitClassService
                                    .GetAllCrossfitClassesAsync();

            IList<CrossfitClassDetailViewModel> resultList = result.ToList();

            Assert.That(resultList.Count, Is.EqualTo(2));

            Assert.That(resultList[0].Name, Is.EqualTo("WOD: Hero Workout"));
            Assert.That(resultList[0].Description, Is.EqualTo("A high-intensity Hero WOD designed to test endurance and mental toughness."));
            //Assert.That(resultList[0].DayOfWeek, Is.EqualTo(DayOfWeek.Monday));
            Assert.That(resultList[0].StartTime, Is.EqualTo("Monday at 17:00"));
            Assert.That(resultList[0].TrainerName, Is.EqualTo("Ivan Dimitrov"));


            Assert.That(resultList[1].Name, Is.EqualTo("CrossFit Team Challenge"));
            Assert.That(resultList[1].Description, Is.EqualTo("Team-based workout to build camaraderie and competitive spirit."));
            //Assert.That(resultList[1].DayOfWeek, Is.EqualTo(DayOfWeek.Wednesday));
            Assert.That(resultList[1].StartTime, Is.EqualTo("Wednesday at 17:00"));
            Assert.That(resultList[1].TrainerName, Is.EqualTo("Georgi Kolev"));

        }

        [Test]
        public async Task AddCrossfitClassAsync_WithValidData_ReturnsTrue()
        {
            CrossfitClassAddViewModel newClass = new CrossfitClassAddViewModel
            {
                Name = "CrossFit Open Prep",
                Description = "Specialized training session to prepare for the CrossFit Open competition.",
                StartTime = "Saturday at 10:00",
                DayOfWeek = DayOfWeek.Saturday,
                TrainerName = "Guest Coach: Stoyan Dimitrov"
            };

            crossfitClassRepoMock
                .Setup(repo => repo.AddAsync(It.IsAny<CrossfitClass>()))
                .Returns(Task.CompletedTask);

            bool isAdded = await crossfitClassService
                                        .AddCrossfitClassAsync(newClass);

            Assert.IsTrue(isAdded);
            crossfitClassRepoMock.Verify(r => r.AddAsync(It.Is<CrossfitClass>(cc => cc.Name == "CrossFit Open Prep")), Times.Once);
            crossfitClassRepoMock.Verify(r => r.AddAsync(It.Is<CrossfitClass>(cc => cc.Description == "Specialized training session to prepare for the CrossFit Open competition.")), Times.Once);
            crossfitClassRepoMock.Verify(r => r.AddAsync(It.Is<CrossfitClass>(cc => cc.StartTime == "Saturday at 10:00")), Times.Once);
            crossfitClassRepoMock.Verify(r => r.AddAsync(It.Is<CrossfitClass>(cc => cc.DayOfWeek == DayOfWeek.Saturday)), Times.Once);
            crossfitClassRepoMock.Verify(r => r.AddAsync(It.Is<CrossfitClass>(cc => cc.TrainerName == "Guest Coach: Stoyan Dimitrov")), Times.Once);
        }

        [Test]
        public async Task GetCrossfitClassByIdAsync_WithInvalidId_ReturnsNull()
        {
            IQueryable<CrossfitClass> crossfitClassList = new List<CrossfitClass>
            {
                new CrossfitClass {
                        Id = Guid.NewGuid(),
                        Name = "Test",
                        Description = "This is a test",
                        StartTime = "Test at 00:00",
                        DayOfWeek = DayOfWeek.Saturday,
                        TrainerName = "Guest Coach: Test"
                }
            }.AsQueryable();

            var mockDbSet = crossfitClassList.BuildMockDbSet();

            crossfitClassRepoMock.Setup(r => r.GetAllAttached())
                                        .Returns(mockDbSet.Object);

            CrossfitClassEditViewModel? result = await crossfitClassService
                                            .GetCrossfitClassByIdAsync("WOD:Hero Workout");

            Assert.IsNull(result);
        }

        [Test]
        public async Task EditCrossfitClassAsync_WithValidModel_EditsAndReturnsTrue()
        {
            Guid crossfitClassId = Guid.NewGuid();

            CrossfitClassEditViewModel crossfitClassVM = new CrossfitClassEditViewModel
            {
                Id = crossfitClassId.ToString(),
                Name = "Test",
                Description = "This is a test",
                StartTime = "Test at 00:00",
                DayOfWeek = DayOfWeek.Saturday,
                TrainerName = "Guest Coach: Test"
            };

            CrossfitClass existingClass = new CrossfitClass
            {
                Id = crossfitClassId,
                Name = "CrossFit Open Prep",
                Description = "Specialized training session to prepare for the CrossFit Open competition.",
                StartTime = "Saturday at 10:00",
                DayOfWeek = DayOfWeek.Saturday,
                TrainerName = "Guest Coach: Stoyan Dimitrov"
            };

            IQueryable<CrossfitClass> crossfitClassList = new List<CrossfitClass> { existingClass }
                                                    .AsQueryable();
            var mockDbSet = crossfitClassList.BuildMockDbSet();

            crossfitClassRepoMock.Setup(r => r.GetAllAttached())
                                                .Returns(mockDbSet.Object);
            crossfitClassRepoMock.Setup(r => r.UpdateAsync(It.IsAny<CrossfitClass>()))
                                                .ReturnsAsync(true);

            var isEdited = await crossfitClassService
                                    .EditCrossfitClassAsync(crossfitClassVM);

            Assert.IsTrue(isEdited);
            crossfitClassRepoMock.Verify(r => r.UpdateAsync(It.Is<CrossfitClass>(
                                                cc =>
                                                    cc.Id == crossfitClassId &&
                                                    cc.Name == "Test" &&
                                                    cc.Description == "This is a test" &&
                                                    cc.StartTime == "Test at 00:00" &&
                                                    cc.DayOfWeek == DayOfWeek.Saturday &&
                                                    cc.TrainerName == "Guest Coach: Test"
                                            )), Times.Once);
        }

        [Test]
        public async Task EditCrossfitClassAsync_WithInvalidId_ReturnsFalse()
        {
            CrossfitClassEditViewModel crossfitClassEditViewModel = new CrossfitClassEditViewModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Test",
                Description = "This is a test",
                StartTime = "Test at 00:00",
                DayOfWeek = DayOfWeek.Saturday,
                TrainerName = "Guest Coach: Test"
            };

            IQueryable<CrossfitClass> crossfitClassList = new List<CrossfitClass>()
                                           .AsQueryable(); //no classes available!
            var mockDbSet = crossfitClassList.BuildMockDbSet();

            crossfitClassRepoMock.Setup(r => r.GetAllAttached())
                                        .Returns(mockDbSet.Object);

            bool isEdit = await crossfitClassService
                                    .EditCrossfitClassAsync(crossfitClassEditViewModel);

            Assert.IsFalse(isEdit);
            crossfitClassRepoMock.Verify(r => r.UpdateAsync(It.IsAny<CrossfitClass>()), Times.Never);
        }

        [Test]
        public async Task EditCrossfitClassAsync_WithNullInput_ReturnsFalse()
        {
            bool isEdit = await crossfitClassService.
                                    EditCrossfitClassAsync(null!);

            Assert.IsFalse(isEdit);
            crossfitClassRepoMock.Verify(r => r.UpdateAsync(It.IsAny<CrossfitClass>()), Times.Never);
        }

        [Test]
        public async Task DeleteOrRestoreCrossfitClassAsync_WithActiveClass_TogglesToInactive()
        {
            Guid crossfitClasId = Guid.NewGuid();

            CrossfitClass entity = new CrossfitClass
            {
                Id = crossfitClasId,
                Name = "Test",
                Description = "This is a test",
                StartTime = "Test at 00:00",
                DayOfWeek = DayOfWeek.Saturday,
                TrainerName = "Guest Coach: Test",
                IsActive = true
            };

            IQueryable<CrossfitClass> crossfitClassList = new List<CrossfitClass> { entity }
                                                    .AsQueryable();
            var mockDbSet = crossfitClassList.BuildMockDbSet();

            crossfitClassRepoMock.Setup(r => r.GetAllAttached()).Returns(mockDbSet.Object);
            crossfitClassRepoMock.Setup(r => r.UpdateAsync(It.IsAny<CrossfitClass>())).ReturnsAsync(true);

            (bool result, bool isRestored) = await crossfitClassService
                                .DeleteOrRestoreCrossfitClassAsync(crossfitClasId.ToString());

            Assert.IsTrue(result);
            Assert.IsFalse(isRestored); // It was active, now inactive
            crossfitClassRepoMock.Verify(r => r.UpdateAsync
                                (It.Is<CrossfitClass>(cc =>cc.IsActive == false)), Times.Once);
        }

        [Test]
        public async Task DeleteOrRestoreCrossfitClassAsync_WithInactiveClass_TogglesToActive()
        {
            Guid crossfitClassId = Guid.NewGuid();
            CrossfitClass entity = new CrossfitClass
            {
                Id = crossfitClassId,
                Name = "Test",
                Description = "This is a test",
                StartTime = "Test at 00:00",
                DayOfWeek = DayOfWeek.Saturday,
                TrainerName = "Guest Coach: Test",
                IsActive = false
            };

            IQueryable<CrossfitClass> crossfitClassList = new List<CrossfitClass> { entity }
                                        .AsQueryable();
            var mockDbSet = crossfitClassList.BuildMockDbSet();

            crossfitClassRepoMock.Setup(r => r.GetAllAttached()).Returns(mockDbSet.Object);
            crossfitClassRepoMock.Setup(r => r.UpdateAsync(It.IsAny<CrossfitClass>()))
                                                    .ReturnsAsync(true);

            (bool result, bool isRestored) = await crossfitClassService
                                .DeleteOrRestoreCrossfitClassAsync(crossfitClassId.ToString());

            Assert.IsTrue(result);
            Assert.IsTrue(isRestored);
            crossfitClassRepoMock.Verify(r => r.UpdateAsync
                                    (It.Is<CrossfitClass>(cc => cc.IsActive == true)), Times.Once);
        }

        [Test]
        public async Task DeleteOrRestoreCrossfitClassAsync_WithInvalidId_ReturnsFalse()
        {
            IQueryable<CrossfitClass> crossfitClassList = new List<CrossfitClass>()
                                            .AsQueryable();
            var mockDbSet = crossfitClassList.BuildMockDbSet();

            crossfitClassRepoMock.Setup(r => r.GetAllAttached())
                                        .Returns(mockDbSet.Object);

            (bool result, bool isRestored) = await crossfitClassService.
                                            DeleteOrRestoreCrossfitClassAsync("test-Id");

            Assert.IsFalse(result);
            Assert.IsFalse(isRestored);
            crossfitClassRepoMock.Verify(r => r.UpdateAsync
                                        (It.IsAny<CrossfitClass>()), Times.Never);
        }

    }

}
