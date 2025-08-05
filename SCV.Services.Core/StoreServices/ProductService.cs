namespace SCV.Services.Core.StoreServices
{
    using Microsoft.EntityFrameworkCore;

    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.StoreServices.Contracts;
    using SCV.Web.ViewModels.Administration.StoreVM.ProductsVM;
    using SCV.Web.ViewModels.StoreVM;
    using SVC.Web.ViewModels.StoreVM;

    using static SCV.GlCommon.ApplicationConstants;

    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepo;

        public ProductService(IProductRepository productRepository)
        {
            productRepo = productRepository;
        }

        public async Task<IEnumerable<StoreProductViewModel>> GetAllProductsByProductCategoryAsync(ProductCategory productCategory)
        {
            IEnumerable<StoreProductViewModel> storeProductVM = await productRepo
                                            .GetAllAttached()
                                            .AsNoTracking()
                                            .Where(p => p.ProductCategory == productCategory)
                                            .Select(p => new StoreProductViewModel()
                                            {
                                                Id = p.Id.ToString(),
                                                Title = p.Title,
                                                ProductCategory = p.ProductCategory,
                                                Quantity = p.Quantity,
                                                Description = p.Description ?? "To be added.",
                                                Price = p.Price,
                                                ImageUrl = p.ImageUrl ?? NoImage,
                                            })
                                            .ToListAsync();

            return storeProductVM;

        }

        public async Task<IEnumerable<ProductAdminDetailViewModel>> GetAllProductsForAdminAsync()
        {
            IEnumerable<ProductAdminDetailViewModel> productsAdminDetailVM = await
                                                    productRepo
                                                    .GetAllAttached()
                                                    .AsNoTracking()
                                                    .IgnoreQueryFilters()
                                                    .Select(e => new ProductAdminDetailViewModel()
                                                    {
                                                        Id = e.Id.ToString(),
                                                        Title = e.Title,
                                                    })
                                                    .ToListAsync();

            return productsAdminDetailVM;

        }

        public async Task<bool> AddProductAsync(ProductAddViewModel productAddVM)
        {
            bool isAdded = false;

            if (productAddVM != null)
            {
                Product productToAdd = new Product
                {
                    Title = productAddVM.Title,
                    ProductCategory = productAddVM.ProductCategory,
                    Quantity = productAddVM.Quantity,
                    Description = productAddVM.Description,
                    Price = productAddVM.Price,
                    ImageUrl = productAddVM.ImageUrl,


                };

                await productRepo.AddAsync(productToAdd);
                isAdded = true;
            }

            return isAdded;
        }

        public async Task<ProductEditViewModel?> GetProductByIdAsync(string? id)
        {
            ProductEditViewModel? productEditVM = null;

            if (!string.IsNullOrEmpty(id))
            {
                Product? productEntity = await productRepo
                                    .GetAllAttached()
                                    .IgnoreQueryFilters()
                                    .SingleOrDefaultAsync(cc => cc.Id.ToString().ToLower() == id.ToLower());

                if (productEntity != null)
                {
                    productEditVM = new ProductEditViewModel()
                    {
                        Id = productEntity.Id.ToString(),
                        Title = productEntity.Title,
                        ProductCategory = productEntity.ProductCategory,
                        Quantity = productEntity.Quantity,
                        Description = productEntity.Description,
                        Price = productEntity.Price,
                        ImageUrl = productEntity.ImageUrl,
                    };
                }
            }

            return productEditVM;
        }

        public async Task<bool> EditProductAsync(ProductEditViewModel productEditVM)
        {
            bool isEdited = false;

            if (productEditVM == null)
            {
                return isEdited;
            }

            Product? productEntity = await productRepo
                                        .GetAllAttached()
                                        .IgnoreQueryFilters()
                                        .SingleOrDefaultAsync(cc => cc.Id.ToString().ToLower() == productEditVM.Id.ToLower());

            if (productEntity != null)
            {
                productEntity.Title = productEditVM.Title;
                productEntity.ProductCategory = productEditVM.ProductCategory;
                productEntity.Quantity = productEditVM.Quantity;
                productEntity.Description = productEditVM.Description;
                productEntity.Price = productEditVM.Price;
                productEntity.ImageUrl = productEditVM.ImageUrl;


                isEdited = await productRepo
                                        .UpdateAsync(productEntity);
            }

            return isEdited;
        }

        public async Task<IEnumerable<ProductDeleteViewModel>> GetAllProductsForDeletingAsync()
        {
            IEnumerable<ProductDeleteViewModel> listProductsDeleteVM = await productRepo
                                                    .GetAllAttached()
                                                    .AsNoTracking()
                                                    .IgnoreQueryFilters()
                                                    .Select(e => new ProductDeleteViewModel()
                                                    {
                                                        Id = e.Id.ToString(),
                                                        Title = e.Title,
                                                        ProductCategory = e.ProductCategory,
                                                        IsDeleted = e.IsDeleted
                                                    })
                                                    .ToListAsync();

            return listProductsDeleteVM;
        }

        public async Task<(bool, bool)> DeleteOrRestoreProductAsync(string? id)
        {
            bool result = false;
            bool isRestored = false;

            if (!string.IsNullOrWhiteSpace(id))
            {
                Product? productEntity = await productRepo
                                    .GetAllAttached()
                                    .IgnoreQueryFilters()
                                    .SingleOrDefaultAsync(c => c.Id.ToString().ToLower() == id.ToLower());

                if (productEntity != null)
                {
                    if (!productEntity.IsDeleted)
                    {
                        isRestored = true;
                    }

                    productEntity.IsDeleted = !productEntity.IsDeleted;

                    result = await productRepo
                                    .UpdateAsync(productEntity);
                }
            }

            return (result, isRestored);
        }

        public async Task<IEnumerable<ProductResultViewModel>> ReturnProductSearchResult(string searchTerm)
        {
            return await productRepo
                    .GetAllAttached()
                    .AsNoTracking()
                    .Where(p => !p.IsDeleted && p.Title.ToLower().Contains(searchTerm.ToLower()))
                    .Select(p => new ProductResultViewModel
                    {
                        Id = p.Id.ToString(),
                        Title = p.Title,
                        ImageUrl = p.ImageUrl,
                        ProductCategory = p.ProductCategory
                    })
                    .ToListAsync();

        }
    }
}
