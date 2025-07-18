namespace SVC.Web.ViewModels.StoreVM
{
    using SCV.GlCommon.Enums;

    public class StoreProductViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public ProductCategory ProductCategory { get; set; }

        public int Quantity { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }


        //public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
