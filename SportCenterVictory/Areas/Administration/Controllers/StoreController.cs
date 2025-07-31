namespace SportCenterVictory.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using SCV.GlCommon.Enums;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.Administration.StoreVM.MembershipsVM;
    using SCV.Web.ViewModels.Administration.StoreVM.ProductsVM;

    using static SCV.GlCommon.ApplicationConstants;
    using static SCV.GlCommon.RoleConstants;

    public partial class StoreController : BaseAdminController
    {
        private readonly IMembershipService memershipServices;
        private readonly IProductService productService;

        public StoreController(IMembershipService memershipServices, IProductService productService)
        {
            this.memershipServices = memershipServices;
            this.productService = productService;

        }

        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public IActionResult AddMembership()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> AddMembership(MembershipAddViewModel membershipAddVM)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    this.ModelState.AddModelError(string.Empty, "Something went wrong, try again!");

                    return this.View(membershipAddVM);
                }

                bool isAddedSuccessfully = await this.memershipServices
                                                        .AddMembershipAsync(membershipAddVM);

                if (!isAddedSuccessfully)
                {
                    TempData[ErrorMessageKey] = "Membership could not be created. Please try again.";

                    return View(membershipAddVM);
                }


                TempData[SuccessMessageKey] = "Membership added successfully!";


                switch (membershipAddVM.MembershipType)
                {
                    case SportType.Fitness:
                        return RedirectToAction("FitnessMembership", "Fitness", new { area = "" });
                    case SportType.CrossFit:
                        return RedirectToAction("CrossfitMembership", "Crossfit", new { area = "" });
                    case SportType.Powerlifting:
                        return RedirectToAction("PowerliftingMembership", "Powerlifting", new { area = "" });
                    default:
                        return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while adding the Membership! Please contact developer team! The error is {e.Message}";
                return RedirectToAction("Index", "Home");
            }
        }


        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> EditMembership()
        {

            try
            {
                IEnumerable<MembershipAdminDetailViewModel> membershipAdminDetailVM = await this.memershipServices.GetAllMembershipsForAdminAsync();

                return this.View(membershipAdminDetailVM);
            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while editing the Membership! Please contact developer team! The error is {e.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> GetMembership(string? id)
        {
            try
            {
                MembershipEditViewModel? membershipEditVM = await this.memershipServices
                                                        .GetMembershipByIdAsync(id);

                if (membershipEditVM == null)
                {
                    return Json(new
                    {
                        success = false,
                        message = "Event could not be found. Please try again."
                    });
                }

                return Json(new
                {
                    success = true,
                    data = new
                    {
                        id = membershipEditVM.Id,
                        name = membershipEditVM.Name,
                        membershipType = (int)membershipEditVM.MembershipType,
                        description = membershipEditVM.Description,
                        price = membershipEditVM.Price,
                        duration = membershipEditVM.Duration,
                    }
                });
            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while editing the Membership! Please contact developer team! The error is {e.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditMembership(MembershipEditViewModel membershipEditVM)
        {
            if (!ModelState.IsValid)
            {
                return View(membershipEditVM);
            }

            await memershipServices.EditMembershipAsync(membershipEditVM);

            TempData["Success"] = $"Membership {membershipEditVM.Name} updated successfully!";

            switch (membershipEditVM.MembershipType)
            {
                case SportType.Fitness:
                    return RedirectToAction("FitnessMembership", "Fitness", new { area = "" });
                case SportType.CrossFit:
                    return RedirectToAction("CrossfitMembership", "Crossfit", new { area = "" });
                case SportType.Powerlifting:
                    return RedirectToAction("PowerliftingMembership", "Powerlifting", new { area = "" });
                default:
                    return RedirectToAction("Memberships", "Store", new { area = "" });
            }

        }

        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> DeleteMembership()
        {
            try
            {
                IEnumerable<MembershipDeleteViewModel> membershipDeleteDetailVM = await this.memershipServices.GetAllMembershipForDeletingAsync();

                return this.View(membershipDeleteDetailVM);
            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while deleting the Membership! Please contact developer team! The error is {e.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> ToggleDeleteMembership(string? id)
        {
            try
            {
                (bool isSuccess, bool isRestored) opResult = await this.memershipServices
                                        .DeleteOrRestoreMembershipAsync(id);

                if (!opResult.isSuccess)
                {
                    TempData[ErrorMessageKey] = "Membership could not be found and deleted!";
                }
                else
                {
                    string operation = opResult.isRestored ? "Deleted" : "Restored";

                    TempData[SuccessMessageKey] = $"Membership is {operation} successfully!";
                }

                return this.RedirectToAction(nameof(DeleteMembership));
            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while deleting the Membership! Please contact developer team! The error is {e.Message}";

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> UsersPurchasedMemberships()
        {
            return View();
        }


        //Product actions are in the partial class StoreController.Products.cs file ->
    }
}
