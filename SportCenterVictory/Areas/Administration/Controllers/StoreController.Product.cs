namespace SportCenterVictory.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using SCV.GlCommon.Enums;
    using SCV.Services.Core;
    using SCV.Web.ViewModels.Administration.StoreVM.ProductsVM;
    using SCV.Web.ViewModels.StoreVM;
    using static SCV.GlCommon.ApplicationConstants;
    using static SCV.GlCommon.RoleConstants;

    public partial class StoreController
    {
        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public IActionResult AddProduct()
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
            try
            {
                IEnumerable<ProductAdminDetailViewModel> productAdminDetailVM = await this.productService.GetAllProductsForAdminAsync();

                return this.View(productAdminDetailVM);
            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while editing the Product! Please contact developer team! The error is {e.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> GetProduct(string? id)
        {
            try
            {
                ProductEditViewModel? productEditVM = await this.productService
                                                        .GetProductByIdAsync(id);

                if (productEditVM == null)
                {
                    return Json(new
                    {
                        success = false,
                        message = "Product could not be found. Please try again."
                    });
                }

                return Json(new
                {
                    success = true,
                    data = new
                    {
                        id = productEditVM.Id,
                        title = productEditVM.Title,
                        productCategory = (int)productEditVM.ProductCategory,
                        quantity = productEditVM.Quantity,
                        description = productEditVM.Description,
                        price = productEditVM.Price,
                        imageUrl = productEditVM.ImageUrl,
                    }
                });
            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while editing the Product! Please contact developer team! The error is {e.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductEditViewModel productEditVM)
        {
            if (!ModelState.IsValid)
            {
                TempData[ErrorMessageKey] = $"Something went wrong please try again or contact the administration!";
                IEnumerable<ProductAdminDetailViewModel> productAdminDetailVM = await this.productService.GetAllProductsForAdminAsync();

                return this.View(productAdminDetailVM);
            }

            await productService.EditProductAsync(productEditVM);

            TempData["Success"] = $"Product {productEditVM.Title} updated successfully!";

            switch (productEditVM.ProductCategory)
            {
                case ProductCategory.Equipment:
                    return RedirectToAction("Equipment", "Store", new { area = "" });
                case ProductCategory.Nutrition:
                    return RedirectToAction("Nutrition", "Store", new { area = "" });
                default:
                    return RedirectToAction("Index", "Store", new { area = "" });
            }

        }


        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> DeleteProduct()
        {
            try
            {
                IEnumerable<ProductDeleteViewModel> productDeleteDetailVM = await this.productService.GetAllProductsForDeletingAsync();

                return this.View(productDeleteDetailVM);
            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while deleting the Product! Please contact developer team! The error is {e.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> ToggleDeleteProduct(string? id)
        {
            try
            {
                (bool isSuccess, bool isRestored) opResult = await this.productService
                                        .DeleteOrRestoreProductAsync(id);

                if (!opResult.isSuccess)
                {
                    TempData[ErrorMessageKey] = "Product could not be found and deleted!";
                }
                else
                {
                    string operation = opResult.isRestored ? "Deleted" : "Restored";

                    TempData[SuccessMessageKey] = $"Product is {operation} successfully!";
                }

                return this.RedirectToAction(nameof(DeleteProduct));
            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while deleting the Product! Please contact developer team! The error is {e.Message}";

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> ApproveOrder()
        {
            IEnumerable<OrderApproveAdminViewModel> userOrders = await this.orderService
                            .GetUsersOrdersForProcessingAsync();

            return View(userOrders);
        }

        [HttpPost]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> ApproveOrder(string orderId, OrderStatus newStatus)
        {
            try
            {
                bool isSuccess = await orderService
                    .UpdateOrderStatusAsync(orderId, newStatus);

                if (!isSuccess)
                {
                    TempData[ErrorMessageKey] = "Order could not be updated. Please try again.";
                    return RedirectToAction(nameof(ApproveOrder));
                }

                TempData[SuccessMessageKey] = "Order status updated successfully!";
                return RedirectToAction(nameof(ApproveOrder));
            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while approving the Order! Please contact developer team! The error is {e.Message}";

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> AllOrders()
        {
            try
            {
                IEnumerable<OrderAdminDetailViewModel> allOrders = await this.orderService
                    .GetAllOrdersForAdminAsync();
                return View(allOrders);
            }
            catch (Exception e)
            {
                TempData[ErrorMessageKey] = $"Unexpected error occurred while retrieving all orders! Please contact developer team! The error is {e.Message}";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
