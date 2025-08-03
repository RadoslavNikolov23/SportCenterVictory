namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using SCV.Data.Models;
    using SCV.GlCommon;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.CommonVM;
    using SCV.Web.ViewModels.StoreVM;
    using SVC.Web.ViewModels.StoreVM;

    public class StoreController : BaseController
    {
        private readonly IProductService productService;
        private readonly IMembershipService membershipService;
        private readonly IMembershipUserService membershipUserService;
        private readonly IOrderService orderService;
        private readonly IOrderProductService orderProductService;
        private readonly UserManager<ApplicationUser> userManager;


        public StoreController(IProductService productService, IMembershipService membershipService, IMembershipUserService membershipUserService, IOrderService orderService, IOrderProductService orderProductService, UserManager<ApplicationUser> userManager)
        {
            this.productService = productService;
            this.membershipService = membershipService;
            this.membershipUserService = membershipUserService;
            this.orderService = orderService;
            this.orderProductService = orderProductService;
            this.userManager = userManager;
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

                    membershipDetailVM.CanBeRemoved = await this.membershipUserService
                                .CanUserRemovedIt(membershipDetailVM.Id, this.GetUserId());


                    membershipDetailVM.IsExpired = await this.membershipUserService
                                .IsExpired(membershipDetailVM.Id, this.GetUserId());
                }
            }

            if (allMembershipsViewModels == null || !allMembershipsViewModels.Any())
            {
                return NotFoundWithMessage(string.Format(ErrorMessages.StoreItemsNotFound, "memberships"));

            }

            return View(allMembershipsViewModels);

        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(Guid productId, int quantity)
        {
            string? userId = this.userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
            {
                this.AccessForbidden("Access is forbidden. Log in or Register first.");
            }

            Order order = await this.orderService
                                .GetOrCreateDraftOrderAsync(userId!);

            await this.orderProductService
                        .AddProductToOrderAsync(order.Id.ToString(), productId.ToString(), quantity);

            return RedirectToAction("Cart");
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            string? userId = this.userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
            {
                this.AccessForbidden("Access is forbidden. Log in or Register first.");
            }

            OrderDetailViewModel? currentCart = await orderService
                                        .GetUserCartAsync(userId!);
            return View(currentCart);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(Guid productId)
        {
            string? userId = this.userManager.GetUserId(User);
            if (string.IsNullOrEmpty(userId))
            {
                this.AccessForbidden("Access is forbidden. Log in or Register first.");
            }

            Order? order = await this.orderService.GetOrCreateDraftOrderAsync(userId!);

            if (order == null)
            {
                return NotFoundWithMessage("Order not found.");
            }

            await this.orderProductService.RemoveProductFromOrderAsync(order.Id, productId);

            return RedirectToAction(nameof(Cart));
        }

        [HttpPost]
        public async Task<IActionResult> FinishOrder(OrderDetailViewModel currentCart)
        {
            string? userId = this.userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
            {
                return this.AccessForbidden("Please log in to complete your order.");
            }



            if (!ModelState.IsValid)
            {
                return View(nameof(Cart));
            }

            bool isSuccessful = await this.orderService.FinishOrderAsync(userId, currentCart.PaymentMethod);

            if (!isSuccessful)
            {
                return this.ServerError("Something went wrong. Please try again.");
            }

            TempData["Success"] = "Your order was placed successfully!";

            return RedirectToAction("MadeOrders", "UserPane");

        }

        [HttpGet]
        public async Task<IActionResult> Search(string? searchTerm)
        {
            ProductSearchViewModel productSearchVM = new ProductSearchViewModel
            {
                SearchTerm = searchTerm ?? string.Empty,
                Results = new HashSet<ProductResultViewModel>()
            };

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                productSearchVM.Results = await this.productService
                                    .ReturnProductSearchResult(searchTerm);
            }

            return View(productSearchVM);
        }

        [HttpGet]
        public async Task<IActionResult> ProductsByCategory(ProductCategory productCategory)
        {
            IEnumerable<StoreProductViewModel> productsByCategory = await this.productService
                                                .GetAllProductsByProductCategoryAsync(productCategory);
            if (productsByCategory == null || !productsByCategory.Any())
            {
                return NotFoundWithMessage(string.Format(ErrorMessages.StoreItemsNotFound, productCategory.ToString().ToLower() + " products"));
            }

            switch (productCategory)
            {
                case ProductCategory.Equipment:
                    return RedirectToAction("Equipment", "Store", new { area = "" });
                case ProductCategory.Nutrition:
                    return RedirectToAction("Nutrition", "Store", new { area = "" });
                default:
                    return RedirectToAction("Index", "Store", new { area = "" });
            }
        }
    }
}
