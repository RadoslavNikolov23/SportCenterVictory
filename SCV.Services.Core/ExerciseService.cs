namespace SCV.Services.Core
{
    using Microsoft.EntityFrameworkCore;
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.FitnessVM;

    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository exerciseRepo;

        public ExerciseService(IExerciseRepository exerciseRepo)
        {
            this.exerciseRepo = exerciseRepo;
        }

        public async Task<ExercisesDetailViewModel?> GetExerciseByIdAsync(string id)
        {
            ExercisesDetailViewModel? exercisesVM = null;

            if (!String.IsNullOrEmpty(id))
            {
               Exercise? exerciseEntity = await this.exerciseRepo
                                            .GetByIdAsync(id);

                if(exerciseEntity != null)
                {
                    exercisesVM = new ExercisesDetailViewModel()
                    {
                        Name = exerciseEntity.Name,
                        Force = exerciseEntity.Force,
                        Mechanic = exerciseEntity.Mechanic,
                        Equipment = exerciseEntity.Equipment,
                        PrimaryMuscles = exerciseEntity.PrimaryMuscles,
                        SecondaryMuscles = exerciseEntity.SecondaryMuscles,
                        Instructions = exerciseEntity.Instructions,
                        Category = exerciseEntity.Category,
                        ImageUrlOne = exerciseEntity.ImageUrlOne ?? $"/imagesExercises/fallback.jpg",
                        ImageUrlTwo = exerciseEntity.ImageUrlTwo ?? $"/imagesExercises/fallback.jpg"

                    };
                }
            }

            return exercisesVM;
        }

        public async Task<IEnumerable<ExercisesDetailViewModel>> GetAllExercisesAsync()
        {
            IEnumerable<ExercisesDetailViewModel> exercisesViewModels = await this.exerciseRepo
                            .GetAllAttached()
                            .AsNoTracking()
                            .Select(ex => new ExercisesDetailViewModel
                            {
                                Name = ex.Name,
                                Force = ex.Force,
                                Mechanic = ex.Mechanic,
                                Equipment = ex.Equipment,
                                PrimaryMuscles = ex.PrimaryMuscles,
                                SecondaryMuscles = ex.SecondaryMuscles,
                                Instructions = ex.Instructions,
                                Category = ex.Category,
                                ImageUrlOne = ex.ImageUrlOne ?? $"/imagesExercises/fallback.jpg",
                                ImageUrlTwo = ex.ImageUrlTwo ?? $"/imagesExercises/fallback.jpg"
                            })
                            .ToListAsync();

            return exercisesViewModels;
        }

        public async Task<IEnumerable<ExercisesDetailViewModel>> GetExercisesPageAsync(int page, int pageSize, string? query)
        {
            IQueryable<Exercise> exercisesQuery = this.exerciseRepo.GetAllAttached().AsQueryable();

            if (!string.IsNullOrWhiteSpace(query))
            {
                exercisesQuery = exercisesQuery
                    .Where(e => e.Name.ToLower()
                                .Contains(query.ToLower()));
            }

            IEnumerable<ExercisesDetailViewModel> exercisesViewModels = await exercisesQuery
                            .AsNoTracking()
                            //.OrderBy(e => e.Id) // optional, but helps stable paging
                            .Skip((page - 1) * pageSize)
                            .Take(pageSize)
                            .Select(ex => new ExercisesDetailViewModel
                            {
                                Name = ex.Name,
                                Force = ex.Force,
                                Mechanic = ex.Mechanic,
                                Equipment = ex.Equipment,
                                PrimaryMuscles = ex.PrimaryMuscles,
                                SecondaryMuscles = ex.SecondaryMuscles,
                                Instructions = ex.Instructions,
                                Category = ex.Category,
                                ImageUrlOne = ex.ImageUrlOne ?? $"/imagesExercises/fallback.jpg",
                                ImageUrlTwo = ex.ImageUrlTwo ?? $"/imagesExercises/fallback.jpg"
                            })
                            .ToListAsync();

            return exercisesViewModels;

        }

    }
}
