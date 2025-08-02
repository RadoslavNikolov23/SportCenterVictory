namespace SCV.Web.ViewModels.StoreVM
{
    public class OrderProductDetailViewModel
    {
        public string ProductId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;

        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
