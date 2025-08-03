namespace SportCenterVictory.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using SCV.GlCommon.Enums;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.Administration.ReferenceVM;
    using SCV.Web.ViewModels.Administration.StoreVM.MembershipsVM;

    using static SCV.GlCommon.ApplicationConstants;
    using static SCV.GlCommon.RoleConstants;

    public partial class StoreController : BaseAdminController
    {
        private readonly IMembershipService membershipServices;
        private readonly IMembershipUserService membershipUserServices;
        private readonly IProductService productService;
        private readonly IOrderService orderService;

        public StoreController(IMembershipService memershipServices, IMembershipUserService membershipUserServices, IProductService productService, IOrderService orderService)
        {
            this.membershipServices = memershipServices;
            this.productService = productService;
            this.membershipUserServices = membershipUserServices;
            this.orderService = orderService;
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

                bool isAddedSuccessfully = await this.membershipServices
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
                        return RedirectToAction("FitnessMembership", "Fitness");
                    case SportType.CrossFit:
                        return RedirectToAction("CrossfitMembership", "Crossfit");
                    case SportType.Powerlifting:
                        return RedirectToAction("PowerliftingMembership", "Powerlifting");
                    default:
                        return RedirectToAction("Index", "Home");
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
                IEnumerable<MembershipAdminDetailViewModel> membershipAdminDetailVM = await this.membershipServices.GetAllMembershipsForAdminAsync();

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
                MembershipEditViewModel? membershipEditVM = await this.membershipServices
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

            await membershipServices.EditMembershipAsync(membershipEditVM);

            TempData["Success"] = $"Membership {membershipEditVM.Name} updated successfully!";

            switch (membershipEditVM.MembershipType)
            {
                case SportType.Fitness:
                    return RedirectToAction("FitnessMembership", "Fitness");
                case SportType.CrossFit:
                    return RedirectToAction("CrossfitMembership", "Crossfit");
                case SportType.Powerlifting:
                    return RedirectToAction("PowerliftingMembership", "Powerlifting");
                default:
                    return RedirectToAction("Memberships", "Store");
            }

        }

        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> DeleteMembership()
        {
            try
            {
                IEnumerable<MembershipDeleteViewModel> membershipDeleteDetailVM = await this.membershipServices.GetAllMembershipForDeletingAsync();

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
                (bool isSuccess, bool isRestored) opResult = await this.membershipServices
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
            try
            {

                IEnumerable<UserMembershipForAdminListViewModel> memebrshipUsersList = await this.membershipUserServices
                    .ForAdminMembershipClientsListAsync();

                return View(memebrshipUsersList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index), "Home");
            }
        }


        /*
                ================================================
                == Product actions are in the partial class   ==
                == StoreController.Products.cs file --->      ==
                ================================================
        */
    }
}
