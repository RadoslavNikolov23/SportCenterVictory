namespace SCV.Web.ViewModels.StoreVM
{
    public class CartPageViewModel
    {
        public OrderDetailViewModel? CurrentCart { get; set; }

        public IEnumerable<OrderDetailViewModel> PastOrders { get; set; } = new HashSet<OrderDetailViewModel>();
    }
}
