namespace SCV.Test.ServiceTests
{
    using Moq;
    using MockQueryable.Moq;

    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core;
    using SCV.Web.ViewModels.Administration.StoreVM.ProductsVM;
    using SCV.Web.ViewModels.StoreVM;
    using SCV.Services.Core.StoreServices.Contracts;

    [TestFixture]
    public class OrderServiceTests
    {
        private Mock<IOrderRepository> orderRepoMock;
        private IOrderService orderService;

        [SetUp]
        public void Setup()
        {
            orderRepoMock = new Mock<IOrderRepository>();
            orderService = new OrderService(orderRepoMock.Object);
        }

        [Test]
        public async Task GetOrCreateDraftOrderAsync_ReturnsExistingDraftOrder()
        {
            Guid userId = Guid.NewGuid();
            Order existingOrder = new Order
            {
                CustomerId = userId,
                OrderStatus = OrderStatus.Processing,
                OrderProducts = new List<OrderProduct>()
            };

            IQueryable<Order> orderList = new List<Order>
                                            {
                                                existingOrder
                                            }
                                            .AsQueryable();


            var mockSet = orderList.BuildMockDbSet();


            orderRepoMock.Setup(r => r.GetAllAttached())
                        .Returns(mockSet.Object);

            Order result = await orderService
                            .GetOrCreateDraftOrderAsync(userId.ToString());

            Assert.That(result, Is.EqualTo(existingOrder));
        }

        [Test]
        public void GetOrCreateDraftOrderAsync_InvalidUserId_ThrowsException()
        {
            //For project purpose only!
            Assert.ThrowsAsync<ArgumentException>(async () => await orderService.GetOrCreateDraftOrderAsync("invalid-guidId"));
        }

        [Test]
        public async Task GetUserCartAsync_ReturnsOrderDetailViewModel()
        {
            Guid userId = Guid.NewGuid();

            Product product = new Product
            {
                Title = "Shaker",
                ProductCategory = ProductCategory.Nutrition,
                Quantity = 50,
                Description = "Shaker bottle with Captain America shield.",
                Price = 14.99m,
                ImageUrl = "shaker.jpg"

            };

            Order order = new Order
            {
                Id = Guid.NewGuid(),
                CustomerId = userId,
                OrderDate = DateTime.UtcNow,
                OrderStatus = OrderStatus.Processing,
                OrderProducts = new List<OrderProduct> { new OrderProduct
                                                            {
                                                                Product = product,
                                                                ProductId = Guid.NewGuid(),
                                                                Quantity = 2,
                                                                Price = 10
                                                            }
                                                        }
            };

            var mockSet = new List<Order> 
                                { 
                                    order 
                                }
                                .AsQueryable()
                                .BuildMockDbSet();

            orderRepoMock.Setup(r => r.GetAllAttached())
                         .Returns(mockSet.Object);

            OrderDetailViewModel? result = await orderService
                                .GetUserCartAsync(userId.ToString());

            Assert.IsNotNull(result);
            Assert.That(result.TotalPrice, Is.EqualTo(20));
            Assert.That(result.Products.Count(), Is.EqualTo(1));

        }

        [Test]
        public async Task GetUserPastOrdersAsync_ReturnsCorrectOrders()
        {
            Guid userId = Guid.NewGuid();
            Order order = new Order
            {
                Id = Guid.NewGuid(),
                CustomerId = userId,
                OrderDate = DateTime.UtcNow,
                OrderStatus = OrderStatus.Delivered,
                OrderProducts = new List<OrderProduct> { new OrderProduct
                                                        {
                                                        Product = new Product
                                                                {   Title = "CrossFit Hoodie",
                                                                    ProductCategory  = ProductCategory.Equipment,
                                                                    Quantity = 30,
                                                                    Description = "Black hoodie for CrossFit sessions.",
                                                                    Price = 52.99m,
                                                                },
                                                        Quantity = 1 } 
                                                        }
            };

            var mockSet = new List<Order> 
                                { 
                                    order 
                                }
                                .AsQueryable()
                                .BuildMockDbSet();
            orderRepoMock.Setup(r => r.GetAllAttached()).Returns(mockSet.Object);

            IEnumerable<OrderDetailViewModel> result = await orderService
                                .GetUserPastOrdersAsync(userId.ToString());

            Assert.That(result.Count(), Is.EqualTo(1));

        }

        [Test]
        public async Task FinishOrderAsync_ValidOrder_UpdatesSuccessfully()
        {
            Guid userId = Guid.NewGuid();
            Order order = new Order
            {
                CustomerId = userId,
                OrderStatus = OrderStatus.Processing,
                OrderProducts = new List<OrderProduct> { new OrderProduct
                                                                    {
                                                                        Quantity = 2,
                                                                        Price = 5
                                                                    }
                                                        }
            };

            var mockSet = new List<Order> 
                                { 
                                    order
                                }
                                .AsQueryable()
                                .BuildMockDbSet();

            orderRepoMock.Setup(r => r.GetAllAttached())
                         .Returns(mockSet.Object);
            orderRepoMock.Setup(r => r.UpdateAsync(order))
                         .ReturnsAsync(true);

            bool isFinished = await orderService
                                .FinishOrderAsync(userId.ToString(), PaymentMethod.OnDelivery);

            Assert.IsTrue(isFinished);

            Assert.That(order.OrderStatus, Is.EqualTo(OrderStatus.Shipped));
            Assert.That(order.TotalPrice, Is.EqualTo(10));

        }

        [Test]
        public async Task UpdateOrderStatusAsync_UpdatesStatus()
        {
            Guid orderId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();

            Order order = new Order
            {
                Id = orderId,
                CustomerId = userId,
                OrderStatus = OrderStatus.Processing,
                OrderProducts = new List<OrderProduct> { new OrderProduct
                                                                    {
                                                                        Quantity = 2,
                                                                        Price = 5
                                                                    }
                                                        }
            };

            IQueryable<Order> orderList = (IQueryable<Order>)new List<Order>
                                            {
                                                order
                                            }
                                            .AsQueryable();

            var mockSet = orderList.BuildMockDbSet();


            orderRepoMock.Setup(r => r.GetAllAttached())
                        .Returns(mockSet.Object);

            orderRepoMock.Setup(r => r.UpdateAsync(order))
                         .ReturnsAsync(true);

            bool isUpdated = await orderService
                                    .UpdateOrderStatusAsync(orderId.ToString(), OrderStatus.Delivered);

            Assert.IsTrue(isUpdated);
            Assert.That(order.OrderStatus, Is.EqualTo(OrderStatus.Delivered));

        }

        [Test]
        public async Task GetUsersOrdersForProcessingAsync_ReturnsProcessingOrders()
        {
            var order = new Order
            {
                OrderStatus = OrderStatus.Processing,
                OrderDate = DateTime.UtcNow,
                OrderProducts = new List<OrderProduct> { new OrderProduct
                                                        { Product = new Product
                                                            {
                                                                Title = "CrossFit Hoodie",
                                                                ProductCategory  = ProductCategory.Equipment,
                                                                Quantity = 30,
                                                                Description = "Black hoodie for CrossFit sessions.",
                                                                Price = 52.99m
                                                            },
                                                          Quantity = 1 } 
                                                        }
            };

            var mockSet = new List<Order> 
                                { 
                                    order 
                                }
                                .AsQueryable()
                                .BuildMockDbSet();
            orderRepoMock.Setup(r => r.GetAllAttached())
                         .Returns(mockSet.Object);

            IEnumerable<OrderApproveAdminViewModel> result = await orderService
                        .GetUsersOrdersForProcessingAsync();

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.Count(), Is.EqualTo(1));

        }

        [Test]
        public async Task GetAllOrdersForAdminAsync_ReturnsAllOrders()
        {
            Order order = new Order
            {
                Id = Guid.NewGuid(),
                OrderDate = DateTime.UtcNow,
                Customer = new ApplicationUser
                {
                    FullName = "Rado Petrov",
                    Email = "rado@test.com"
                },
                OrderProducts = new List<OrderProduct> { new OrderProduct
                                                            {
                                                                Product = new Product
                                                                {
                                                                    Title = "CrossFit Hoodie",
                                                                    ProductCategory  = ProductCategory.Equipment,
                                                                    Quantity = 30,
                                                                    Description = "Black hoodie for CrossFit sessions.",
                                                                    Price = 52.99m
                                                                },
                                                                Quantity = 1 } 
                                                            }
            };

            var mockSet = new List<Order>
                                {
                                    order
                                }
                                .AsQueryable()
                                .BuildMockDbSet();
            orderRepoMock.Setup(r => r.GetAllAttached())
                         .Returns(mockSet.Object);

            IEnumerable<OrderAdminDetailViewModel> result = await orderService
                                .GetAllOrdersForAdminAsync();

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().UserFullName, Is.EqualTo("Rado Petrov"));
            Assert.That(result.First().Email, Is.EqualTo("rado@test.com"));

        }
    }
}
