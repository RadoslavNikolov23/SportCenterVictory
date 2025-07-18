namespace SCV.Services.Core.Contracts
{
    using SCV.GlCommon.Enums;
    using SVC.Web.ViewModels.StoreVM;

    public interface IProductService
    {
        Task<IEnumerable<StoreProductViewModel>> GetAllProductsByProductCategoryAsync(ProductCategory productCategory);

    }
}
