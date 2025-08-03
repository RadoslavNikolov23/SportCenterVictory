namespace SVC.Web.ViewModels.StoreVM
{
    using SCV.GlCommon.Enums;

    public class StoreProductViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public ProductCategory ProductCategory { get; set; }

        public int Quantity { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

    }
}
