namespace SportCenterVictory.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.Administration.FitnessVM;

    using static SCV.GlCommon.ApplicationConstants;
    using static SCV.GlCommon.RoleConstants;

    public class FitnessController : BaseAdminController
    {
        private readonly IExerciseService exerciseService;
        private readonly IWorkoutPlanService workoutPlanService;
        private readonly IWorkoutPlanExerciseService workoutPlanExerciseService;

        public FitnessController(IExerciseService exerciseService, IWorkoutPlanService workoutPlanService, IWorkoutPlanExerciseService workoutPlanExerciseService)
        {
            this.exerciseService = exerciseService;
            this.workoutPlanService = workoutPlanService;
            this.workoutPlanExerciseService = workoutPlanExerciseService;
        }

        [HttpGet]
        public IActionResult AddExercise()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddExercise(ExerciseAddViewModel exerciseAddVM)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    this.ModelState.AddModelError(string.Empty, "Something went wrong, try again!");

                    return this.View(exerciseAddVM);
                }

                bool isAddedSuccessfully = await this.exerciseService
                                                        .AddExerciseAsync(exerciseAddVM);

                if (!isAddedSuccessfully)
                {
                    TempData[ErrorMessageKey] = "Exercise could not be created. Please try again.";

                    return View(exerciseAddVM);
                }


                TempData[SuccessMessageKey] = "Exercise added successfully!";

                return View(nameof(AddExercise));

            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while adding the Exercise! Please contact developer team! The error is {e.Message}";
                return RedirectToAction("Index", "Home");
            }
        }


        [HttpGet]
        public async Task<IActionResult> EditExercise()
        {

            try
            {
                IEnumerable<ExerciseAdminDetailViewModel> exerciseAdminDetailVM = await this.exerciseService
                            .GetAllExerciseForAdminAsync();

                return this.View(exerciseAdminDetailVM);
            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while editing the Exercise! Please contact developer team! The error is {e.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetExercise(string? id)
        {
            try
            {
                ExerciseEditViewModel? exerciseEditVM = await this.exerciseService
                                                        .GetExerciseForEditByIdAsync(id);

                if (exerciseEditVM == null)
                {
                    return Json(new
                    {
                        success = false,
                        message = "Exercise could not be found. Please try again."
                    });
                }

                return Json(new
                {
                    success = true,
                    data = new
                    {
                        id = exerciseEditVM.Id,
                        name = exerciseEditVM.Name,
                        force = exerciseEditVM.Force,
                        mechanic = exerciseEditVM.Mechanic,
                        equipment = exerciseEditVM.Equipment,
                        primaryMuscles = exerciseEditVM.PrimaryMuscles,
                        secondaryMuscles = exerciseEditVM.SecondaryMuscles,
                        instructions = exerciseEditVM.Instructions,
                        category = exerciseEditVM.Category,
                        imageUrlOne = exerciseEditVM.ImageUrlOne,
                        imageUrlTwo = exerciseEditVM.ImageUrlTwo,
                    }
                });
            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while editing the Exercise! Please contact developer team! The error is {e.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditExercise(ExerciseEditViewModel exerciseEditVM)
        {
            if (!ModelState.IsValid)
            {
                return View(exerciseEditVM);
            }

            await exerciseService.EditExerciseAsync(exerciseEditVM);

            TempData["Success"] = $"Exercise {exerciseEditVM.Name} updated successfully!";

            return RedirectToAction("Exercises", "Fitness", new { area = "" });
        }

        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> DeleteExercise()
        {
            try
            {
                IEnumerable<ExerciseDeleteViewModel> exerciseDeleteDetailVM = await this.exerciseService
                            .GetAllExerciseForDeletingAsync();

                return this.View(exerciseDeleteDetailVM);
            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while deleting the Exercise! Please contact developer team! The error is {e.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> ToggleDeleteExercise(string? id)
        {
            try
            {
                (bool isSuccess, bool isRestored) opResult = await this.exerciseService
                                        .DeleteOrRestoreExerciseAsync(id);

                if (!opResult.isSuccess)
                {
                    TempData[ErrorMessageKey] = "Exercise could not be found and deleted!";
                }
                else
                {
                    string operation = opResult.isRestored ? "Deleted" : "Restored";

                    TempData[SuccessMessageKey] = $"Exercise is {operation} successfully!";
                }

                return this.RedirectToAction(nameof(DeleteExercise));
            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while deleting the Exercise! Please contact developer team! The error is {e.Message}";

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public IActionResult AddWorkoutPlan()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkoutPlan(WorkoutPlanAddViewModel workoutPlanAddVM)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    this.ModelState.AddModelError(string.Empty, "Something went wrong, try again!");

                    return this.View(workoutPlanAddVM);
                }

                bool isAddedSuccessfully = await this.workoutPlanService
                                                        .AddWorkoutPlanAsync(workoutPlanAddVM);

                if (!isAddedSuccessfully)
                {
                    TempData[ErrorMessageKey] = "Workout Plan could not be created. Please try again.";

                    return View(workoutPlanAddVM);
                }


                TempData[SuccessMessageKey] = "Workout Plan added successfully!";

                return RedirectToAction(nameof(AddWorkoutPlan));

            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while adding the Workout Plan! Please contact developer team! The error is {e.Message}";
                return RedirectToAction("Index", "Home");
            }
        }


        [HttpGet]
        public async Task<IActionResult> EditWorkoutPlan()
        {

            try
            {
                IEnumerable<WorkoutPlanAdminDetailViewModel> workoutPlanAdminDetailVM = await this.workoutPlanService
                                                .GetAllWorkoutPlansForAdminAsync();

                return this.View(workoutPlanAdminDetailVM);
            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while editing the Workout Plan! Please contact developer team! The error is {e.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetWorkoutPlan(string? id)
        {
            try
            {
                WorkoutPlanEditViewModel? workoutPlanEditVM = await this.workoutPlanService
                                                        .GetWorkoutPlanByIdAsync(id);

                if (workoutPlanEditVM == null)
                {
                    return Json(new
                    {
                        success = false,
                        message = "Workout Plan could not be found. Please try again."
                    });
                }

                return Json(new
                {
                    success = true,
                    data = new
                    {
                        id = workoutPlanEditVM.Id,
                        title = workoutPlanEditVM.Title,
                        description = workoutPlanEditVM.Description,
                        type = (int)workoutPlanEditVM.Type,
                        imageUrl = workoutPlanEditVM.ImageUrl
                    }
                });
            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while editing the Workout Plan! Please contact developer team! The error is {e.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditWorkoutPlan(WorkoutPlanEditViewModel workoutPlanEditVM)
        {
            if (!ModelState.IsValid)
            {
                return View(workoutPlanEditVM);
            }

            await workoutPlanService.EditWorkoutPlanAsync(workoutPlanEditVM);

            TempData["Success"] = $"Workout Plan {workoutPlanEditVM.Title} updated successfully!";

            return RedirectToAction("WorkoutPlab", "Fitness", new { area = "" });

        }

        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> DeleteWorkoutPlan()
        {
            try
            {
                IEnumerable<WorkoutPlanDeleteViewModel> workoutPlanDeleteDetailVM = await this.workoutPlanService
                                        .GetAllWorkoutPlanForDeletingAsync();

                return this.View(workoutPlanDeleteDetailVM);
            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while deleting the Workout Plan! Please contact developer team! The error is {e.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> ToggleDeleteWorkoutPlan(string? id)
        {
            try
            {
                (bool isSuccess, bool isRestored) opResult = await this.workoutPlanService
                                        .DeleteOrRestoreWorkoutPlanAsync(id);

                if (!opResult.isSuccess)
                {
                    TempData[ErrorMessageKey] = "Workout Plan could not be found and deleted!";
                }
                else
                {
                    string operation = opResult.isRestored ? "Deleted" : "Restored";

                    TempData[SuccessMessageKey] = $"Workout Plan is {operation} successfully!";
                }

                return this.RedirectToAction(nameof(DeleteWorkoutPlan));
            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while deleting the Workout Plan! Please contact developer team! The error is {e.Message}";

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> SelectWorkoutPlan()
        {
            IEnumerable<WorkoutPlanAdminDetailViewModel> workoutPlans = await workoutPlanService.GetAllWorkoutPlansForAdminAsync();

            WorkoutPlanSelectListViewModel WorkoutPlansSelectedListVM = new WorkoutPlanSelectListViewModel
                                        {
                                            WorkoutPlans = workoutPlans
                                        };

            return View(WorkoutPlansSelectedListVM);
        }

        [HttpGet]
        public async Task<IActionResult> AttachExercises(string id)
        {
            WorkoutPlanEditViewModel? workoutPlan = await workoutPlanService
                                .GetWorkoutPlanByIdAsync(id);

            if (workoutPlan == null)
            {
                TempData[ErrorMessageKey] = "Workout plan not found.";

                return RedirectToAction(nameof(EditWorkoutPlan), "Fitness");
            }

            IEnumerable<ExerciseAdminDetailViewModel> allExercises = await exerciseService
                                                    .GetAllExerciseForAdminAsync();

            ICollection<string> attachedIds = await workoutPlanExerciseService
                                .GetExerciseIdsForWorkoutPlanAsync(id);

            WorkoutPlanExerciseAttachViewModel workoutPlanExerciseAttachVM = new WorkoutPlanExerciseAttachViewModel
            {
                WorkoutPlanId = id,
                WorkoutPlanTitle = workoutPlan.Title,
                AllExercises = allExercises,
                AttachedExerciseIds = attachedIds
            };

            return View(workoutPlanExerciseAttachVM);
        }

        [HttpPost]
        public async Task<IActionResult> AttachExercises(WorkoutPlanExerciseAttachViewModel workoutPlanExerciseAttachVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    workoutPlanExerciseAttachVM.AllExercises = await exerciseService
                                                        .GetAllExerciseForAdminAsync();
                    return View(workoutPlanExerciseAttachVM);
                }

                await workoutPlanExerciseService
                    .UpdateExercisesForWorkoutPlanAsync(workoutPlanExerciseAttachVM.WorkoutPlanId, workoutPlanExerciseAttachVM.SelectedExerciseIds ?? new List<string>());

                TempData["Success"] = "Exercises updated successfully.";
                return RedirectToAction("EditWorkoutPlan", "Fitness");
            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while attaching Exercises to the Workout Plan! Please contact developer team! The error is {e.Message}";

                return RedirectToAction("Index", "Home");
            }
        }

    }
}
