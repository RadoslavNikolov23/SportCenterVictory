namespace SCV.Web.ViewModels.StoreVM
{
    public class ProductSearchViewModel
    {
        public string SearchTerm { get; set; } = null!;

        public IEnumerable<ProductResultViewModel> Results { get; set; } = new HashSet<ProductResultViewModel>();
    }
}
