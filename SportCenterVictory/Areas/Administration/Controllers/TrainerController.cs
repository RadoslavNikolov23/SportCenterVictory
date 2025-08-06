namespace SportCenterVictory.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    using SCV.Data.Models;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.TrainerServices.Contracts;
    using SCV.Web.ViewModels.Administration.ReferenceVM;
    using SCV.Web.ViewModels.Administration.TrainerBioVM;

    using static SCV.GlCommon.ApplicationConstants;
    using static SCV.GlCommon.RoleConstants;
    using static SCV.GlCommon.ErrorMessages;
    using static SCV.GlCommon.ExceptionMessages;
    using static SCV.GlCommon.ToastMessages;

    public class TrainerController : BaseAdminController<TrainerController>
    {
        private readonly ITrainerService trainerService;
        private readonly ITrainerUserService trainerUserService;
        private readonly UserManager<ApplicationUser> userManager;

        public TrainerController(ITrainerService trainerService, UserManager<ApplicationUser> userManager, ITrainerUserService trainerUserService, ILogger<TrainerController> logger) : base(logger)
        {
            this.trainerService = trainerService;
            this.userManager = userManager;
            this.trainerUserService = trainerUserService;
        }

        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> AddTrainerBio()
        {
            IList<ApplicationUser> trainerUsers = await userManager
                                .GetUsersInRoleAsync(SCV.GlCommon.RoleConstants.Trainer);

            ViewBag.Trainers = new SelectList(trainerUsers, "Id", "UserName");

            return View();
        }

        [HttpPost]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> AddTrainerBio(TrainerBioAddViewModel trainerBioToAddVM)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    this.ModelState.AddModelError(string.Empty, SomethingWentWrong);
                    return this.View(trainerBioToAddVM);
                }

                bool isAddedSuccessfully = await this.trainerService
                                    .AddTrainerBioAsync(trainerBioToAddVM);

                if (!isAddedSuccessfully)
                {
                    this.logger.LogWarning($"Error occurred in the service methods while creating a Trainer.");
                    TempData[WarningMessageKey] = ErrorMessageCannotCreateTrainer;
                    return View(trainerBioToAddVM);
                }

                this.logger.LogInformation($"Successfully a new Trainer was Created with the name {trainerBioToAddVM.FirstName} {trainerBioToAddVM.LastName}");
                TempData[SuccessMessageKey] = SuccessMessageCreatedTrainer;

                switch (trainerBioToAddVM.TrainerSpecialty)
                {
                    case SportType.Fitness:
                        return RedirectToAction("FitnessTrainer", "Fitness", new { area = "" });
                    case SportType.CrossFit:
                        return RedirectToAction("CrossFitCoaches", "Crossfit", new { area = "" });
                    case SportType.Powerlifting:
                        return RedirectToAction("PowerliftingCoaches", "Powerlifting", new { area = "" });
                    default:
                        return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while adding a Trainer Bio. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditTrainerBio()
        {
            try
            {
                ApplicationUser? user = await userManager.GetUserAsync(User);
                IList<string> roles = await userManager.GetRolesAsync(user!);

                if (roles.Contains(SCV.GlCommon.RoleConstants.Trainer))
                {
                    //! Trainer sees only their own bio
                    TrainerBioEditViewModel? trainerEditVM = await trainerService
                                                    .GetTrainerBioByIdAsync(user!.Id.ToString());
                    if (trainerEditVM == null)
                    {
                        return this.NotFoundWithMessage(ErrorMessageCannotFindTrainer);
                    }

                    return View("EditTrainerBioUser", trainerEditVM);
                }

                if (roles.Contains(Manager) || roles.Contains(Admin))
                {
                    // Admins and Managers see the dropdown list
                    IEnumerable<TrainerAdminDetailViewModel> allTrainers = await trainerService
                                                .GetAllTrainersForAdminAsync();

                    return View("EditTrainerBioAdminManager", allTrainers);
                }

                return this.AccessForbiddenWithMessage(AccessIsForbiddenLogOrRegister);

            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error occurred while editing a Trainer Bio. Error: {ex.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> GetTrainer(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    return this.NotFoundWithMessage(ErrorMessageCannotFindTrainer);
                }

                ApplicationUser? user = await userManager.GetUserAsync(User);
                IList<string> roles = await userManager.GetRolesAsync(user!);

                if (!roles.Contains(Admin) && !roles.Contains(Manager))
                {
                    return this.AccessForbiddenWithMessage(AccessIsForbiddenLogOrRegister);
                }

                TrainerBioEditViewModel? trainerVM = await trainerService
                                            .GetTrainerBioByIdAsync(id);

                if (trainerVM == null)
                {
                    return Json(new
                    {
                        success = false,
                        message = ErrorMessageCannotFindTrainer
                    });
                }

                return Json(new
                {
                    success = true,
                    data = trainerVM
                });
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while editing a Trainer Bio with {id}. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditTrainerBio(TrainerBioEditViewModel trainerBioEditVM)
        {
            try
            {
                if (trainerBioEditVM.Id == null)
                {
                    TempData[WarningMessageKey] = SomethingWentWrong;

                    return RedirectToAction(nameof(EditTrainerBio));
                }

                ApplicationUser? user = await userManager.GetUserAsync(User);

                if (!ModelState.IsValid)
                {
                    return View("EditTrainerBioUser", trainerBioEditVM);
                }

                bool isEdited = await trainerService
                                        .EditTrainerBioAsync(trainerBioEditVM, user!.Id.ToString());

                if (!isEdited)
                {
                    TempData[WarningMessageKey] = ErrorMessageNotAuthorizeToEdit;
                    return View("EditTrainerBioUser", trainerBioEditVM);
                }

                TempData[SuccessMessageKey] = SuccessMessageUpdateTrainer;

                switch (trainerBioEditVM.TrainerSpecialty)
                {
                    case SportType.Fitness:
                        return RedirectToAction("FitnessTrainer", "Fitness", new { area = "" });
                    case SportType.CrossFit:
                        return RedirectToAction("CrossFitCoaches", "Crossfit", new { area = "" });
                    case SportType.Powerlifting:
                        return RedirectToAction("PowerliftingCoaches", "Powerlifting", new { area = "" });
                    default:
                        return RedirectToAction("Index", "Home", new { area = "" });
                }

            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error occurred while editing a Trainer Bio with ID: {trainerBioEditVM.Id}. Error: {ex.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> DeleteTrainerBio()
        {
            try
            {
                IEnumerable<TrainerBioDeleteViewModel> trainerBioDeleteVM = await this.trainerService
                                                        .GetAllTrainerBiosForDeletingAsync();

                return this.View(trainerBioDeleteVM);
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while deleting a Trainer Bio. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }


        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> ToggleDelete(string? id)
        {
            try
            {
                (bool isSuccess, bool isRestored) opResult = await this.trainerService
                                        .DeleteOrRestoreTrainerBioAsync(id);

                if (!opResult.isSuccess)
                {
                    TempData[WarningMessageKey] = ErrorMessageCannotFindTrainer;
                }
                else
                {
                    string operation = opResult.isRestored ? Deleted : Restored;

                    TempData[SuccessMessageKey] = string.Format(SuccessMessageTrainerDeleted, operation);
                }

                return this.RedirectToAction(nameof(DeleteTrainerBio));
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while deleting a Trainer Bio with {id}. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> TrainersAndClients()
        {
            try
            {
                IEnumerable<TrainerUserForAdminListViewModel> clientsTrainerList = await this.trainerUserService
                                        .ForAdminTrainerClientsListAsync();

                return View(clientsTrainerList);
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while trying to load all the Trainers and their Clients. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }
    }
}
