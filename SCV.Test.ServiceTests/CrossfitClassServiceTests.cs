namespace SCV.Test.ServiceTests
{
    using Microsoft.EntityFrameworkCore;
    using MockQueryable.EntityFrameworkCore;
    using Moq;
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core;
    using SCV.Test.ServiceTests.Extensions;
    using SCV.Web.ViewModels.Administration.CrossfitClassesVM;
    using SCV.Web.ViewModels.CrossfitVM;
    using System.Linq;

    [TestFixture]
    public class CrossfitClassServiceTests
    {
        private Mock<ICrossfitClassRepository> crossfitClassRepoMock = null!;

        private CrossfitClassService crossfitCLassService = null!;

        [SetUp]
        public void SetUp()
        {
            crossfitClassRepoMock = new Mock<ICrossfitClassRepository>();
            crossfitCLassService = new CrossfitClassService(crossfitClassRepoMock.Object);
        }

        [Test]
        public async Task GetAllCrossfitClassesAsync_ReturnsSortedList()
        {
            IList<CrossfitClass> classes = new List<CrossfitClass>
            {
                new CrossfitClass
                {
                    Id = Guid.NewGuid(),
                    Name = "WOD: Hero Workout",
                    Description = "A high-intensity Hero WOD designed to test endurance and mental toughness.",
                    DayOfWeek = DayOfWeek.Monday, //Use Enums!!
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
            };

            IQueryable<CrossfitClass> mockDbSet = classes.BuildMock();

            crossfitClassRepoMock.Setup(repo => repo.GetAllAttached())
                                                .Returns(mockDbSet);

            IEnumerable<CrossfitClassDetailViewModel> result = await crossfitCLassService
                                                 .GetAllCrossfitClassesAsync();

            IList<CrossfitClassDetailViewModel> resultList = result.ToList();

            Assert.That(resultList.Count, Is.EqualTo(2));

            Assert.That(resultList[0].Name, Is.EqualTo("WOD: Hero Workout"));
            Assert.That(resultList[0].Description, Is.EqualTo("A high-intensity Hero WOD designed to test endurance and mental toughness."));
            Assert.That(resultList[0].StartTime, Is.EqualTo("Monday at 17:00"));
            Assert.That(resultList[0].TrainerName, Is.EqualTo("Ivan Dimitrov"));


            Assert.That(resultList[1].Name, Is.EqualTo("CrossFit Team Challenge"));
            Assert.That(resultList[1].Description, Is.EqualTo("Team-based workout to build camaraderie and competitive spirit."));
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

            bool isAdded = await crossfitCLassService.AddCrossfitClassAsync(newClass);

            Assert.IsTrue(isAdded);

            crossfitClassRepoMock.Verify(r => r.AddAsync(It.Is<CrossfitClass>(cc => cc.Name == "CrossFit Open Prep")), Times.Once);

            crossfitClassRepoMock.Verify(r => r.AddAsync(It.Is<CrossfitClass>(cc => cc.Description == "Specialized training session to prepare for the CrossFit Open competition.")), Times.Once);

            crossfitClassRepoMock.Verify(r => r.AddAsync(It.Is<CrossfitClass>(cc => cc.StartTime == "Saturday at 10:00")), Times.Once);

            crossfitClassRepoMock.Verify(r => r.AddAsync(It.Is<CrossfitClass>(cc => cc.DayOfWeek.ToString() == DayOfWeek.Saturday.ToString())), Times.Once);

            crossfitClassRepoMock.Verify(r => r.AddAsync(It.Is<CrossfitClass>(cc => cc.TrainerName == "Guest Coach: Stoyan Dimitrov")), Times.Once);
        }

        [Test]
        public async Task GetCrossfitClassByIdAsync_WithInvalidId_ReturnsNull()
        {
            IList<CrossfitClass> data = new List<CrossfitClass>
            {
                new CrossfitClass {
                        Id = Guid.NewGuid(),
                        Name = "Test",
                        Description = "This is a test",
                        StartTime = "Test at 00:00",
                        DayOfWeek = DayOfWeek.Saturday,
                        TrainerName = "Guest Coach: Test"
                }
            };

            IQueryable<CrossfitClass> mockDbSet = data.BuildMock();
            crossfitClassRepoMock.Setup(r => r.GetAllAttached()).Returns(mockDbSet);

            CrossfitClassEditViewModel? result = await crossfitCLassService.GetCrossfitClassByIdAsync("WOD:Hero Workout");

            Assert.IsNull(result);
        }

        [Test]
        public async Task EditCrossfitClassAsync_WithValidModel_EditsAndReturnsTrue()
        {
            Guid crossfitClassId = Guid.NewGuid();
            CrossfitClassEditViewModel model = new CrossfitClassEditViewModel
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

            IList<CrossfitClass> data = new List<CrossfitClass> { existingClass };
            IQueryable<CrossfitClass> mockDbSet = data.BuildMock();
            crossfitClassRepoMock.Setup(r => r.GetAllAttached()).Returns(mockDbSet);
            crossfitClassRepoMock.Setup(r => r.UpdateAsync(It.IsAny<CrossfitClass>())).ReturnsAsync(true);

            bool isEdited = await crossfitCLassService.EditCrossfitClassAsync(model);

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
            CrossfitClassEditViewModel model = new CrossfitClassEditViewModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Test",
                Description = "This is a test",
                StartTime = "Test at 00:00",
                DayOfWeek = DayOfWeek.Saturday,
                TrainerName = "Guest Coach: Test"
            };

            IList<CrossfitClass> data = new List<CrossfitClass>(); //no classes available!
            IQueryable<CrossfitClass> mockDbSet = data.BuildMock();

            crossfitClassRepoMock.Setup(r => r.GetAllAttached()).Returns(mockDbSet);

            bool isEdited = await crossfitCLassService.EditCrossfitClassAsync(model);

            Assert.IsFalse(isEdited);
            crossfitClassRepoMock.Verify(r => r.UpdateAsync(It.IsAny<CrossfitClass>()), Times.Never);
        }

        [Test]
        public async Task EditCrossfitClassAsync_WithNullInput_ReturnsFalse()
        {
            bool isEdited = await crossfitCLassService.EditCrossfitClassAsync(null!);

            Assert.IsFalse(isEdited);
            crossfitClassRepoMock.Verify(r => r.UpdateAsync(It.IsAny<CrossfitClass>()), Times.Never);
        }

        [Test]
        public async Task DeleteOrRestoreCrossfitClassAsync_WithActiveClass_TogglesToInactive()
        {
            var crossfitClasId = Guid.NewGuid();

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

            IList<CrossfitClass> data = new List<CrossfitClass> { entity };
            IQueryable<CrossfitClass> mockDbSet = data.BuildMock();

            crossfitClassRepoMock.Setup(r => r.GetAllAttached()).Returns(mockDbSet);
            crossfitClassRepoMock.Setup(r => r.UpdateAsync(It.IsAny<CrossfitClass>())).ReturnsAsync(true);

            (bool isSuccess, bool isRestored) opResult = await crossfitCLassService.DeleteOrRestoreCrossfitClassAsync(crossfitClasId.ToString());

            Assert.IsTrue(opResult.isSuccess);
            Assert.IsFalse(opResult.isRestored); // It was active, now inactive
            crossfitClassRepoMock.Verify(r => r.UpdateAsync(It.Is<CrossfitClass>(cc => cc.IsActive == false)), Times.Once);
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

            IList<CrossfitClass> data = new List<CrossfitClass> { entity };
            IQueryable<CrossfitClass> mockDbSet = data.BuildMock();

            crossfitClassRepoMock.Setup(r => r.GetAllAttached()).Returns(mockDbSet);
            crossfitClassRepoMock.Setup(r => r.UpdateAsync(It.IsAny<CrossfitClass>())).ReturnsAsync(true);

           (bool result, bool isRestored) = await crossfitCLassService
                                    .DeleteOrRestoreCrossfitClassAsync(crossfitClassId.ToString());

            Assert.IsTrue(result);
            Assert.IsTrue(isRestored);
            crossfitClassRepoMock.Verify(r => r.UpdateAsync(It.Is<CrossfitClass>(cc => cc.IsActive == true)), Times.Once);
        }

        [Test]
        public async Task DeleteOrRestoreCrossfitClassAsync_WithInvalidId_ReturnsFalse()
        {
            IList<CrossfitClass> data = new List<CrossfitClass>();
            IQueryable<CrossfitClass> mockDbSet = data.BuildMock();
            crossfitClassRepoMock.Setup(r => r.GetAllAttached()).Returns(mockDbSet);

            (bool result, bool isRestored) = await crossfitCLassService
                                    .DeleteOrRestoreCrossfitClassAsync("test-Id");

            Assert.IsFalse(result);
            Assert.IsFalse(isRestored);
            crossfitClassRepoMock.Verify(r => r.UpdateAsync(It.IsAny<CrossfitClass>()), Times.Never);
        }

    }

}
