namespace SCV.Test.ServiceTests
{
    using MockQueryable.EntityFrameworkCore;
    using MockQueryable.Moq;
    using Moq;

    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.Services.Core;
    using SCV.Services.Core.FitnessServices.Contracts;
    using SCV.Web.ViewModels.Administration.EventVM;
    using SCV.Web.ViewModels.Administration.FitnessVM;
    using SCV.Web.ViewModels.FitnessVM;

    [TestFixture]
    public class ExerciseServiceTests
    {
        private Mock<IExerciseRepository> mockRepo;
        private IExerciseService exerciseService;

        [SetUp]
        public void Setup()
        {
            mockRepo = new Mock<IExerciseRepository>();
            exerciseService = new ExerciseService(mockRepo.Object);
        }

        [Test]
        public async Task GetExerciseByIdAsync_ReturnsNull()
        {
            string exerciseId = "Barbell_Deadlift";

            IQueryable<Exercise> data = new List<Exercise>
            {
                new Exercise
                {
                    Id = exerciseId,
                    Name = "Barbell_Deadlift",
                    Force = "Test",
                    Mechanic= "Test",
                    Equipment= "Test",
                    PrimaryMuscles= "Test",
                    SecondaryMuscles= "calves, forearms, glutes, hamstrings, lats, middle back, quadriceps, traps",
                    Instructions= "Test",
                    Category= "Test",
                    ImageUrlOne= "/deadlift/0.jpg",
                    ImageUrlTwo= "/deadlift/1.jpg"
                }
            }
            .AsQueryable();



            var mockSet = data.BuildMockDbSet();
           
            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);

            ExercisesDetailViewModel? result = await exerciseService
                                    .GetExerciseByIdAsync(exerciseId);

            Assert.IsNull(result);

        }

        [Test]
        public async Task GetAllExercisesAsync_ReturnsAllExercises()
        {
            IQueryable<Exercise> data = new List<Exercise>
            {
             new Exercise
                {
                    Id = "Barbell_Deadlift",
                    Name = "Barbell Deadlift",
                    Force = "pull",
                    Mechanic= "compound",
                    Equipment= "barbell",
                    PrimaryMuscles= "back",
                    SecondaryMuscles= "calves, forearms, glutes, hamstrings, lats, middle back, quadriceps, traps",
                    Instructions= "Stand in front of a loaded barbell., While keeping the back as straight as possible, bend your knees, bend forward and grasp the bar using a medium (shoulder width) overhand grip. This will be the starting position of the exercise. Tip: If it is difficult to hold on to the bar with this grip, alternate your grip or use wrist straps., While holding the bar, start the lift by pushing with your legs while simultaneously getting your torso to the upright position as you breathe out. In the upright position, stick your chest out and contract the back by bringing the shoulder blades back. Think of how the soldiers in the military look when they are in standing in attention., Go back to the starting position by bending at the knees while simultaneously leaning the torso forward at the waist while keeping the back straight. When the weights on the bar touch the floor you are back at the starting position and ready to perform another repetition., Perform the amount of repetitions prescribed in the program.",
                    Category= "strength",
                    ImageUrlOne= "/deadlift/0.jpg",
                    ImageUrlTwo= "/deadlift/1.jpg",
                    IsDeleted = false
                },
                new Exercise
                {
                    Id = "Barbell_Full_Squat",
                    Name = "Barbell Full Squat",
                    Force = "push",
                    Mechanic = "compound",
                    Equipment = "barbell",
                    PrimaryMuscles = "quadriceps",
                    SecondaryMuscles = "calves, glutes, hamstrings, lower back",
                    Instructions = "This exercise is best performed inside a squat rack for safety purposes. To begin, first set the bar on a rack just above shoulder level. Once the correct height is chosen and the bar is loaded, step under the bar and place the back of your shoulders (slightly below the neck) across it., Hold on to the bar using both arms at each side and lift it off the rack by first pushing with your legs and at the same time straightening your torso., Step away from the rack and position your legs using a shoulder-width medium stance with the toes slightly pointed out. Keep your head up at all times and maintain a straight back. This will be your starting position., Begin to slowly lower the bar by bending the knees and sitting back with your hips as you maintain a straight posture with the head up. Continue down until your hamstrings are on your calves. Inhale as you perform this portion of the movement., Begin to raise the bar as you exhale by pushing the floor with the heel or middle of your foot as you straighten the legs and extend the hips to go back to the starting position., Repeat for the recommended amount of repetitions.",
                    Category = "strength",
                    ImageUrlOne = "/squat/0.jpg",
                    ImageUrlTwo = "/squat/1.jpg",
                    IsDeleted = false
                },
                new Exercise
                {
                    Id = "Bench_Press_-_Powerlifting",
                    Name = "Bench Press - Powerlifting",
                    Force = "push",
                    Mechanic = "compound",
                    Equipment = "barbell",
                    PrimaryMuscles = "triceps",
                    SecondaryMuscles = "chest, forearms, lats, shoulders",
                    Instructions = "Begin by lying on the bench, getting your head beyond the bar if possible. Tuck your feet underneath you and arch your back. Using the bar to help support your weight, lift your shoulder off the bench and retract them, squeezing the shoulder blades together. Use your feet to drive your traps into the bench. Maintain this tight body position throughout the movement., However wide your grip, it should cover the ring on the bar. Pull the bar out of the rack without protracting your shoulders. Focus on squeezing the bar and trying to pull it apart., Lower the bar to your lower chest or upper stomach. The bar, wrist, and elbow should stay in line at all times., Pause when the barbell touches your torso, and then drive the bar up with as much force as possible. The elbows should be tucked in until lockout.",
                    Category = "powerlifting",
                    ImageUrlOne = "/Bench_Press/0.jpg",
                    ImageUrlTwo = "/Bench_Press/1.jpg",
                    IsDeleted = true
                },
            }
            .AsQueryable();

            //mockRepo.Setup(r => r.GetAllAttached()).Returns(data);

            var mockSet = data.BuildMockDbSet();
            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);

            IEnumerable<ExercisesDetailViewModel> result = await exerciseService
                                    .GetAllExercisesAsync();

            Assert.That(result.Count(), Is.EqualTo(3));
            Assert.IsTrue(result.Any(e => e.Name == "Barbell Deadlift"));
            Assert.IsTrue(result.Any(e => e.Name == "Barbell Full Squat"));
            Assert.IsTrue(result.Any(e => e.Name == "Bench Press - Powerlifting"));
        }

        [Test]
        public async Task GetExercisesPageAsync_ReturnsCorrectPage()
        {
            IQueryable<Exercise> data = new List<Exercise>
            {
             new Exercise
                {
                    Id = "Barbell_Deadlift",
                    Name = "Barbell Deadlift",
                    Force = "pull",
                    Mechanic= "compound",
                    Equipment= "barbell",
                    PrimaryMuscles= "back",
                    SecondaryMuscles= "calves, forearms, glutes, hamstrings, lats, middle back, quadriceps, traps",
                    Instructions= "Stand in front of a loaded barbell., While keeping the back as straight as possible, bend your knees, bend forward and grasp the bar using a medium (shoulder width) overhand grip. This will be the starting position of the exercise. Tip: If it is difficult to hold on to the bar with this grip, alternate your grip or use wrist straps., While holding the bar, start the lift by pushing with your legs while simultaneously getting your torso to the upright position as you breathe out. In the upright position, stick your chest out and contract the back by bringing the shoulder blades back. Think of how the soldiers in the military look when they are in standing in attention., Go back to the starting position by bending at the knees while simultaneously leaning the torso forward at the waist while keeping the back straight. When the weights on the bar touch the floor you are back at the starting position and ready to perform another repetition., Perform the amount of repetitions prescribed in the program.",
                    Category= "strength",
                    ImageUrlOne= "/deadlift/0.jpg",
                    ImageUrlTwo= "/deadlift/1.jpg",
                },
                new Exercise
                {
                    Id = "Barbell_Full_Squat",
                    Name = "Barbell Full Squat",
                    Force = "push",
                    Mechanic = "compound",
                    Equipment = "barbell",
                    PrimaryMuscles = "quadriceps",
                    SecondaryMuscles = "calves, glutes, hamstrings, lower back",
                    Instructions = "This exercise is best performed inside a squat rack for safety purposes. To begin, first set the bar on a rack just above shoulder level. Once the correct height is chosen and the bar is loaded, step under the bar and place the back of your shoulders (slightly below the neck) across it., Hold on to the bar using both arms at each side and lift it off the rack by first pushing with your legs and at the same time straightening your torso., Step away from the rack and position your legs using a shoulder-width medium stance with the toes slightly pointed out. Keep your head up at all times and maintain a straight back. This will be your starting position., Begin to slowly lower the bar by bending the knees and sitting back with your hips as you maintain a straight posture with the head up. Continue down until your hamstrings are on your calves. Inhale as you perform this portion of the movement., Begin to raise the bar as you exhale by pushing the floor with the heel or middle of your foot as you straighten the legs and extend the hips to go back to the starting position., Repeat for the recommended amount of repetitions.",
                    Category = "strength",
                    ImageUrlOne = "/squat/0.jpg",
                    ImageUrlTwo = "/squat/1.jpg",
                },
                new Exercise
                {
                    Id = "Bench_Press_-_Powerlifting",
                    Name = "Bench Press - Powerlifting",
                    Force = "push",
                    Mechanic = "compound",
                    Equipment = "barbell",
                    PrimaryMuscles = "triceps",
                    SecondaryMuscles = "chest, forearms, lats, shoulders",
                    Instructions = "Begin by lying on the bench, getting your head beyond the bar if possible. Tuck your feet underneath you and arch your back. Using the bar to help support your weight, lift your shoulder off the bench and retract them, squeezing the shoulder blades together. Use your feet to drive your traps into the bench. Maintain this tight body position throughout the movement., However wide your grip, it should cover the ring on the bar. Pull the bar out of the rack without protracting your shoulders. Focus on squeezing the bar and trying to pull it apart., Lower the bar to your lower chest or upper stomach. The bar, wrist, and elbow should stay in line at all times., Pause when the barbell touches your torso, and then drive the bar up with as much force as possible. The elbows should be tucked in until lockout.",
                    Category = "powerlifting",
                    ImageUrlOne = "/Bench_Press/0.jpg",
                    ImageUrlTwo = "/Bench_Press/1.jpg",
                },
            }.AsQueryable();

            var mockSet = data.BuildMockDbSet();
            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);

            IEnumerable<ExercisesDetailViewModel> result = await exerciseService
                                .GetExercisesPageAsync(2, 1, "Barbell");

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().Name, Is.EqualTo("Barbell Full Squat"));

        }

        [Test]
        public async Task AddExerciseAsync_AddsExercise()
        {
            ExerciseAddViewModel model = new ExerciseAddViewModel
            {
               // Id = "Bench_Press_Test",
                Name = "Bench Press Test",
                Force = "push",
                Mechanic = "test",
                Equipment = "test",
                PrimaryMuscles = "test",
                SecondaryMuscles = "test",
                Instructions = "Test Instructions ",
                Category = "test",
                ImageUrlOne = "/Bench_Press/0.jpg",
                ImageUrlTwo = "/Bench_Press/1.jpg"
            };

            //Exercise? addedExercise = new Exercise();
            //addedExercise!.Id = "Bench_Press_Test";

            var mockData = new List<Exercise>().AsQueryable();

            mockRepo.Setup(r => r.GetAllAttached())
                .Returns(mockData.BuildMock().BuildMockDbSet().Object);

            mockRepo.Setup(r => r.AddAsync(It.IsAny<Exercise>())).Returns(Task.CompletedTask);

            bool isAdded = await exerciseService
                                .AddExerciseAsync(model);

            Assert.That(isAdded, Is.True);
        }

        [Test]
        public async Task GetExerciseForEditByIdAsync_ReturnsCorrectExercise()
        {
            string exerciseToFindId = "Barbell_Full_Squat";
            IQueryable<Exercise> data = new List<Exercise>
            {
                new Exercise
                {
                        Id = "Barbell_Full_Squat",
                        Name = "Barbell Full Squat",
                        Force = "push",
                        Mechanic = "compound",
                        Equipment = "barbell",
                        PrimaryMuscles = "quadriceps",
                        SecondaryMuscles = "calves, glutes, hamstrings, lower back",
                        Instructions = "This exercise is best performed inside a squat rack for safety purposes. To begin, first set the bar on a rack just above shoulder level. Once the correct height is chosen and the bar is loaded, step under the bar and place the back of your shoulders (slightly below the neck) across it., Hold on to the bar using both arms at each side and lift it off the rack by first pushing with your legs and at the same time straightening your torso., Step away from the rack and position your legs using a shoulder-width medium stance with the toes slightly pointed out. Keep your head up at all times and maintain a straight back. This will be your starting position., Begin to slowly lower the bar by bending the knees and sitting back with your hips as you maintain a straight posture with the head up. Continue down until your hamstrings are on your calves. Inhale as you perform this portion of the movement., Begin to raise the bar as you exhale by pushing the floor with the heel or middle of your foot as you straighten the legs and extend the hips to go back to the starting position., Repeat for the recommended amount of repetitions.",
                        Category = "strength",
                        ImageUrlOne = "/squat/0.jpg",
                        ImageUrlTwo = "/squat/1.jpg"
                },
                new Exercise
                    {
                        Id = "Bench_Press_-_Powerlifting",
                        Name = "Bench Press - Powerlifting",
                        Force = "push",
                        Mechanic = "compound",
                        Equipment = "barbell",
                        PrimaryMuscles = "triceps",
                        SecondaryMuscles = "chest, forearms, lats, shoulders",
                        Instructions = "Begin by lying on the bench, getting your head beyond the bar if possible. Tuck your feet underneath you and arch your back. Using the bar to help support your weight, lift your shoulder off the bench and retract them, squeezing the shoulder blades together. Use your feet to drive your traps into the bench. Maintain this tight body position throughout the movement., However wide your grip, it should cover the ring on the bar. Pull the bar out of the rack without protracting your shoulders. Focus on squeezing the bar and trying to pull it apart., Lower the bar to your lower chest or upper stomach. The bar, wrist, and elbow should stay in line at all times., Pause when the barbell touches your torso, and then drive the bar up with as much force as possible. The elbows should be tucked in until lockout.",
                        Category = "powerlifting",
                        ImageUrlOne = "/Bench_Press/0.jpg",
                        ImageUrlTwo = "/Bench_Press/1.jpg"
                    }
            }.AsQueryable();

            var mockSet = data.BuildMockDbSet();
            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);
        

            ExerciseEditViewModel? result = await exerciseService
                            .GetExerciseForEditByIdAsync(exerciseToFindId);

            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(exerciseToFindId));
            Assert.That(result.Name, Is.EqualTo("Barbell Full Squat"));
        }

        [Test]
        public async Task EditExerciseAsync_UpdatesExercise()
        {
            string exerciseId = "Bench_Press_-_Powerlifting";
            Exercise entity = new Exercise
            {
                Id = exerciseId,
                Name = "Bench Press - Powerlifting",
                Force = "push",
                Mechanic = "compound",
                Equipment = "barbell",
                PrimaryMuscles = "triceps",
                SecondaryMuscles = "chest, forearms, lats, shoulders",
                Instructions = "Begin by lying on the bench, getting your head beyond the bar if possible. Tuck your feet underneath you and arch your back. Using the bar to help support your weight, lift your shoulder off the bench and retract them, squeezing the shoulder blades together. Use your feet to drive your traps into the bench. Maintain this tight body position throughout the movement., However wide your grip, it should cover the ring on the bar. Pull the bar out of the rack without protracting your shoulders. Focus on squeezing the bar and trying to pull it apart., Lower the bar to your lower chest or upper stomach. The bar, wrist, and elbow should stay in line at all times., Pause when the barbell touches your torso, and then drive the bar up with as much force as possible. The elbows should be tucked in until lockout.",
                Category = "powerlifting",
                ImageUrlOne = "/Bench_Press/0.jpg",
                ImageUrlTwo = "/Bench_Press/1.jpg"
            };

            IQueryable<Exercise> data = new List<Exercise> 
                                        { 
                                            entity 
                                        }
                                        .AsQueryable();

            var mockSet = data.BuildMockDbSet();

            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);

            mockRepo.Setup(r => r.UpdateAsync(entity))
                    .ReturnsAsync(true);

            ExerciseEditViewModel model = new ExerciseEditViewModel
                    {
                        Id = exerciseId,
                        Name = "Bench Press - Just",
                        Force = "test",
                        Mechanic = "test",
                        Equipment = "test",
                        PrimaryMuscles = "test",
                        SecondaryMuscles = "test",
                        Instructions = "Test only text",
                        Category = "test",
                        ImageUrlOne = "test.jpg",
                        ImageUrlTwo = "test.jpg"
                    };

            bool isEdit = await exerciseService.EditExerciseAsync(model);

            Assert.True(isEdit);
        }

        [Test]
        public async Task DeleteOrRestoreExerciseAsync_TogglesIsDeleted()
        {
            string exerciseToDeleteId = "Barbell_Deadlift";
            Exercise entity = new Exercise
            {
                Id = "Barbell_Deadlift",
                Name = "Barbell Deadlift",
                Force = "pull",
                Mechanic = "compound",
                Equipment = "barbell",
                PrimaryMuscles = "back",
                SecondaryMuscles = "calves, forearms, glutes, hamstrings, lats, middle back, quadriceps, traps",
                Instructions = "Stand in front of a loaded barbell., While keeping the back as straight as possible, bend your knees, bend forward and grasp the bar using a medium (shoulder width) overhand grip. This will be the starting position of the exercise. Tip: If it is difficult to hold on to the bar with this grip, alternate your grip or use wrist straps., While holding the bar, start the lift by pushing with your legs while simultaneously getting your torso to the upright position as you breathe out. In the upright position, stick your chest out and contract the back by bringing the shoulder blades back. Think of how the soldiers in the military look when they are in standing in attention., Go back to the starting position by bending at the knees while simultaneously leaning the torso forward at the waist while keeping the back straight. When the weights on the bar touch the floor you are back at the starting position and ready to perform another repetition., Perform the amount of repetitions prescribed in the program.",
                Category = "strength",
                ImageUrlOne = "/deadlift/0.jpg",
                ImageUrlTwo = "/deadlift/1.jpg",
                IsDeleted = false
            };

            IQueryable<Exercise> data = new List<Exercise>
                                        {
                                            entity
                                        }
                                        .AsQueryable();

            var mockSet = data.BuildMockDbSet();

            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);
            mockRepo.Setup(r => r.UpdateAsync(entity))
                    .ReturnsAsync(true);

            (bool result, bool isRestored) = await exerciseService.
                                    DeleteOrRestoreExerciseAsync(exerciseToDeleteId);

            Assert.IsTrue(result);
            Assert.IsTrue(isRestored);
        }

        [Test]
        public async Task GetAllExerciseForAdminAsync_ReturnsAllExercises()
        {
            IQueryable<Exercise> data = new List<Exercise>
                {
                    new Exercise
                    {
                        Id = "Barbell_Deadlift",
                        Name = "Barbell Deadlift",
                        Force = "pull",
                        Mechanic= "compound",
                        Equipment= "barbell",
                        PrimaryMuscles= "back",
                        SecondaryMuscles= "calves, forearms, glutes, hamstrings, lats, middle back, quadriceps, traps",
                        Instructions= "Stand in front of a loaded barbell., While keeping the back as straight as possible, bend your knees, bend forward and grasp the bar using a medium (shoulder width) overhand grip. This will be the starting position of the exercise. Tip: If it is difficult to hold on to the bar with this grip, alternate your grip or use wrist straps., While holding the bar, start the lift by pushing with your legs while simultaneously getting your torso to the upright position as you breathe out. In the upright position, stick your chest out and contract the back by bringing the shoulder blades back. Think of how the soldiers in the military look when they are in standing in attention., Go back to the starting position by bending at the knees while simultaneously leaning the torso forward at the waist while keeping the back straight. When the weights on the bar touch the floor you are back at the starting position and ready to perform another repetition., Perform the amount of repetitions prescribed in the program.",
                        Category= "strength",
                        ImageUrlOne= "/deadlift/0.jpg",
                        ImageUrlTwo= "/deadlift/1.jpg",
                        IsDeleted = false
                    },
                    new Exercise
                    {
                        Id = "Barbell_Full_Squat",
                        Name = "Barbell Full Squat",
                        Force = "push",
                        Mechanic = "compound",
                        Equipment = "barbell",
                        PrimaryMuscles = "quadriceps",
                        SecondaryMuscles = "calves, glutes, hamstrings, lower back",
                        Instructions = "This exercise is best performed inside a squat rack for safety purposes. To begin, first set the bar on a rack just above shoulder level. Once the correct height is chosen and the bar is loaded, step under the bar and place the back of your shoulders (slightly below the neck) across it., Hold on to the bar using both arms at each side and lift it off the rack by first pushing with your legs and at the same time straightening your torso., Step away from the rack and position your legs using a shoulder-width medium stance with the toes slightly pointed out. Keep your head up at all times and maintain a straight back. This will be your starting position., Begin to slowly lower the bar by bending the knees and sitting back with your hips as you maintain a straight posture with the head up. Continue down until your hamstrings are on your calves. Inhale as you perform this portion of the movement., Begin to raise the bar as you exhale by pushing the floor with the heel or middle of your foot as you straighten the legs and extend the hips to go back to the starting position., Repeat for the recommended amount of repetitions.",
                        Category = "strength",
                        ImageUrlOne = "/squat/0.jpg",
                        ImageUrlTwo = "/squat/1.jpg",
                        IsDeleted = false
                    },
                    new Exercise
                    {
                        Id = "Bench_Press_-_Powerlifting",
                        Name = "Bench Press - Powerlifting",
                        Force = "push",
                        Mechanic = "compound",
                        Equipment = "barbell",
                        PrimaryMuscles = "triceps",
                        SecondaryMuscles = "chest, forearms, lats, shoulders",
                        Instructions = "Begin by lying on the bench, getting your head beyond the bar if possible. Tuck your feet underneath you and arch your back. Using the bar to help support your weight, lift your shoulder off the bench and retract them, squeezing the shoulder blades together. Use your feet to drive your traps into the bench. Maintain this tight body position throughout the movement., However wide your grip, it should cover the ring on the bar. Pull the bar out of the rack without protracting your shoulders. Focus on squeezing the bar and trying to pull it apart., Lower the bar to your lower chest or upper stomach. The bar, wrist, and elbow should stay in line at all times., Pause when the barbell touches your torso, and then drive the bar up with as much force as possible. The elbows should be tucked in until lockout.",
                        Category = "powerlifting",
                        ImageUrlOne = "/Bench_Press/0.jpg",
                        ImageUrlTwo = "/Bench_Press/1.jpg",
                        IsDeleted = true
                    }
                }
                   .AsQueryable();

            var mockSet = data.BuildMockDbSet();

            this.mockRepo.Setup(r => r.GetAllAttached())
                         .Returns(mockSet.Object);

            IEnumerable<ExerciseAdminDetailViewModel> resultEnumerable = await exerciseService
                                    .GetAllExerciseForAdminAsync();

            IList<ExerciseAdminDetailViewModel> result = resultEnumerable.ToList();

            Assert.That(result.Count(), Is.EqualTo(3));
            //Assert.IsTrue(result.Any(e => e.Name == "Barbell Deadlift"));
           // Assert.IsTrue(result.Any(e => e.Name == "Barbell Full Squat"));
           // Assert.IsTrue(result.Any(e => e.Name == "Bench Press - Powerlifting"));
        }
    }
}
