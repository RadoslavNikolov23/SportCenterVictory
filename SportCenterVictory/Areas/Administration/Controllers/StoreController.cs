namespace SportCenterVictory.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using SCV.GlCommon.Enums;
    using SCV.Services.Core.StoreServices.Contracts;
    using SCV.Web.ViewModels.Administration.ReferenceVM;
    using SCV.Web.ViewModels.Administration.StoreVM.MembershipsVM;

    using static SCV.GlCommon.ApplicationConstants;
    using static SCV.GlCommon.RoleConstants;
    using static SCV.GlCommon.ErrorMessages;
    using static SCV.GlCommon.ExceptionMessages;
    using static SCV.GlCommon.ToastMessages;

    public partial class StoreController : BaseAdminController<StoreController>
    {
        private readonly IMembershipService membershipServices;
        private readonly IMembershipUserService membershipUserServices;
        private readonly IProductService productService;
        private readonly IOrderService orderService;

        public StoreController(IMembershipService memershipServices, IMembershipUserService membershipUserServices, IProductService productService, IOrderService orderService, ILogger<StoreController> logger) : base(logger)
        {
            this.membershipServices = memershipServices;
            this.membershipUserServices = membershipUserServices;
            this.productService = productService;
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
                    this.ModelState.AddModelError(string.Empty, SomethingWentWrong);

                    return this.View(membershipAddVM);
                }

                bool isAddedSuccessfully = await this.membershipServices
                                                        .AddMembershipAsync(membershipAddVM);

                if (!isAddedSuccessfully)
                {
                    this.logger.LogWarning($"Error occurred in the service methods while trying to create a Membership.");
                    TempData[ErrorMessageKey] = ErrorMessageCannotCreateMembership;
                    return View(membershipAddVM);
                }

                TempData[SuccessMessageKey] = ErrorMessageMembershipAdded;

                switch (membershipAddVM.MembershipType)
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
            catch (Exception ex)
            {
                this.logger.LogError($"Error occurred while adding a Membership. Error: {ex.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
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
            catch (Exception ex)
            {
                this.logger.LogError($"Error occurred while editing a Membership. Error: {ex.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
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
                        message = ErrorMessageCannotFindMembership
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
                this.logger.LogError($"Error occurred while editing a Membership with {id}. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditMembership(MembershipEditViewModel membershipEditVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(membershipEditVM);
                }

                await membershipServices.EditMembershipAsync(membershipEditVM);

                TempData[SuccessMessageKey] = string.Format(SuccessMessageUpdateMembership, membershipEditVM.Name);

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
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while editing a Membership with {membershipEditVM.Id}. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
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
                this.logger.LogError($"Error occurred while deleting a Membership. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
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
                    this.logger.LogWarning($"Error occurred in the service methods while trying to delete a Membership.");
                    TempData[ErrorMessageKey] = ErrorMessageCannotFindMembership;
                }
                else
                {
                    string operation = opResult.isRestored ? Deleted : Restored;

                    TempData[SuccessMessageKey] = string.Format(SuccessMessageDeleteMembership, operation);
                }

                return this.RedirectToAction(nameof(DeleteMembership));
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while deleting a Membership with {id}. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
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
                this.logger.LogError($"Error occurred while trying to load all the Memberships and the Users that have purchased them. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
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
