namespace SportCenterVictory.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.Administration.CrossfitClassesVM;

    using static SCV.GlCommon.ApplicationConstants;
    using static SCV.GlCommon.RoleConstants;

    public class CrossfitController : BaseAdminController
    {
        private readonly ICrossfitClassService crossfitClassService;

        public CrossfitController(ICrossfitClassService crossfitClassService)
        {
            this.crossfitClassService = crossfitClassService;
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
                    this.ModelState.AddModelError(string.Empty, "Something went wrong, try again!");

                    return this.View(crossfitClassAddVM);
                }

                bool isAddedSuccessfully = await this.crossfitClassService
                    .AddCrossfitClassAsync(crossfitClassAddVM);

                if (!isAddedSuccessfully)
                {
                    TempData[ErrorMessageKey] = "CrossFit Class could not be created. Please try again.";

                    return View(crossfitClassAddVM);
                }


                TempData[SuccessMessageKey] = "CrossFit Classes added successfully!";
                return RedirectToAction("CrossfitClasses", "Crossfit", new { area = "" });


            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while adding the CrossFit Class! Please contact developer team! The error is {e.Message}";
                return RedirectToAction("Index", "Home");
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
                TempData[ErrorMessageKey] = $"Unexpected error occurred while editing the CrossFit Class! Please contact developer team! The error is {e.Message}";
                return RedirectToAction("Index", "Home");
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
                    return NotFound();
                }

                return Json(new
                {
                    id = crossfitClassEditVM.Id,
                    name = crossfitClassEditVM.Name,
                    trainerName = crossfitClassEditVM.TrainerName,
                    startTime = crossfitClassEditVM.StartTime,
                    dayOfWeek = (int)crossfitClassEditVM.DayOfWeek,
                    description = crossfitClassEditVM.Description
                });
            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while editing the CrossFit class! Please contact developer team! The error is {e.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditClass(CrossfitClassEditViewModel crossfitClassEditVM)
        {
            if (!ModelState.IsValid)
            {
                return View(crossfitClassEditVM);
            }

            await crossfitClassService.EditCrossfitClassAsync(crossfitClassEditVM);

            TempData["Success"] = $"CrossFit Class {crossfitClassEditVM.Name} updated successfully!";

            return RedirectToAction("CrossfitClasses", "Crossfit", new { area = "" });

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
                TempData[ErrorMessageKey] = $"Unexpected error occurred while deleting the CrossFit class! Please contact developer team! The error is {e.Message}";
                return RedirectToAction("Index", "Home");
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
                    TempData[ErrorMessageKey] = "CrossFit Class could not be found and deleted!";
                }
                else
                {
                    string operation = opResult.isRestored ? "Active" : "Inactive";

                    TempData[SuccessMessageKey] = $"CrossFit Class {operation} successfully!";
                }

                return this.RedirectToAction(nameof(DeleteClass));
            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while deleting the CrossFit class! Please contact developer team! The error is {e.Message}";

                return RedirectToAction("Index", "Home");
            }
        }
    }
}
