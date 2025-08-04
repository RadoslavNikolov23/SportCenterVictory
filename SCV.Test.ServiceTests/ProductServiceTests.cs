namespace SCV.Test.ServiceTests
{
    using MockQueryable.Moq;
    using Moq;
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.Administration.StoreVM.ProductsVM;
    using SCV.Web.ViewModels.StoreVM;
    using SVC.Web.ViewModels.StoreVM;

    public class ProductServiceTests
    {
        private Mock<IProductRepository> mockRepo;
        private IProductService productService;

        [SetUp]
        public void SetUp()
        {
            mockRepo = new Mock<IProductRepository>();
            productService = new ProductService(mockRepo.Object);
        }

        [Test]
        public async Task GetAllProductsByProductCategoryAsync_ReturnsCorrectProducts()
        {
            ProductCategory category = ProductCategory.Equipment;
            IQueryable<Product> products = new List<Product>
            {
                new Product
                    {
                        Id = Guid.NewGuid(),
                        Title = "CrossFit Hoodie",
                        ProductCategory  = ProductCategory.Equipment,
                        Quantity = 30,
                        Description = "Black hoodie for CrossFit sessions.",
                        Price = 52.99m,
                        ImageUrl = "hoodie.jpg"
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Title = "CrossFit White Hoodie",
                        ProductCategory  = ProductCategory.Equipment,
                        Quantity = 50,
                        Description = "Black hoodie for CrossFit sessions.",
                        Price = 49.99m,
                        ImageUrl = "whiteHoodie.jpg"
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Title = "Shaker",
                        ProductCategory =  ProductCategory.Nutrition,
                        Quantity = 50,
                        Description = "Shaker bottle with Captain America shield.",
                        Price = 14.99m,
                        ImageUrl = "shaker.jpg"
                    }


            }.AsQueryable();

            var mockSet = products.BuildMockDbSet();
            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);

            IEnumerable<StoreProductViewModel> resultEnumerable = await productService
                            .GetAllProductsByProductCategoryAsync(category);

            IList<StoreProductViewModel> result = resultEnumerable.ToList();

            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result[0].Title, Is.EqualTo("CrossFit Hoodie"));
            Assert.That(result[1].Title, Is.EqualTo("CrossFit White Hoodie"));

        }

        [Test]
        public async Task GetAllProductsForAdminAsync_ReturnsAllProducts()
        {
            IQueryable<Product> products = new List<Product>
            {
                new Product
                    {
                        Id = Guid.NewGuid(),
                        Title = "CrossFit Hoodie",
                        ProductCategory  = ProductCategory.Equipment,
                        Quantity = 30,
                        Description = "Black hoodie for CrossFit sessions.",
                        Price = 52.99m,
                        ImageUrl = "hoodie.jpg"
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Title = "CrossFit White Hoodie",
                        ProductCategory  = ProductCategory.Equipment,
                        Quantity = 50,
                        Description = "Black hoodie for CrossFit sessions.",
                        Price = 49.99m,
                        ImageUrl = "whiteHoodie.jpg"
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Title = "Shaker",
                        ProductCategory =  ProductCategory.Nutrition,
                        Quantity = 50,
                        Description = "Shaker bottle with Captain America shield.",
                        Price = 14.99m,
                        ImageUrl = "shaker.jpg"
                    }


            }.AsQueryable();

            var mockSet = products.BuildMockDbSet();
            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);

            IEnumerable<ProductAdminDetailViewModel> resultEnumerable = await productService
                                .GetAllProductsForAdminAsync();

            IList<ProductAdminDetailViewModel> result = resultEnumerable.ToList();

            Assert.That(result.Count(), Is.EqualTo(3));
            Assert.That(result[0].Title, Is.EqualTo("CrossFit Hoodie"));
            Assert.That(result[1].Title, Is.EqualTo("CrossFit White Hoodie"));
            Assert.That(result[2].Title, Is.EqualTo("Shaker"));
        }

        [Test]
        public async Task AddProductAsync_AddsProductSuccessfully()
        {
            ProductAddViewModel newProduct = new ProductAddViewModel
            {
                Title = "New Shaker",
                ProductCategory = ProductCategory.Nutrition,
                Quantity = 15,
                Description = "New Shaker all metal bottle.",
                Price = 24.99m,
                ImageUrl = "metalShaker.jpg"
            };

            mockRepo.Setup(r => r.AddAsync(It.IsAny<Product>()))
                                .Returns(Task.CompletedTask);

            bool isAdded = await productService
                                .AddProductAsync(newProduct);
            Assert.IsTrue(isAdded);

        }

        [Test]
        public async Task GetProductByIdAsync_ReturnsProduct_WhenFound()
        {
            Guid productId = Guid.NewGuid();
            IQueryable<Product> products = new List<Product>
            {
                new Product
                    {
                        Id = productId,
                        Title = "CrossFit Hoodie",
                        ProductCategory  = ProductCategory.Equipment,
                        Quantity = 30,
                        Description = "Black hoodie for CrossFit sessions.",
                        Price = 52.99m,
                        ImageUrl = "hoodie.jpg"
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Title = "CrossFit White Hoodie",
                        ProductCategory  = ProductCategory.Equipment,
                        Quantity = 50,
                        Description = "Black hoodie for CrossFit sessions.",
                        Price = 49.99m,
                        ImageUrl = "whiteHoodie.jpg"
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Title = "Shaker",
                        ProductCategory =  ProductCategory.Nutrition,
                        Quantity = 50,
                        Description = "Shaker bottle with Captain America shield.",
                        Price = 14.99m,
                        ImageUrl = "shaker.jpg"
                    }


            }.AsQueryable();

            var mockSet = products.BuildMockDbSet();
            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);

            ProductEditViewModel? result = await productService
                            .GetProductByIdAsync(productId.ToString());

            Assert.IsNotNull(result);
            Assert.That(result.Title, Is.EqualTo("CrossFit Hoodie"));
            Assert.That(result.ProductCategory, Is.EqualTo(ProductCategory.Equipment));
            Assert.That(result.Quantity, Is.EqualTo(30));
            Assert.That(result.Description, Is.EqualTo("Black hoodie for CrossFit sessions."));
            Assert.That(result.Price, Is.EqualTo(52.99));
            Assert.That(result.ImageUrl, Is.EqualTo("hoodie.jpg"));

        }

        [Test]
        public async Task EditProductAsync_UpdatesProductSuccessfully()
        {
            Guid productId = Guid.NewGuid();

            Product product = new Product
            {
                Id = productId,
                Title = "Shaker",
                ProductCategory = ProductCategory.Nutrition,
                Quantity = 50,
                Description = "Shaker bottle with Captain America shield.",
                Price = 14.99m,
                ImageUrl = "shaker.jpg"
            };

            IQueryable<Product> products = new List<Product> 
                                            { 
                                                product 
                                            }
                                            .AsQueryable();

            var mockSet = products.BuildMockDbSet();

            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);
            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Product>()))
                    .ReturnsAsync(true);

            ProductEditViewModel productEditVM= new ProductEditViewModel
            {
                Id = productId.ToString(),
                Title = "Test",
                ProductCategory = ProductCategory.Nutrition,
                Quantity = 90,
                Description = "Test",
                Price = 99.99m,
                ImageUrl = "test.jpg"
            };

            bool isEdit = await productService
                            .EditProductAsync(productEditVM);
            Assert.IsTrue(isEdit);

            Assert.That(product.Title, Is.EqualTo("Test"));
            Assert.That(product.ProductCategory, Is.EqualTo(ProductCategory.Nutrition));
            Assert.That(product.Quantity, Is.EqualTo(90));
            Assert.That(product.Description, Is.EqualTo("Test"));
            Assert.That(product.Price, Is.EqualTo(99.99));
            Assert.That(product.ImageUrl, Is.EqualTo("test.jpg"));

        }

        [Test]
        public async Task GetAllProductsForDeletingAsync_ReturnsProducts()
        {
            IQueryable<Product> products = new List<Product>
            {
                new Product
                    {
                        Id = Guid.NewGuid(),
                        Title = "CrossFit Hoodie",
                        ProductCategory  = ProductCategory.Equipment,
                        Quantity = 30,
                        Description = "Black hoodie for CrossFit sessions.",
                        Price = 52.99m,
                        ImageUrl = "hoodie.jpg",
                        IsDeleted = false
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Title = "CrossFit White Hoodie",
                        ProductCategory  = ProductCategory.Equipment,
                        Quantity = 50,
                        Description = "Black hoodie for CrossFit sessions.",
                        Price = 49.99m,
                        ImageUrl = "whiteHoodie.jpg",
                        IsDeleted = false

                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Title = "Shaker",
                        ProductCategory =  ProductCategory.Nutrition,
                        Quantity = 50,
                        Description = "Shaker bottle with Captain America shield.",
                        Price = 14.99m,
                        ImageUrl = "shaker.jpg",
                        IsDeleted = true
                    }


            }.AsQueryable();

            var mockSet = products.BuildMockDbSet();
            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);

            IEnumerable<ProductDeleteViewModel> result = await productService
                        .GetAllProductsForDeletingAsync();

            Assert.That(result.Count(), Is.EqualTo(3));

        }

        [Test]
        public async Task DeleteOrRestoreProductAsync_TogglesIsDeleted()
        {
            Guid productId = Guid.NewGuid();
            Product product = new Product 
            {
                Id = productId,
                Title = "Shaker",
                ProductCategory =  ProductCategory.Nutrition,
                Quantity = 50,
                Description = "Shaker bottle with Captain America shield.",
                Price = 14.99m,
                ImageUrl = "shaker.jpg",
                IsDeleted = false
            };

            IQueryable<Product> products = new List<Product> 
                                        { 
                                            product 
                                        }
                                        .AsQueryable();

            var mockSet = products.BuildMockDbSet();
            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);
            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Product>()))
                    .ReturnsAsync(true);

            (bool result, bool isRestored) = await productService
                                .DeleteOrRestoreProductAsync(productId.ToString());

            Assert.IsTrue(result);
            Assert.IsTrue(isRestored);
        }

        [Test]
        public async Task ReturnProductSearchResult_ReturnsFilteredProducts()
        {
            IQueryable<Product> products = new List<Product>
            {
                new Product
                    {
                        Id = Guid.NewGuid(),
                        Title = "CrossFit Hoodie",
                        ProductCategory  = ProductCategory.Equipment,
                        Quantity = 30,
                        Description = "Black hoodie for CrossFit sessions.",
                        Price = 52.99m,
                        ImageUrl = "hoodie.jpg"
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Title = "CrossFit White Hoodie",
                        ProductCategory  = ProductCategory.Equipment,
                        Quantity = 50,
                        Description = "Black hoodie for CrossFit sessions.",
                        Price = 49.99m,
                        ImageUrl = "whiteHoodie.jpg"
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Title = "Shaker",
                        ProductCategory =  ProductCategory.Nutrition,
                        Quantity = 50,
                        Description = "Shaker bottle with Captain America shield.",
                        Price = 14.99m,
                        ImageUrl = "shaker.jpg"
                    }


            }.AsQueryable();

            var mockSet = products.BuildMockDbSet();
            mockRepo.Setup(r => r.GetAllAttached())
                    .Returns(mockSet.Object);

            IEnumerable<ProductResultViewModel> result = await productService.
                            ReturnProductSearchResult("Hoodie");

            Assert.That(result.Count(), Is.EqualTo(2));

        }
    }
}
