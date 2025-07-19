namespace SCV.Services.Core
{
    using Microsoft.EntityFrameworkCore;
    using SCV.Data.Repository.Contracts;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.Contracts;
    using SVC.Web.ViewModels.StoreVM;

    public class ProductService: IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
           this.productRepository = productRepository;  
        }

        public async Task<IEnumerable<StoreProductViewModel>> GetAllProductsByProductCategoryAsync(ProductCategory productCategory)
        {
            IEnumerable<StoreProductViewModel> storeProductVM = await this.productRepository
                                            .GetAllAttached()
                                            .AsNoTracking()
                                            .Where(p=>p.ProductCategory == productCategory)
                                            .Select(p=> new StoreProductViewModel()
                                            {
                                                Id = p.Id,
                                                Title = p.Title,
                                                ProductCategory = p.ProductCategory,
                                                Quantity = p.Quantity,
                                                Description = p.Description ?? "To be added.",
                                                Price = p.Price,
                                                ImageUrl = p.ImageUrl ?? $"/noImage.jpg",
                                            })
                                            .ToListAsync();

            return storeProductVM;

        }
    }
}
