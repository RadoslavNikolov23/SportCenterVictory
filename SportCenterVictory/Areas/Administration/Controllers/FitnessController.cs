namespace SportCenterVictory.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SCV.Services.Core.FitnessServices.Contracts;
    using SCV.Web.ViewModels.Administration.FitnessVM;

    using static SCV.GlCommon.ApplicationConstants;
    using static SCV.GlCommon.RoleConstants;
    using static SCV.GlCommon.ErrorMessages;
    using static SCV.GlCommon.ExceptionMessages;
    using static SCV.GlCommon.ToastMessages;

    public class FitnessController : BaseAdminController<FitnessController>
    {
        private readonly IExerciseService exerciseService;
        private readonly IWorkoutPlanService workoutPlanService;
        private readonly IWorkoutPlanExerciseService workoutPlanExerciseService;

        public FitnessController(IExerciseService exerciseService, IWorkoutPlanService workoutPlanService, IWorkoutPlanExerciseService workoutPlanExerciseService, ILogger<FitnessController> logger) : base(logger)
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
                    this.ModelState.AddModelError(string.Empty, SomethingWentWrong);

                    return this.View(exerciseAddVM);
                }

                bool isAddedSuccessfully = await this.exerciseService
                                                        .AddExerciseAsync(exerciseAddVM);

                if (!isAddedSuccessfully)
                {
                    this.logger.LogWarning($"Error occurred in the Service methods while trying to add an Exercise.");
                    TempData[ErrorMessageKey] = ErrorMessageCannotCreateExercise;
                    return View(exerciseAddVM);
                }


                TempData[SuccessMessageKey] = SuccessMessageCreatedExercise;

                return View(nameof(AddExercise));

            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while Adding Exercise. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
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
                this.logger.LogError($"Error occurred while Editing Exercise. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
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
                        message = ErrorMessageCannotFindExercise
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
                this.logger.LogError($"Error occurred while Editing Exercise with ID:{id}. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditExercise(ExerciseEditViewModel exerciseEditVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(exerciseEditVM);
                }

                bool isEditSuccessfully = await exerciseService.EditExerciseAsync(exerciseEditVM);


                if (!isEditSuccessfully)
                {
                    this.logger.LogWarning($"Error occurred while editing a Exercise with Id{exerciseEditVM.Id}");
                    TempData[ErrorMessageKey] = string.Format(ErrorMessageCannotUpdateExercise, exerciseEditVM.Name); ;
                    return View(exerciseEditVM);
                }


                TempData[SuccessMessageKey] = string.Format(SuccessMessageUpdateExercise, exerciseEditVM.Name);

                return RedirectToAction("Exercises", "Fitness");
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while Editing Exercise with ID:{exerciseEditVM.Id}. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> DeleteExercise(int page = 1, string? searchTerm = null)
        {
            try
            {
                ExerciseDeletePageViewModel exerciseDeletePageVM = await this.exerciseService
                            .GetAllExerciseForDeletingByPageAsync(page, searchTerm);

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return PartialView("_ExerciseDeleteTablePartial", exerciseDeletePageVM);
                }

                return this.View(exerciseDeletePageVM);
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while Deleting Exercise. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
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
                    TempData[ErrorMessageKey] = ErrorMessageCannotFindExercise;
                }
                else
                {
                    string operation = opResult.isRestored ? Deleted : Restored;

                    TempData[SuccessMessageKey] = string.Format(SuccessMessageDeleteExercise, operation);
                }

                return this.RedirectToAction(nameof(DeleteExercise));
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while Deletin Exercise with ID:{id}. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        //------------------Workout Plan------------------------

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
                    this.ModelState.AddModelError(string.Empty, SomethingWentWrong);
                    return this.View(workoutPlanAddVM);
                }

                bool isAddedSuccessfully = await this.workoutPlanService
                                                        .AddWorkoutPlanAsync(workoutPlanAddVM);

                if (!isAddedSuccessfully)
                {
                    this.logger.LogWarning($"Error occurred in the service methods while creating a Workout Plan");
                    TempData[ErrorMessageKey] = ErrorMessageCannotCreateWorkoutPlan;

                    return View(workoutPlanAddVM);
                }

                TempData[SuccessMessageKey] = SuccessMessageCreatedWorkoutPlan;

                return RedirectToAction(nameof(AddWorkoutPlan));

            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while adding the Workout Plan. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
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
                this.logger.LogError($"Error occurred while editing the Workout Plan. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
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
                        message = ErrorMessageCannotFindWorkoutPlan
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
                this.logger.LogError($"Error occurred while editing the Workout Plan with ID:{id}. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditWorkoutPlan(WorkoutPlanEditViewModel workoutPlanEditVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(workoutPlanEditVM);
                }

                bool isEditSuccessfully = await workoutPlanService.EditWorkoutPlanAsync(workoutPlanEditVM);


                if (!isEditSuccessfully)
                {
                    this.logger.LogWarning($"Error occurred while editing a Workout Plan with Id:{workoutPlanEditVM.Id}");
                    TempData[ErrorMessageKey] = string.Format(ErrorMessageCannotUpdateWorkoutPlan, workoutPlanEditVM.Title); ;
                    return View(workoutPlanEditVM);
                }


                TempData[SuccessMessageKey] = string.Format(SuccessMessageUpdateWorkoutPlan, workoutPlanEditVM.Title);

                return RedirectToAction("WorkoutPlan", "Fitness");
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while editing the Workout Plan with ID:{workoutPlanEditVM.Id}. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
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
            catch (Exception ex)
            {
                this.logger.LogError($"Error occurred while deleting the Workout Plan. Error: {ex.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
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
                    TempData[ErrorMessageKey] = ErrorMessageCannotFindWorkoutPlan;
                }
                else
                {
                    string operation = opResult.isRestored ? Deleted : Restored;

                    TempData[SuccessMessageKey] = string.Format(SuccessMessageDeleteWorkoutPlan, operation);
                }

                return this.RedirectToAction(nameof(DeleteWorkoutPlan));
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while deleting the Workout Plan with ID: {id}. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
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
            try
            {
                WorkoutPlanEditViewModel? workoutPlan = await workoutPlanService
                                    .GetWorkoutPlanByIdAsync(id);

                if (workoutPlan == null)
                {
                    this.logger.LogWarning($"Error occurred while trying to attach Exercise to WorkoutPlan with ID: {id}.");

                    TempData[ErrorMessageKey] = ErrorMessageCannotFindWorkoutPlan;
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
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while trying to attach Exercise to WorkoutPlan with ID: {id}. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
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

                TempData[SuccessMessageKey] = SuccessMessageWorkoutPlanExerciseUpdate;
                return RedirectToAction(nameof(EditWorkoutPlan), "Fitness");
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while trying attaching Exercises to the Workout Plan. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

    }
}
