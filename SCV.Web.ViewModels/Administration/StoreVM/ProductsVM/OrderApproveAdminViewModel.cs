namespace SCV.Web.ViewModels.Administration.StoreVM.ProductsVM
{
    using SCV.Web.ViewModels.StoreVM;

    public class OrderApproveAdminViewModel : OrderDetailViewModel
    {
        public string CustomerFullName { get; set; } = null!;
        public string? CustomerEmail { get; set; }
    }
}
