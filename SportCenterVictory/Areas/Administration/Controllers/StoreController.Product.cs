namespace SportCenterVictory.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using SCV.GlCommon.Enums;
    using SCV.Web.ViewModels.Administration.StoreVM.ProductsVM;

    using static SCV.GlCommon.ApplicationConstants;
    using static SCV.GlCommon.RoleConstants;
    using static SCV.GlCommon.ErrorMessages;
    using static SCV.GlCommon.ExceptionMessages;
    using static SCV.GlCommon.ToastMessages;

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
                    this.ModelState.AddModelError(string.Empty, SomethingWentWrong);

                    return this.View(productAddVM);
                }

                bool isAddedSuccessfully = await this.productService
                                                        .AddProductAsync(productAddVM);

                if (!isAddedSuccessfully)
                {
                    this.logger.LogWarning($"Error occurred while trying to create a Product.");
                    TempData[WarningMessageKey] = ErrorMessageCannotCreateProduct;
                    return View(productAddVM);
                }


                TempData[SuccessMessageKey] = SuccessMessageProductCreated;

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
                this.logger.LogError($"Error occurred while adding a Product. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
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
                this.logger.LogError($"Error occurred while editing a Product. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
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
                        message = ErrorMessageCannotFindProduct
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
            catch (Exception ex)
            {
                this.logger.LogError($"Error occurred while adding a Product with ID: {id}. Error: {ex.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductEditViewModel productEditVM)
        {
            try
            {
                if (productEditVM.Id == null)
                {
                    TempData[WarningMessageKey] = SomethingWentWrong;

                    return RedirectToAction(nameof(EditProduct));
                }

                if (!ModelState.IsValid)
                {
                    IEnumerable<ProductAdminDetailViewModel> productAdminDetailVM = await this.productService
                                            .GetAllProductsForAdminAsync();
                    return this.View(productAdminDetailVM);
                }

                bool isEditSuccessfully = await productService.EditProductAsync(productEditVM);


                if (!isEditSuccessfully)
                {
                    this.logger.LogWarning($"Error occurred while editing a Product with Id: {productEditVM.Id} - {productEditVM.ProductCategory}");
                    TempData[WarningMessageKey] = string.Format(ErrorMessageProductCannotUpdate, productEditVM.Title); ;
                    return View(productEditVM);
                }

                TempData[SuccessMessageKey] = string.Format(SuccessMessageProductUpdate, productEditVM.Title);

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
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while adding a Product with ID: {productEditVM.Id}. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }

        [HttpGet]
        [Authorize(Roles = AdminOrManager)]
        public async Task<IActionResult> DeleteProduct()
        {
            try
            {
                IEnumerable<ProductDeleteViewModel> productDeleteDetailVM = await this.productService
                                        .GetAllProductsForDeletingAsync();

                return this.View(productDeleteDetailVM);
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while deleting a Product. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
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
                    TempData[WarningMessageKey] = ErrorMessageCannotFindProduct;
                }
                else
                {
                    string operation = opResult.isRestored ? Deleted : Restored;

                    TempData[SuccessMessageKey] = string.Format(SuccessMessageDeleteProduct, operation);
                }

                return this.RedirectToAction(nameof(DeleteProduct));
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while deleting a Product with ID: {id}. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
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
                    .ApproveOrderStatusAsync(orderId, newStatus);

                if (!isSuccess)
                {
                    this.logger.LogWarning($"Error occurred in the service methods while trying to approve order with ID: {orderId}.");
                    TempData[WarningMessageKey] = ErrorMessageCannotApproveOrder;
                    return RedirectToAction(nameof(ApproveOrder));
                }

                TempData[SuccessMessageKey] = SuccessMessageApproveOrder;
                return RedirectToAction(nameof(ApproveOrder));
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error occurred while approving an Order. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
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
                this.logger.LogError($"Error occurred while retrieving all Orders made by Users. Error: {e.Message}");
                return this.ServerErrorWithMessage(BaseServerErrorMessage);
            }
        }
    }
}
