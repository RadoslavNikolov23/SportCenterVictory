namespace SportCenterVictory.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using SCV.Data.Models;
    using SCV.GlCommon;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.StoreServices.Contracts;
    using SCV.Web.ViewModels.CommonVM;
    using SCV.Web.ViewModels.StoreVM;
    using SVC.Web.ViewModels.StoreVM;

    using static SCV.GlCommon.ApplicationConstants;
    using static SCV.GlCommon.ErrorMessages;
    using static SCV.GlCommon.ExceptionMessages;
    using static SCV.GlCommon.ToastMessages;

    public class StoreController : BaseController<StoreController>
    {
        private readonly IProductService productService;
        private readonly IMembershipService membershipService;
        private readonly IMembershipUserService membershipUserService;
        private readonly IOrderService orderService;
        private readonly IOrderProductService orderProductService;
        private readonly UserManager<ApplicationUser> userManager;


        public StoreController(IProductService productService, IMembershipService membershipService, IMembershipUserService membershipUserService, IOrderService orderService, IOrderProductService orderProductService, UserManager<ApplicationUser> userManager, ILogger<StoreController> logger) : base(logger)
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
                this.logger.LogWarning(string.Format(ErrorMessages.StoreItemsNotFound, "equipment products"));
                return this.NotFoundWithMessage(string.Format(ErrorMessages.StoreItemsNotFound, "equipment products"));
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
                this.logger.LogWarning(string.Format(ErrorMessages.StoreItemsNotFound, "nutrition products"));
                return this.NotFoundWithMessage(string.Format(ErrorMessages.StoreItemsNotFound, "nutrition products"));
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
                this.logger.LogWarning(string.Format(ErrorMessages.StoreItemsNotFound, "memberships"));
                return this.NotFoundWithMessage(string.Format(ErrorMessages.StoreItemsNotFound, "memberships"));
            }

            return View(allMembershipsViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(Guid productId, int quantity)
        {
            try
            {
                string? userId = this.userManager.GetUserId(User);

                if (string.IsNullOrEmpty(userId))
                {
                    return this.AccessForbiddenWithMessage(AccessIsForbiddenLogOrRegister);
                }

                Order order = await this.orderService
                                    .GetOrCreateDraftOrderAsync(userId!);

                await this.orderProductService
                            .AddProductToOrderAsync(order.Id.ToString(), productId.ToString(), quantity);

                return RedirectToAction(nameof(Cart));
            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error occurred while adding to Car Products: Error: {ex.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            string? userId = this.userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
            {
                return this.AccessForbiddenWithMessage(AccessIsForbiddenLogOrRegister);
            }

            OrderDetailViewModel? currentCart = await orderService
                                        .GetUserCartAsync(userId!);
            return View(currentCart);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(Guid productId)
        {
            try
            {
                string? userId = this.userManager.GetUserId(User);

                if (string.IsNullOrEmpty(userId))
                {
                    return this.AccessForbiddenWithMessage(AccessIsForbiddenLogOrRegister);
                }

                Order? order = await this.orderService.GetOrCreateDraftOrderAsync(userId!);

                if (order == null)
                {
                    this.logger.LogWarning($"{OrderNotFound} for user with ID: {userId}");
                    return this.NotFoundWithMessage(OrderNotFound);
                }

                await this.orderProductService.RemoveProductFromOrderAsync(order.Id, productId);

                return RedirectToAction(nameof(Cart));
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error occurred while removing from Car Products: Error: {ex.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> FinishOrder(OrderDetailViewModel currentCart)
        {
            try
            {
                string? userId = this.userManager.GetUserId(User);

                if (string.IsNullOrEmpty(userId))
                {
                    return this.AccessForbiddenWithMessage(AccessIsForbiddenLogOrRegister);
                }

                if (!ModelState.IsValid)
                {
                    return View(nameof(Cart));
                }

                bool isSuccessful = await this.orderService
                                .FinishOrderAsync(userId, currentCart.PaymentMethod);

                if (!isSuccessful)
                {
                    this.logger.LogWarning($"Error occurred while Finishing the order from user with Id: {userId}");
                    return this.ServerErrorWithMessage(BaseServerErrorMessage);
                }

                TempData[SuccessMessageKey] = SuccessMessageOrderPlaced;

                return RedirectToAction("MadeOrders", "UserPanel");
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error occurred while adding to Car Products: Error: {ex.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }

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
                this.logger.LogWarning(string.Format(ErrorMessages.StoreItemsNotFound, productCategory.ToString().ToLower() + " products"));
                return NotFoundWithMessage(string.Format(ErrorMessages.StoreItemsNotFound, productCategory.ToString().ToLower() + " products"));
            }

            switch (productCategory)
            {
                case ProductCategory.Equipment:
                    return RedirectToAction(nameof(Equipment), "Store");
                case ProductCategory.Nutrition:
                    return RedirectToAction(nameof(Nutrition), "Store");
                default:
                    return RedirectToAction(nameof(Index), "Store");
            }
        }
    }
}
