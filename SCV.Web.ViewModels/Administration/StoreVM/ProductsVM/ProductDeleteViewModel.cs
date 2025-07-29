namespace SCV.Web.ViewModels.Administration.StoreVM.ProductsVM
{
    using SCV.GlCommon.Enums;

    public class ProductDeleteViewModel : BaseProductViewModel
    {
        public ProductCategory ProductCategory { get; set; }

        public bool IsDeleted { get; set; }

    }
}
