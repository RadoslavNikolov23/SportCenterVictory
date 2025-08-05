namespace SCV.Test.ServiceTests
{
    using MockQueryable.Moq;
    using Moq;
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.FitnessServices;
    using SCV.Web.ViewModels.Administration.FitnessVM;
    using System.Linq;

    [TestFixture]
    public class WorkoutPlanServiceTests
    {
        private Mock<IWorkoutPlanRepository> mockRepo;
        private WorkoutPlanService service;

        [SetUp]
        public void SetUp()
        {
            mockRepo = new Mock<IWorkoutPlanRepository>();
            service = new WorkoutPlanService(mockRepo.Object);
        }

        [Test]
        public async Task GetAllWorkoutPlansBySportTypeAsync_ReturnsCorrectPlans()
        {
            Guid workoutPlanId = Guid.NewGuid();
            string exerciseId = "Barbell_Full_Squat";

            IQueryable<WorkoutPlan> data = new List<WorkoutPlan>
        {
            new WorkoutPlan
            {
                Id = workoutPlanId,
                Title = "Full Body – Beginner Fitness",
                Description = "Day 1 – Upper Body\n- Lat Pulldown: 3 sets x 8-10 reps\n- Bent Over Rows: 3 x 8-10 reps \n- Barbell Bench Press: 3 sets x 8-10 reps\n- Dumbbell Shoulder Press: 3 x 8-10 reps \n- Bicep Curl with dumbbells: 3 x 8-10 reps \n- Triceps Pushdown: 3 x 8-10 reps\n\nDay 2 – Lower Body\n- Squats: 3 x 8-10\n- Bodyweight Walking Lunges: 3 x 8-10 each leg\n- Lying Leg Curls: 3 x 8-10\n- Standing Calf Raises: 3 x 10\n- Plank: 3 x 30 sec\n- Crunches: 3 x 12-15 \n\nDay 3 – Optional Cardio or Rest day\n- For warm up: Burpees: 3 x 10\n- 20 minutes of walking on the Treadmill\nOr 20 minutes on the  Exercise bikes",
                Type = SportType.Fitness,
                ImageUrl  = "workoutOne.jpg",
                WorkoutPlanExercises = new List<WorkoutPlanExercise>
                {
                    new WorkoutPlanExercise
                    {
                        ExerciseId = exerciseId,
                        Exercise = new Exercise
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
                        WorkoutPlanId = workoutPlanId
                    }
                }
            }
        }.AsQueryable();

            var mockSet = data.BuildMockDbSet();
            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);

            var result = await service.GetAllWorkoutPlansBySportTypeAsync(SportType.Fitness);

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().WorkoutPlanExercisesVM.Count(), Is.EqualTo(1));

            Assert.That(result.First().Title, Is.EqualTo("Full Body – Beginner Fitness"));
            Assert.That(result.First().WorkoutPlanExercisesVM.First().ExerciseName, Is.EqualTo("Barbell Full Squat"));
        }

        [Test]
        public async Task GetAllWorkoutPlansForAdminAsync_ReturnsAll()
        {
            IQueryable<WorkoutPlan> data = new List<WorkoutPlan>
        {
          new WorkoutPlan
            {
                Id = Guid.NewGuid(),
                Title = "Full Body – Beginner Fitness",
                Description = "Day 1 – Upper Body\n- Lat Pulldown: 3 sets x 8-10 reps\n- Bent Over Rows: 3 x 8-10 reps \n- Barbell Bench Press: 3 sets x 8-10 reps\n- Dumbbell Shoulder Press: 3 x 8-10 reps \n- Bicep Curl with dumbbells: 3 x 8-10 reps \n- Triceps Pushdown: 3 x 8-10 reps\n\nDay 2 – Lower Body\n- Squats: 3 x 8-10\n- Bodyweight Walking Lunges: 3 x 8-10 each leg\n- Lying Leg Curls: 3 x 8-10\n- Standing Calf Raises: 3 x 10\n- Plank: 3 x 30 sec\n- Crunches: 3 x 12-15 \n\nDay 3 – Optional Cardio or Rest day\n- For warm up: Burpees: 3 x 10\n- 20 minutes of walking on the Treadmill\nOr 20 minutes on the  Exercise bikes",
                Type = SportType.Fitness,
                ImageUrl  = "workoutOne.jpg"
            },
            new WorkoutPlan
            {
                Id = Guid.NewGuid(),
                Title = "Muscle Sculpt – Intermediate Fitness",
                Description = "Day 1 – Chest & Triceps\n- Bench Press: 4 x 6-8\n- Incline Dumbbell Press: 4 x 8-10\n- Cable Crossover: 4 x 10-12\n- EZ-Bar Skullcrusher: 3 x 8-10\n- Triceps Dips: 3 x 10-12\n\nDay 2 – Back & Biceps\n- Barbell Deadlift: 4 x 6\n- Lat Pulldowns: 4 x 10-12\n- Seated Cable Rows: 4 x 10-12- Dumbbell Curls: 3 x 8-10\n- Hammer Curls: 3 x 10-12\n\nDay 3 – Legs & Abs\n- Squats: 4 x 6\n- Romanian Deadlifts: 4 x 8-10\n- Leg Extensions: 4 x 10-12\n- Lying Leg Curls: 3 x 10-12\n- Ab Roller: 3 x 12\n- Hanging Leg Raises: 3 x 12",
                Type = SportType.Fitness,
                ImageUrl = "workoutTwo.jpg"
            }
        }.AsQueryable();


            var mockSet = data.BuildMockDbSet();
            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);

            var resultEnumerable = await service.GetAllWorkoutPlansForAdminAsync();

            var result = resultEnumerable.ToList();

            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result[0].Title, Is.EqualTo("Full Body – Beginner Fitness"));
            Assert.That(result[1].Title, Is.EqualTo("Muscle Sculpt – Intermediate Fitness"));
        }

        [Test]
        public async Task AddWorkoutPlanAsync_ValidInput_ReturnsTrue()
        {
            WorkoutPlanAddViewModel workoutPlanAddViewModel = new WorkoutPlanAddViewModel
            {
                Title = "Full Body – Beginner Fitness",
                Description = "Day 1 – Upper Body\n- Lat Pulldown: 3 sets x 8-10 reps\n- Bent Over Rows: 3 x 8-10 reps \n- Barbell Bench Press: 3 sets x 8-10 reps\n- Dumbbell Shoulder Press: 3 x 8-10 reps \n- Bicep Curl with dumbbells: 3 x 8-10 reps \n- Triceps Pushdown: 3 x 8-10 reps\n\nDay 2 – Lower Body\n- Squats: 3 x 8-10\n- Bodyweight Walking Lunges: 3 x 8-10 each leg\n- Lying Leg Curls: 3 x 8-10\n- Standing Calf Raises: 3 x 10\n- Plank: 3 x 30 sec\n- Crunches: 3 x 12-15 \n\nDay 3 – Optional Cardio or Rest day\n- For warm up: Burpees: 3 x 10\n- 20 minutes of walking on the Treadmill\nOr 20 minutes on the  Exercise bikes",
                Type = SportType.Fitness,
                ImageUrl = "workoutOne.jpg"
            };

            mockRepo.Setup(r => r.AddAsync(It.IsAny<WorkoutPlan>()))
                    .Returns(Task.CompletedTask);

            bool isAdded = await service.AddWorkoutPlanAsync(workoutPlanAddViewModel);

            Assert.IsTrue(isAdded);
        }

        [Test]
        public async Task GetWorkoutPlanByIdAsync_ValidId_ReturnsWorkout()
        {
            Guid workoutPlanId = Guid.NewGuid();

            IQueryable<WorkoutPlan> data = new List<WorkoutPlan>
        {
            new WorkoutPlan
            {
                Id = workoutPlanId,
                Title = "Full Body – Beginner Fitness",
                Description = "Day 1 – Upper Body\n- Lat Pulldown: 3 sets x 8-10 reps\n- Bent Over Rows: 3 x 8-10 reps \n- Barbell Bench Press: 3 sets x 8-10 reps\n- Dumbbell Shoulder Press: 3 x 8-10 reps \n- Bicep Curl with dumbbells: 3 x 8-10 reps \n- Triceps Pushdown: 3 x 8-10 reps\n\nDay 2 – Lower Body\n- Squats: 3 x 8-10\n- Bodyweight Walking Lunges: 3 x 8-10 each leg\n- Lying Leg Curls: 3 x 8-10\n- Standing Calf Raises: 3 x 10\n- Plank: 3 x 30 sec\n- Crunches: 3 x 12-15 \n\nDay 3 – Optional Cardio or Rest day\n- For warm up: Burpees: 3 x 10\n- 20 minutes of walking on the Treadmill\nOr 20 minutes on the  Exercise bikes",
                Type = SportType.Fitness,
                ImageUrl = "workoutOne.jpg"
            }
        }.AsQueryable();

            var mockSet = data.BuildMockDbSet();
            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);

            WorkoutPlanEditViewModel? result = await service
                                .GetWorkoutPlanByIdAsync(workoutPlanId.ToString());

            Assert.IsNotNull(result);
            Assert.That(result.Title, Is.EqualTo("Full Body – Beginner Fitness"));
            Assert.That(result.Description, Is.EqualTo("Day 1 – Upper Body\n- Lat Pulldown: 3 sets x 8-10 reps\n- Bent Over Rows: 3 x 8-10 reps \n- Barbell Bench Press: 3 sets x 8-10 reps\n- Dumbbell Shoulder Press: 3 x 8-10 reps \n- Bicep Curl with dumbbells: 3 x 8-10 reps \n- Triceps Pushdown: 3 x 8-10 reps\n\nDay 2 – Lower Body\n- Squats: 3 x 8-10\n- Bodyweight Walking Lunges: 3 x 8-10 each leg\n- Lying Leg Curls: 3 x 8-10\n- Standing Calf Raises: 3 x 10\n- Plank: 3 x 30 sec\n- Crunches: 3 x 12-15 \n\nDay 3 – Optional Cardio or Rest day\n- For warm up: Burpees: 3 x 10\n- 20 minutes of walking on the Treadmill\nOr 20 minutes on the  Exercise bikes"));
            Assert.That(result.ImageUrl, Is.EqualTo("workoutOne.jpg"));
        }

        [Test]
        public async Task EditWorkoutPlanAsync_ValidInput_ReturnsTrue()
        {
            Guid workoutPlanId = Guid.NewGuid();

            WorkoutPlan entity = new WorkoutPlan
            {
                Id = workoutPlanId,
                Title = "Full Body – Beginner Fitness",
                Description = "Day 1 – Upper Body\n- Lat Pulldown: 3 sets x 8-10 reps\n- Bent Over Rows: 3 x 8-10 reps \n- Barbell Bench Press: 3 sets x 8-10 reps\n- Dumbbell Shoulder Press: 3 x 8-10 reps \n- Bicep Curl with dumbbells: 3 x 8-10 reps \n- Triceps Pushdown: 3 x 8-10 reps\n\nDay 2 – Lower Body\n- Squats: 3 x 8-10\n- Bodyweight Walking Lunges: 3 x 8-10 each leg\n- Lying Leg Curls: 3 x 8-10\n- Standing Calf Raises: 3 x 10\n- Plank: 3 x 30 sec\n- Crunches: 3 x 12-15 \n\nDay 3 – Optional Cardio or Rest day\n- For warm up: Burpees: 3 x 10\n- 20 minutes of walking on the Treadmill\nOr 20 minutes on the  Exercise bikes",
                Type = SportType.Fitness,
                ImageUrl = "workoutOne.jpg"
            };

            IQueryable<WorkoutPlan> data = new List<WorkoutPlan>
                                        {
                                            entity
                                        }
                                            .AsQueryable();

            WorkoutPlanEditViewModel workoutPlanEditViewModel = new WorkoutPlanEditViewModel
            {
                Id = workoutPlanId.ToString(),
                Title = "Edited Full Body",
                Description = "Updated - Test",
                Type = SportType.CrossFit,
                ImageUrl = "new.jpg"
            };

            var mockSet = data.BuildMockDbSet();
            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);
            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<WorkoutPlan>()))
                    .ReturnsAsync(true);

            bool isEdited = await service
                            .EditWorkoutPlanAsync(workoutPlanEditViewModel);

            Assert.IsTrue(isEdited);
        }

        [Test]
        public async Task GetAllWorkoutPlanForDeletingAsync_ReturnsAll()
        {
            IQueryable<WorkoutPlan> data = new List<WorkoutPlan>
        {
            new WorkoutPlan
            {
                Id = Guid.NewGuid(),
                Title = "Full Body – Beginner Fitness",
                Description = "Day 1 – Upper Body\n- Lat Pulldown: 3 sets x 8-10 reps\n- Bent Over Rows: 3 x 8-10 reps \n- Barbell Bench Press: 3 sets x 8-10 reps\n- Dumbbell Shoulder Press: 3 x 8-10 reps \n- Bicep Curl with dumbbells: 3 x 8-10 reps \n- Triceps Pushdown: 3 x 8-10 reps\n\nDay 2 – Lower Body\n- Squats: 3 x 8-10\n- Bodyweight Walking Lunges: 3 x 8-10 each leg\n- Lying Leg Curls: 3 x 8-10\n- Standing Calf Raises: 3 x 10\n- Plank: 3 x 30 sec\n- Crunches: 3 x 12-15 \n\nDay 3 – Optional Cardio or Rest day\n- For warm up: Burpees: 3 x 10\n- 20 minutes of walking on the Treadmill\nOr 20 minutes on the  Exercise bikes",
                Type = SportType.Fitness,
                ImageUrl  = "workoutOne.jpg",
                IsDeleted = false
            }
        }.AsQueryable();

            var mockSet = data.BuildMockDbSet();
            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);

            IEnumerable<WorkoutPlanDeleteViewModel> result = await service
                                .GetAllWorkoutPlanForDeletingAsync();

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().Title, Is.EqualTo("Full Body – Beginner Fitness"));
        }

        [Test]
        public async Task DeleteOrRestoreWorkoutPlanAsync_TogglesDeletion()
        {
            Guid workoutPlanid = Guid.NewGuid();
            WorkoutPlan entity = new WorkoutPlan
            {
                Id = workoutPlanid,
                Title = "Full Body – Beginner Fitness",
                Description = "Day 1 – Upper Body\n- Lat Pulldown: 3 sets x 8-10 reps\n- Bent Over Rows: 3 x 8-10 reps \n- Barbell Bench Press: 3 sets x 8-10 reps\n- Dumbbell Shoulder Press: 3 x 8-10 reps \n- Bicep Curl with dumbbells: 3 x 8-10 reps \n- Triceps Pushdown: 3 x 8-10 reps\n\nDay 2 – Lower Body\n- Squats: 3 x 8-10\n- Bodyweight Walking Lunges: 3 x 8-10 each leg\n- Lying Leg Curls: 3 x 8-10\n- Standing Calf Raises: 3 x 10\n- Plank: 3 x 30 sec\n- Crunches: 3 x 12-15 \n\nDay 3 – Optional Cardio or Rest day\n- For warm up: Burpees: 3 x 10\n- 20 minutes of walking on the Treadmill\nOr 20 minutes on the  Exercise bikes",
                Type = SportType.Fitness,
                ImageUrl = "workoutOne.jpg",
                IsDeleted = false
            };
            IQueryable<WorkoutPlan> data = new List<WorkoutPlan>
                                            {
                                                entity
                                            }
                                                .AsQueryable();

            var mockSet = data.BuildMockDbSet();
            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);
            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<WorkoutPlan>()))
                    .ReturnsAsync(true);

            (bool result, bool restored) = await service
                        .DeleteOrRestoreWorkoutPlanAsync(workoutPlanid.ToString());

            Assert.IsTrue(result);
            Assert.IsTrue(restored); // because it was NOT deleted before
        }
    }
}
