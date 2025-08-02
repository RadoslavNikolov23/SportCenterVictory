namespace SCV.Services.Core.Contracts
{
    using SCV.GlCommon.Enums;
    using SCV.Web.ViewModels.Administration.StoreVM.ProductsVM;
    using SVC.Web.ViewModels.StoreVM;

    public interface IProductService
    {
        Task<IEnumerable<StoreProductViewModel>> GetAllProductsByProductCategoryAsync(ProductCategory productCategory);

        Task<IEnumerable<ProductAdminDetailViewModel>> GetAllProductsForAdminAsync();

        Task<bool> AddProductAsync(ProductAddViewModel productAddVM);

        Task<ProductEditViewModel?> GetProductByIdAsync(string? id);

        Task<bool> EditProductAsync(ProductEditViewModel productEditVM);

        Task<IEnumerable<ProductDeleteViewModel>> GetAllProductsForDeletingAsync();

        Task<(bool, bool)> DeleteOrRestoreProductAsync(string? id);

    }
}
