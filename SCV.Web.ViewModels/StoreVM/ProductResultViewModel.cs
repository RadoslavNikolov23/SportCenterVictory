namespace SCV.Web.ViewModels.StoreVM
{
    using SCV.GlCommon.Enums;

    public class ProductResultViewModel
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
}
