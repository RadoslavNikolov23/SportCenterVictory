namespace SCV.Web.ViewModels.Administration.StoreVM.ProductsVM
{
    using SCV.Web.ViewModels.StoreVM;

    public class OrderAdminDetailViewModel : OrderDetailViewModel
    {
        public string UserFullName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
