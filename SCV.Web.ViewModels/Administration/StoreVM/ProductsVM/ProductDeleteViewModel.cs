namespace SCV.Web.ViewModels.Administration.StoreVM.ProductsVM
{
    using SCV.GlCommon.Enums;

    public class ProductDeleteViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public ProductCategory ProductCategory { get; set; }

        public bool IsDeleted { get; set; }

    }
}
