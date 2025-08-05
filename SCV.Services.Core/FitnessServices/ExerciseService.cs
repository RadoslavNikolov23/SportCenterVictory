namespace SCV.Services.Core.FitnessServices
{
    using Microsoft.EntityFrameworkCore;

    using System.Text.RegularExpressions;

    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.Web.ViewModels.Administration.FitnessVM;
    using SCV.Web.ViewModels.FitnessVM;

    using static SCV.GlCommon.ApplicationConstants;
    using SCV.Services.Core.FitnessServices.Contracts;

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

            if (!string.IsNullOrEmpty(id))
            {
                Exercise? exerciseEntity = await exerciseRepo
                                             .GetByIdAsync(id);

                if (exerciseEntity != null)
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
                        ImageUrlOne = exerciseEntity.ImageUrlOne ?? ImageFallback,
                        ImageUrlTwo = exerciseEntity.ImageUrlTwo ??ImageFallback

                    };
                }
            }

            return exercisesVM;
        }



        public async Task<IEnumerable<ExercisesDetailViewModel>> GetAllExercisesAsync()
        {
            IEnumerable<ExercisesDetailViewModel> exercisesViewModels = await exerciseRepo
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
                                ImageUrlOne = ex.ImageUrlOne ?? ImageFallback,
                                ImageUrlTwo = ex.ImageUrlTwo ?? ImageFallback
                            })
                            .ToListAsync();

            return exercisesViewModels;
        }

        public async Task<IEnumerable<ExercisesDetailViewModel>> GetExercisesPageAsync(int page, int pageSize, string? query)
        {
            IQueryable<Exercise> exercisesQuery = exerciseRepo
                                                .GetAllAttached();

            if (!string.IsNullOrWhiteSpace(query))
            {
                exercisesQuery = exercisesQuery
                    .Where(e => e.Name.ToLower()
                                .Contains(query.ToLower()));
            }

            IEnumerable<ExercisesDetailViewModel> exercisesViewModels = await exercisesQuery
                            .AsNoTracking()
                            .OrderBy(e => e.Id) // TODO: optional, for stability in pagination
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
                                ImageUrlOne = ex.ImageUrlOne ?? ImageFallback,
                                ImageUrlTwo = ex.ImageUrlTwo ?? ImageFallback
                            })
                            .ToListAsync();

            return exercisesViewModels;

        }

        public async Task<IEnumerable<ExerciseAdminDetailViewModel>> GetAllExerciseForAdminAsync()
        {
            IEnumerable<ExerciseAdminDetailViewModel> exerciseAdminDetailVM = await
                                                    exerciseRepo
                                                    .GetAllAttached()
                                                    .AsNoTracking()
                                                    .Select(e => new ExerciseAdminDetailViewModel()
                                                    {
                                                        Id = e.Id,
                                                        Name = e.Name,
                                                    })
                                                    .ToListAsync();

            return exerciseAdminDetailVM;

        }

        public async Task<bool> AddExerciseAsync(ExerciseAddViewModel exerciseToAddVM)
        {
            bool isAdded = false;

            if (exerciseToAddVM != null)
            {
                string exerciseId = GenerateExerciseId(exerciseToAddVM.Name);

                Exercise? exerciseExists = await exerciseRepo
                                    .GetAllAttached()
                                    .IgnoreQueryFilters()
                                    .SingleOrDefaultAsync(e => e.Id.ToString().ToLower() == exerciseId.ToLower());

                if (exerciseExists != null)
                {
                    Exercise exerciseToAdd = new Exercise()
                    {
                        Name = exerciseToAddVM.Name,
                        Force = exerciseToAddVM.Force,
                        Mechanic = exerciseToAddVM.Mechanic,
                        Equipment = exerciseToAddVM.Equipment,
                        PrimaryMuscles = exerciseToAddVM.PrimaryMuscles,
                        SecondaryMuscles = exerciseToAddVM.SecondaryMuscles,
                        Instructions = exerciseToAddVM.Instructions,
                        Category = exerciseToAddVM.Category,
                        ImageUrlOne = exerciseToAddVM.ImageUrlOne,
                        ImageUrlTwo = exerciseToAddVM.ImageUrlTwo,
                        IsDeleted = false

                    };

                    isAdded = await exerciseRepo.UpdateAsync(exerciseToAdd);
                }
                else
                {
                    Exercise exerciseToAdd = new Exercise()
                    {
                        Id = exerciseId,
                        Name = exerciseToAddVM.Name,
                        Force = exerciseToAddVM.Force,
                        Mechanic = exerciseToAddVM.Mechanic,
                        Equipment = exerciseToAddVM.Equipment,
                        PrimaryMuscles = exerciseToAddVM.PrimaryMuscles,
                        SecondaryMuscles = exerciseToAddVM.SecondaryMuscles,
                        Instructions = exerciseToAddVM.Instructions,
                        Category = exerciseToAddVM.Category,
                        ImageUrlOne = exerciseToAddVM.ImageUrlOne,
                        ImageUrlTwo = exerciseToAddVM.ImageUrlTwo
                    };
                    await exerciseRepo.AddAsync(exerciseToAdd);
                    isAdded = true;
                }
            }

            return isAdded;
        }


        public async Task<ExerciseEditViewModel?> GetExerciseForEditByIdAsync(string? id)
        {
            ExerciseEditViewModel? exerciseForEditVM = null;

            if (!string.IsNullOrEmpty(id))
            {
                Exercise? exerciseEntity = await exerciseRepo
                                .GetAllAttached()
                                .IgnoreQueryFilters()
                                .SingleOrDefaultAsync(e => e.Id.ToString().ToLower() == id.ToLower());


                if (exerciseEntity != null)
                {
                    exerciseForEditVM = new ExerciseEditViewModel()
                    {
                        Id = exerciseEntity.Id,
                        Name = exerciseEntity.Name,
                        Force = exerciseEntity.Force,
                        Mechanic = exerciseEntity.Mechanic,
                        Equipment = exerciseEntity.Equipment,
                        PrimaryMuscles = exerciseEntity.PrimaryMuscles,
                        SecondaryMuscles = exerciseEntity.SecondaryMuscles,
                        Instructions = exerciseEntity.Instructions,
                        Category = exerciseEntity.Category,
                        ImageUrlOne = exerciseEntity.ImageUrlOne,
                        ImageUrlTwo = exerciseEntity.ImageUrlTwo,
                    };
                }
            }

            return exerciseForEditVM;
        }

        public async Task<bool> EditExerciseAsync(ExerciseEditViewModel exerciseEditVM)
        {
            bool isEdited = false;

            if (exerciseEditVM == null)
            {
                return isEdited;
            }

            Exercise? exerciseEntity = await exerciseRepo
                                    .GetAllAttached()
                                    .SingleOrDefaultAsync(e => e.Id.ToString().ToLower() == exerciseEditVM.Id.ToLower());

            if (exerciseEntity != null)
            {
                if (exerciseEditVM.Name != exerciseEntity.Name)
                {
                    string newId = GenerateExerciseId(exerciseEditVM.Name);

                    Exercise? exerciseExists = await exerciseRepo
                                        .GetAllAttached()
                                        .IgnoreQueryFilters()
                                        .SingleOrDefaultAsync(e => e.Id.ToString().ToLower() == newId.ToLower());

                    if (exerciseExists == null)
                    {
                        exerciseEntity.Id = newId;
                        exerciseEntity.Name = exerciseEditVM.Name;
                        exerciseEntity.Force = exerciseEditVM.Force;
                        exerciseEntity.Mechanic = exerciseEditVM.Mechanic;
                        exerciseEntity.Equipment = exerciseEditVM.Equipment;
                        exerciseEntity.PrimaryMuscles = exerciseEditVM.PrimaryMuscles;
                        exerciseEntity.SecondaryMuscles = exerciseEditVM.SecondaryMuscles;
                        exerciseEntity.Instructions = exerciseEditVM.Instructions;
                        exerciseEntity.Category = exerciseEditVM.Category;
                        exerciseEntity.ImageUrlOne = exerciseEditVM.ImageUrlOne;
                        exerciseEntity.ImageUrlTwo = exerciseEditVM.ImageUrlTwo;

                        isEdited = await exerciseRepo
                                            .UpdateAsync(exerciseEntity);
                        return isEdited;
                    }
                    else
                    {
                        exerciseExists.Name = exerciseEditVM.Name;
                        exerciseExists.Force = exerciseEditVM.Force;
                        exerciseExists.Mechanic = exerciseEditVM.Mechanic;
                        exerciseExists.Equipment = exerciseEditVM.Equipment;
                        exerciseExists.PrimaryMuscles = exerciseEditVM.PrimaryMuscles;
                        exerciseExists.SecondaryMuscles = exerciseEditVM.SecondaryMuscles;
                        exerciseExists.Instructions = exerciseEditVM.Instructions;
                        exerciseExists.Category = exerciseEditVM.Category;
                        exerciseExists.ImageUrlOne = exerciseEditVM.ImageUrlOne;
                        exerciseExists.ImageUrlTwo = exerciseEditVM.ImageUrlTwo;

                        isEdited = await exerciseRepo
                                   .UpdateAsync(exerciseExists);
                        return isEdited;
                    }
                }
                else
                {
                    exerciseEntity.Force = exerciseEditVM.Force;
                    exerciseEntity.Mechanic = exerciseEditVM.Mechanic;
                    exerciseEntity.Equipment = exerciseEditVM.Equipment;
                    exerciseEntity.PrimaryMuscles = exerciseEditVM.PrimaryMuscles;
                    exerciseEntity.SecondaryMuscles = exerciseEditVM.SecondaryMuscles;
                    exerciseEntity.Instructions = exerciseEditVM.Instructions;
                    exerciseEntity.Category = exerciseEditVM.Category;
                    exerciseEntity.ImageUrlOne = exerciseEditVM.ImageUrlOne;
                    exerciseEntity.ImageUrlTwo = exerciseEditVM.ImageUrlTwo;

                    isEdited = await exerciseRepo
                                            .UpdateAsync(exerciseEntity);
                }
            }

            return isEdited;
        }

        public async Task<ExerciseDeletePageViewModel> GetAllExerciseForDeletingByPageAsync(int page = 1, string? searchTerm = null)
        {

            int pageSize = 20;
            IQueryable<Exercise> exercisesList = exerciseRepo
                                                        .GetAllAttached()
                                                        .IgnoreQueryFilters();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.Trim().ToLower();
                exercisesList = exercisesList
                                    .Where(e => e.Name.ToLower().Contains(searchTerm));
            }

            int totalCount = await exercisesList.CountAsync();

            IEnumerable<ExerciseDeleteViewModel> listExerciseDeleteVM = await exercisesList
                                                           .OrderBy(e => e.Id)
                                                           .Skip((page - 1) * pageSize)
                                                           .Take(pageSize)
                                                           .Select(e => new ExerciseDeleteViewModel()
                                                           {
                                                               Id = e.Id,
                                                               Name = e.Name,
                                                               PrimaryMuscles = e.PrimaryMuscles,
                                                               Category = e.Category,
                                                               IsDeleted = e.IsDeleted
                                                           })
                                                           .ToListAsync();

            ExerciseDeletePageViewModel exerciseDeletePage = new ExerciseDeletePageViewModel
                                        {
                                            Exercises = listExerciseDeleteVM,
                                            CurrentPage = page,
                                            TotalPages = (int)Math.Ceiling((double)totalCount / pageSize),
                                            SearchTerm = searchTerm
                                        };


            return exerciseDeletePage;
        }

        public async Task<(bool, bool)> DeleteOrRestoreExerciseAsync(string? id)
        {
            bool result = false;
            bool isRestored = false;

            if (!string.IsNullOrWhiteSpace(id))
            {
                Exercise? exerciseEntity = await exerciseRepo
                                    .GetAllAttached()
                                    .IgnoreQueryFilters()
                                    .SingleOrDefaultAsync(c => c.Id.ToLower() == id.ToLower());

                if (exerciseEntity != null)
                {
                    if (!exerciseEntity.IsDeleted)
                    {
                        isRestored = true;
                    }

                    exerciseEntity.IsDeleted = !exerciseEntity.IsDeleted;

                    result = await exerciseRepo
                                    .UpdateAsync(exerciseEntity);
                }
            }

            return (result, isRestored);
        }

        private string GenerateExerciseId(string nameExercise)
        {
            return Regex.Replace(nameExercise.Trim().ToLower(), @"[^a-z0-9]+", "_").Trim('_');
        }
    }
}
