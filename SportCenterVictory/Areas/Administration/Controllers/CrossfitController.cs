namespace SportCenterVictory.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SCV.Services.Core.CrossfitServices.Contracts;
    using SCV.Web.ViewModels.Administration.CrossfitClassesVM;
    using SCV.Web.ViewModels.Administration.ReferenceVM;

    using static SCV.GlCommon.ApplicationConstants;
    using static SCV.GlCommon.RoleConstants;
    using static SCV.GlCommon.ErrorMessages;
    using static SCV.GlCommon.ExceptionMessages;
    using static SCV.GlCommon.ToastMessages;

    public class CrossfitController : BaseAdminController<CrossfitController>
    {
        private readonly ICrossfitClassService crossfitClassService;
        private readonly ICrossfitClassUserService crossfitClassUserService;

        public CrossfitController(ICrossfitClassService crossfitClassService, ICrossfitClassUserService crossfitClassUserService, ILogger<CrossfitController> logger) : base(logger)
        {
            this.crossfitClassService = crossfitClassService;
            this.crossfitClassUserService = crossfitClassUserService;
        }

        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public IActionResult AddClass()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> AddClass(CrossfitClassAddViewModel crossfitClassAddVM)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    this.ModelState.AddModelError(string.Empty, SomethingWentWrong);
                    return this.View(crossfitClassAddVM);
                }

                bool isAddedSuccessfully = await this.crossfitClassService
                    .AddCrossfitClassAsync(crossfitClassAddVM);

                if (!isAddedSuccessfully)
                {
                    this.logger.LogWarning($"Error occurred while creating a Crossfit Class");
                    TempData[WarningMessageKey] = ErrorMessageCrossfitClassCannotCreate;
                    return View(crossfitClassAddVM);
                }

                TempData[SuccessMessageKey] = SuccessMessageCrossfitClassCreated;
                return RedirectToAction("CrossfitClasses", "Crossfit", new { area = "" });


            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while adding Crossfit Class. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditClass()
        {
            try
            {
                IEnumerable<CrossfitClassAdminDetailViewModel> crossfitClassesAdminDetailVM = await this.crossfitClassService
                                         .GetAllCrossfitClassesForAdminAsync();

                return this.View(crossfitClassesAdminDetailVM);
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while edditing Crossfit Class. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetClass(string? id)
        {
            try
            {
                CrossfitClassEditViewModel? crossfitClassEditVM = await this.crossfitClassService
                                 .GetCrossfitClassByIdAsync(id);

                if (crossfitClassEditVM == null)
                {
                    return Json(new
                    {
                        success = false,
                        message = ErrorMessageCrossfitClassCannotFind
                    });
                }

                return Json(new
                {
                    success = true,
                    data = new
                    {
                        id = crossfitClassEditVM.Id,
                        name = crossfitClassEditVM.Name,
                        trainerName = crossfitClassEditVM.TrainerName,
                        startTime = crossfitClassEditVM.StartTime,
                        dayOfWeek = (int)crossfitClassEditVM.DayOfWeek,
                        description = crossfitClassEditVM.Description
                    }
                });
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error occurred while editing Crossfit Class with ID: {id}. Error: {ex.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditClass(CrossfitClassEditViewModel crossfitClassEditVM)
        {
            try
            {
                if (crossfitClassEditVM.Id == null)
                {
                    TempData[WarningMessageKey] = SomethingWentWrong;

                    return RedirectToAction(nameof(EditClass));
                }

                if (!ModelState.IsValid)
                {
                    return View(crossfitClassEditVM);
                }

                bool isEditSuccessfully = await crossfitClassService.EditCrossfitClassAsync(crossfitClassEditVM);


                if (!isEditSuccessfully)
                {
                    this.logger.LogWarning($"Error occurred while editing a CrossFit Class with {crossfitClassEditVM.Id}!");
                    TempData[WarningMessageKey] = string.Format(ErrorMessageCannotUpdateCrossfitClass, crossfitClassEditVM.Name); ;
                    return View(crossfitClassEditVM);
                }


                TempData[SuccessMessageKey] = string.Format(SuccessMessageUpdateCrossfitClass, crossfitClassEditVM.Name);

                return RedirectToAction("CrossFitClasses", "CrossFit", new { area = "" });
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while edditing Crossfit Class with ID: {crossfitClassEditVM.Id}. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> DeleteClass()
        {
            try
            {
                IEnumerable<CrossfitClassDeleteVIewModel> crossfitClassesAdminDetailVM = await this.crossfitClassService
                                         .GetAllCrossfitClassesForDeletingAsync();

                return this.View(crossfitClassesAdminDetailVM);
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while Deleting Crossfit Class. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }


        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> ToggleDelete(string? id)
        {
            try
            {
                (bool isSuccess, bool isRestored) opResult = await this.crossfitClassService
                                        .DeleteOrRestoreCrossfitClassAsync(id);

                if (!opResult.isSuccess)
                {
                    this.logger.LogError($"Error occurred in the service methos while trying to Deleting Crossfit Class with ID: {id}");
                    TempData[WarningMessageKey] = ErrorMessageCrossfitClassCannotDelete;
                }
                else
                {
                    string operation = opResult.isRestored ? Active : Inactive;

                    TempData[SuccessMessageKey] = string.Format(SuccessMessageDeleteCrossfitClass, operation);
                }

                return this.RedirectToAction(nameof(DeleteClass));
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error occurred while Deleting Crossfit Class. Error: {ex.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> UsersJoinedCrossfitClass()
        {
            try
            {
                IEnumerable<UserCrossfitClassesForAdminListViewModel> crossfitClassesUsersList = await this.crossfitClassUserService
                    .ForAdminCrossfitClassClientsListAsync();

                return View(crossfitClassesUsersList);
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while loading all the Crossfit Class with their users. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }
    }
}
