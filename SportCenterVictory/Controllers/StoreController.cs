namespace SportCenterVictory.Controllers
{
    using SCV.GlCommon;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.CommonVM;
    using SVC.Web.ViewModels.StoreVM;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class StoreController : BaseController
    {
        private readonly IProductService productService;
        private readonly IMembershipService membershipService;
        private readonly IMembershipUserService membershipUserService;


        public StoreController(IProductService productService, IMembershipService membershipService, IMembershipUserService membershipUserService)
        {
            this.productService = productService;
            this.membershipService = membershipService;
            this.membershipUserService = membershipUserService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Equipment()
        {
            IEnumerable<StoreProductViewModel> productEquipmentViewModels = await this.productService
                                                .GetAllProductsByProductCategoryAsync(ProductCategory.Equipment);

            if (productEquipmentViewModels == null || !productEquipmentViewModels.Any())
            {
                return NotFoundWithMessage(string.Format(ErrorMessages.StoreItemsNotFound, "equipment products"));
            }

            return View(productEquipmentViewModels);

        }

        [HttpGet]
        public async Task<IActionResult> Nutrition()
        {
            IEnumerable<StoreProductViewModel> productNutritionViewModels = await this.productService
                                                .GetAllProductsByProductCategoryAsync(ProductCategory.Nutrition);

            if (productNutritionViewModels == null || !productNutritionViewModels.Any())
            {
                return NotFoundWithMessage(string.Format(ErrorMessages.StoreItemsNotFound, "nutrition products"));

            }

            return View(productNutritionViewModels);

        }

        [HttpGet]
        public async Task<IActionResult> Memberships()
        {
            IEnumerable<MembershipDetailViewModel> allMembershipsViewModels = await this.membershipService
                                                        .GetAllMembershipAsync();

            if (this.IsUserAuthenticated())
            {
                foreach (MembershipDetailViewModel membershipDetailVM in allMembershipsViewModels)
                {
                    membershipDetailVM.IsPurchasedMembership = await this.membershipUserService
                        .IsUserAddedToMembershipList(membershipDetailVM.Id, this.GetUserId());
                }
            }

            if (allMembershipsViewModels == null || !allMembershipsViewModels.Any())
            {
                return NotFoundWithMessage(string.Format(ErrorMessages.StoreItemsNotFound, "memberships"));

            }

            return View(allMembershipsViewModels);

        }
    }
}
