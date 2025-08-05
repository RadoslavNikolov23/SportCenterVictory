namespace SCV.Test.ServiceTests
{
    using Moq;
    using MockQueryable.Moq;

    using System.Linq;

    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.Services.Core.FitnessServices;
    using SCV.Services.Core.FitnessServices.Contracts;

    [TestFixture]
    public class WorkoutPlanExerciseServiceTests
    {
        private Mock<IWorkoutPlanExerciseRepository> mockExerciseRepo;
        private Mock<IWorkoutPlanRepository> mockPlanRepo;
        private IWorkoutPlanExerciseService service;

        [SetUp]
        public void Setup()
        {
            mockExerciseRepo = new Mock<IWorkoutPlanExerciseRepository>();
            mockPlanRepo = new Mock<IWorkoutPlanRepository>();
            service = new WorkoutPlanExerciseService(mockExerciseRepo.Object, mockPlanRepo.Object);
        }

        [Test]
        public async Task GetExerciseIdsForWorkoutPlanAsync_ReturnsCorrectIds()
        {
            Guid planId = Guid.NewGuid();
            string exerciseOneId = "Barbell_Full_Squat";
            string exerciseTwoId = "Bench_Press_-_Powerlifting";

            IQueryable<WorkoutPlanExercise> data = new List<WorkoutPlanExercise>
            {
                new WorkoutPlanExercise { WorkoutPlanId = planId, ExerciseId = exerciseOneId},
                new WorkoutPlanExercise { WorkoutPlanId = planId, ExerciseId = exerciseTwoId},
            }.AsQueryable();

            mockExerciseRepo.Setup(r => r.GetAllAttached())
                            .Returns(data.BuildMockDbSet().Object);

            List<string> result = await service
                            .GetExerciseIdsForWorkoutPlanAsync(planId.ToString());

            Assert.That(result.Count, Is.EqualTo(2));
            Assert.Contains(exerciseOneId, result);
            Assert.Contains(exerciseTwoId, result);
        }

        [Test]
        public void UpdateExercisesForWorkoutPlanAsync_Throws_WhenWorkoutPlanIdIsNull()
        {
            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.UpdateExercisesForWorkoutPlanAsync(null, new List<string> { "Barbell_Full_Squat" }));

            Assert.That(ex.ParamName, Is.EqualTo("workoutPlanId"));
        }

        [Test]
        public void UpdateExercisesForWorkoutPlanAsync_Throws_WhenWorkoutPlanIdInvalidGuid()
        {
            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.UpdateExercisesForWorkoutPlanAsync("invalid", new List<string> { "Barbell_Full_Squat" }));
            Assert.That(ex.ParamName, Is.EqualTo("workoutPlanId"));
        }

        [Test]
        public void UpdateExercisesForWorkoutPlanAsync_Throws_WhenExerciseIdsIsNull()
        {
            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.UpdateExercisesForWorkoutPlanAsync(Guid.NewGuid().ToString(), null));
            Assert.That(ex.ParamName, Is.EqualTo("exerciseIds"));
        }

        [Test]
        public async Task UpdateExercisesForWorkoutPlanAsync_DeletesAndAddsExercises()
        {
            Guid planId = Guid.NewGuid();
            string oldExerciseOneId = "Barbell_Full_Squat";
            string oldExerciseTwoId = "Bench_Press_-_Powerlifting";

            string newExerciseOneId = "Barbell_Deadlift";
            string newExerciseTwoId = "Standing_Military_Press";

            IQueryable<WorkoutPlanExercise> oldLinks = new List<WorkoutPlanExercise>
            {
                new WorkoutPlanExercise { WorkoutPlanId = planId, ExerciseId = oldExerciseOneId },
                new WorkoutPlanExercise { WorkoutPlanId = planId, ExerciseId = oldExerciseTwoId },
            }.AsQueryable();

            IList<string> exerciseIds = new List<string>
                        {
                            newExerciseOneId,
                            newExerciseTwoId
                        };

            mockExerciseRepo.Setup(r => r.GetAllAttached())
                            .Returns(oldLinks.BuildMockDbSet().Object);

            mockExerciseRepo.Setup(r => r.HardDeleteRangeAsync(It.IsAny<IEnumerable<WorkoutPlanExercise>>()))
                            .Returns(Task.CompletedTask).Verifiable();

            mockExerciseRepo.Setup(r => r.AddRangeAsync(It.IsAny<IEnumerable<WorkoutPlanExercise>>()))
                            .Returns(Task.CompletedTask).Verifiable();

            await service.UpdateExercisesForWorkoutPlanAsync(planId.ToString(), exerciseIds);

            mockExerciseRepo.Verify(r => r.HardDeleteRangeAsync(It.IsAny<IEnumerable<WorkoutPlanExercise>>()), Times.Once);
            mockExerciseRepo.Verify(r => r.AddRangeAsync(It.Is<IEnumerable<WorkoutPlanExercise>>(x => x.Count() == 2)), Times.Once);
        }
    }
}
