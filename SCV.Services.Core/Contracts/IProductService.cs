namespace SCV.Services.Core.Contracts
{
    using SCV.GlCommon.Enums;
    using SCV.Web.ViewModels.CommonVM;
    using SVC.Web.ViewModels.Membership;

    public interface IProductService
    {
        Task<IEnumerable<StoreProductViewModel>> GetAllProductsByProductCategoryAsync(ProductCategory productCategory);

    }
}
