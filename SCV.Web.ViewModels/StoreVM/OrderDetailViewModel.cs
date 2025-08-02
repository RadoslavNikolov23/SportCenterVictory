namespace SCV.Web.ViewModels.StoreVM
{
    using SCV.GlCommon.Enums;

    public class OrderDetailViewModel
    {
        public string OrderId { get; set; } = null!;

        public decimal TotalPrice { get; set; }

        public string OrderDate { get; set; } = null!;

        public PaymentMethod PaymentMethod { get; set; }

        public IEnumerable<OrderProductDetailViewModel> Products { get; set; } = new HashSet<OrderProductDetailViewModel>();
    }
}
