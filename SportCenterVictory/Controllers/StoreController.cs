namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.CommonVM;
    using SVC.Web.ViewModels.StoreVM;

    public class StoreController : Controller
    {
        private readonly IProductService productService;
        private readonly IMembershipService membershipService;


        public StoreController(IProductService productService, IMembershipService membershipService)
        {
            this.productService = productService;
            this.membershipService = membershipService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //TODO make a View
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Equipment()
        {
            //TODO make a View
            IEnumerable<StoreProductViewModel> productEquipmentViewModels = await this.productService
                                                .GetAllProductsByProductCategoryAsync(ProductCategory.Equipment);

            return View(productEquipmentViewModels);

        }

        [HttpGet]
        public async Task<IActionResult> Nutrition()
        {
            //TODO make a View
            IEnumerable<StoreProductViewModel> productNutritionViewModels = await this.productService
                                                .GetAllProductsByProductCategoryAsync(ProductCategory.Nutrition);

            return View(productNutritionViewModels);

        }

        [HttpGet]
        public async Task<IActionResult> Memberships()
        {
            //TODO make a View
            IEnumerable<MembershipDetailViewModel> allMembershipsViewModels = await this.membershipService
                                                        .GetAllMembershipAsync();

            return View(allMembershipsViewModels);

        }
    }
}
