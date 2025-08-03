namespace SportCenterVictory.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    using SCV.Data.Models;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.Administration.ReferenceVM;
    using SCV.Web.ViewModels.Administration.TrainerBioVM;

    using static SCV.GlCommon.ApplicationConstants;
    using static SCV.GlCommon.RoleConstants;

    public class TrainerController : BaseAdminController
    {
        private readonly ITrainerService trainerService;
        private readonly ITrainerUserService trainerUserService;
        private readonly UserManager<ApplicationUser> userManager;

        public TrainerController(ITrainerService trainerService, UserManager<ApplicationUser> userManager, ITrainerUserService trainerUserService)
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
                    this.ModelState.AddModelError(string.Empty, "Something went wrong, try again!");
                    return this.View(trainerBioToAddVM);
                }

                bool isAddedSuccessfully = await this.trainerService.AddTrainerBioAsync(trainerBioToAddVM);
               
                if (!isAddedSuccessfully)
                {
                    TempData[ErrorMessageKey] = "Trainer Bio could not be created. Please try again.";
                    return View(trainerBioToAddVM);
                }
                TempData[SuccessMessageKey] = "Trainer Bio added successfully!";

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
                TempData[ErrorMessageKey] = $"Unexpected error occurred while adding the Trainer Bio! Please contact developer team! The error is {e.Message}";

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditTrainerBio()
        {
            ApplicationUser? user = await userManager.GetUserAsync(User);
            IList<string> roles = await userManager.GetRolesAsync(user!);

            if (roles.Contains(SCV.GlCommon.RoleConstants.Trainer))
            {
                // Trainer sees only their own bio
                TrainerBioEditViewModel? trainerEditVM = await trainerService
                                                .GetTrainerBioByIdAsync(user!.Id.ToString());
                if (trainerEditVM == null)
                {
                    return NotFound();
                }

                return View("EditTrainerBioUser", trainerEditVM);
            }

            if (roles.Contains(Manager) || roles.Contains(Admin))
            {
                // Admins and Managers see the dropdown list
                IEnumerable<TrainerAdminDetailViewModel> allTrainers = await trainerService.GetAllTrainersForAdminAsync();

                return View("EditTrainerBioAdminManager", allTrainers);
            }

            return Forbid();
        }

        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> GetTrainer(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest();
            }

            ApplicationUser? user = await userManager.GetUserAsync(User);
            IList<string> roles = await userManager.GetRolesAsync(user!);

            if (!roles.Contains(Admin) && !roles.Contains(Manager))
            {
                return Forbid();
            }

            TrainerBioEditViewModel? trainerVM = await trainerService
                                                        .GetTrainerBioByIdAsync(id);

            if (trainerVM == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Trainer could not be found or is not a trainer. Please try again."
                });
            }

            return Json(new
            {
                success = true,
                data = trainerVM
            });
        }

        [HttpPost]
        public async Task<IActionResult> EditTrainerBio(TrainerBioEditViewModel trainerBioEditVM)
        {
            ApplicationUser? user = await userManager.GetUserAsync(User);

            if (!ModelState.IsValid)
            {
                return View("EditTrainerBioUser", trainerBioEditVM);
            }

            bool isEdited = await trainerService
                                    .EditTrainerBioAsync(trainerBioEditVM, user!.Id.ToString());

            if (!isEdited)
            {
                TempData["Error"] = "You are not authorized to edit this Trainer Bio.";
                return View("EditTrainerBioUser", trainerBioEditVM);
            }

            TempData["Success"] = "Trainer Bio updated successfully.";

            return RedirectToAction("EditTrainerBio");
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
                TempData[ErrorMessageKey] = $"Unexpected error occurred while deleting the Trainer Bio! Please contact developer team! The error is {e.Message}";
                return RedirectToAction("Index", "Home");
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
                    TempData[ErrorMessageKey] = "Trainer Bio could not be found and deleted!";
                }
                else
                {
                    string operation = opResult.isRestored ? "Deleted" : "Restored";

                    TempData[SuccessMessageKey] = $"Trainer is {operation} successfully!";
                }

                return this.RedirectToAction(nameof(DeleteTrainerBio));
            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while deleting the Trainer! Please contact developer team! The error is {e.Message}";

                return RedirectToAction("Index", "Home");
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
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index), "Home");
            }
        }
    }
}
