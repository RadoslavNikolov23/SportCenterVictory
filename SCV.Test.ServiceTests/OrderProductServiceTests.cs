namespace SCV.Test.ServiceTests
{
    using MockQueryable.Moq;
    using Moq;
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.StoreServices;
    using SCV.Services.Core.StoreServices.Contracts;

    [TestFixture]
    public class OrderProductServiceTests
    {
        private Mock<IOrderProductRepository> orderProductRepoMock;
        private Mock<IProductRepository> productRepoMock;
        private IOrderProductService orderProductservice;

        [SetUp]
        public void Setup()
        {
            orderProductRepoMock = new Mock<IOrderProductRepository>();
            productRepoMock = new Mock<IProductRepository>();
            orderProductservice = new OrderProductService(orderProductRepoMock.Object, productRepoMock.Object);
        }

        [Test]
        public async Task AddProductToOrderAsync_AddsNewOrderProduct_WhenNotExists()
        {
            Guid orderId = Guid.NewGuid();
            Guid productId = Guid.NewGuid();
            int quantity = 50;

            Product product = new Product
            {
                Id = productId,
                Title = "Shaker",
                ProductCategory = ProductCategory.Nutrition,
                Quantity = quantity,
                Description = "Shaker bottle with Captain America shield.",
                Price = 14.99m
            };

            IQueryable<OrderProduct> orderProducts = new List<OrderProduct>()
                                        .AsQueryable();

            productRepoMock.Setup(r => r.GetByIdAsync(productId))
                            .ReturnsAsync(product);
            orderProductRepoMock.Setup(r => r.GetAllAttached())
                            .Returns(orderProducts.BuildMockDbSet().Object);

            await orderProductservice
                        .AddProductToOrderAsync(orderId.ToString(), productId.ToString(), quantity);

            orderProductRepoMock.Verify(r => r.AddAsync(It.Is<OrderProduct>(op =>
                op.OrderId == orderId &&
                op.ProductId == productId &&
                op.Quantity == quantity &&
                op.Price == 14.99m
            )), Times.Once);
        }

        [Test]
        public async Task AddProductToOrderAsync_UpdatesExistingOrderProduct()
        {
            Guid orderId = Guid.NewGuid();
            Guid productId = Guid.NewGuid();

            Product product = new Product
            {
                Id = productId,
                Title = "Shaker",
                ProductCategory = ProductCategory.Nutrition,
                Quantity = 50,
                Description = "Shaker bottle with Captain America shield.",
                Price = 14.99m
            };

            OrderProduct existingOrderProduct = new OrderProduct
            {
                OrderId = orderId,
                ProductId = productId,
                Quantity = 2,
                Price = 14.99m
            };

            IQueryable<OrderProduct> orderProducts = new List<OrderProduct> 
                                                        { 
                                                            existingOrderProduct 
                                                        }
                                                        .AsQueryable();

            productRepoMock.Setup(r => r.GetByIdAsync(productId))
                            .ReturnsAsync(product);
            orderProductRepoMock.Setup(r => r.GetAllAttached())
                            .Returns(orderProducts.BuildMockDbSet().Object);

            await orderProductservice
                        .AddProductToOrderAsync(orderId.ToString(), productId.ToString(), 3);

            Assert.That(existingOrderProduct.Quantity, Is.EqualTo(5));
            orderProductRepoMock.Verify(r => r.UpdateAsync(existingOrderProduct), Times.Once);
        }

        [Test]
        public void AddProductToOrderAsync_ThrowsException_ForInvalidGuids()
        {
            //Just for Developer project purpose
            Assert.ThrowsAsync<ArgumentException>(() => orderProductservice.AddProductToOrderAsync("invalid", "123", 1));
        }

        [Test]
        public void AddProductToOrderAsync_ThrowsException_IfProductNotFound()
        {
            Guid orderId = Guid.NewGuid();
            Guid productId = Guid.NewGuid();

            productRepoMock.Setup(r => r.GetByIdAsync(productId))
                            .ReturnsAsync((Product?)null);

            Assert.ThrowsAsync<ArgumentException>(() => orderProductservice.AddProductToOrderAsync(orderId.ToString(), productId.ToString(), 1));
        }

        [Test]
        public async Task RemoveProductFromOrderAsync_RemovesExistingItem()
        {
            Guid orderId = Guid.NewGuid();
            Guid productId = Guid.NewGuid();

            OrderProduct orderProduct = new OrderProduct
            {
                OrderId = orderId,
                ProductId = productId,
                Quantity = 1,
                Price = 10
            };

            IQueryable<OrderProduct> orderProducts = new List<OrderProduct> 
                                                        { 
                                                            orderProduct 
                                                        }
                                                        .AsQueryable();

            orderProductRepoMock.Setup(r => r.GetAllAttached())
                                .Returns(orderProducts.BuildMockDbSet().Object);

            await orderProductservice
                        .RemoveProductFromOrderAsync(orderId, productId);

            orderProductRepoMock.Verify(r => r.HardDeleteAsync(orderProduct), Times.Once);
        }

        [Test]
        public async Task RemoveProductFromOrderAsync_DoesNothing_IfNotFound()
        {
            IQueryable<OrderProduct> orderProducts = new List<OrderProduct>()
                                                .AsQueryable();

            orderProductRepoMock.Setup(r => r.GetAllAttached())
                                .Returns(orderProducts.BuildMockDbSet().Object);

            await orderProductservice
                    .RemoveProductFromOrderAsync(Guid.NewGuid(), Guid.NewGuid());

            orderProductRepoMock.Verify(r => r.HardDeleteAsync(It.IsAny<OrderProduct>()), Times.Never);
        }
    }
}
