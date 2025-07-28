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

    public class StoreController : BaseAdminController
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
        public async Task<IActionResult> AddMembership()
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
            return View();
        }


        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> DeleteMembership()
        {
            return View();
        }


        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> AddProduct()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> AddProduct(ProductAddViewModel productAddVM)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    this.ModelState.AddModelError(string.Empty, "Something went wrong, try again!");

                    return this.View(productAddVM);
                }

                bool isAddedSuccessfully = await this.productService
                                                        .AddProductAsync(productAddVM);

                if (!isAddedSuccessfully)
                {
                    TempData[ErrorMessageKey] = "Product could not be created. Please try again.";

                    return View(productAddVM);
                }


                TempData[SuccessMessageKey] = "Product added successfully!";


                switch (productAddVM.ProductCategory)
                {
                    case ProductCategory.Equipment:
                        return RedirectToAction("Equipment", "Store", new { area = "" });
                    case ProductCategory.Nutrition:
                        return RedirectToAction("Nutrition", "Store", new { area = "" });
                    default:
                        return RedirectToAction("Index", "Store", new { area = "" });
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
        public async Task<IActionResult> EditProduct()
        {
            return View();
        }


        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> DeleteProduct()
        {
            return View();
        }

    }
}
