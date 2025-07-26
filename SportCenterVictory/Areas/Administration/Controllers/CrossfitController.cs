namespace SportCenterVictory.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.Administration.CrossfitClassesVM;

    public class CrossfitController : BaseAdminController
    {
        private readonly ICrossfitClassService crossfitClassService;

        public CrossfitController(ICrossfitClassService crossfitClassService)
        {
            this.crossfitClassService = crossfitClassService;
        }

        [HttpGet]
        public async Task<IActionResult> AddClass()
        {

            return this.View();

        }

        [HttpPost]
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
                    this.ModelState.AddModelError(string.Empty, "Crossfit Class could not be created. Please try again.");
                    return View(crossfitClassAddVM);

                }

                return RedirectToAction("CrossfitClasses", "Crossfit", new { area = "" });


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
