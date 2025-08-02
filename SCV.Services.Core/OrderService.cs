namespace SCV.Services.Core
{
    using Microsoft.EntityFrameworkCore;

    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.StoreVM;

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepo;

        public OrderService(IOrderRepository orderRepo)
        {
            this.orderRepo = orderRepo;
        }

        public async Task<Order> GetOrCreateDraftOrderAsync(string userId)
        {
            Order? order = await this.orderRepo
                    .GetAllAttached()
                    .Include(o => o.OrderProducts)
                    .SingleOrDefaultAsync(o => o.CustomerId.ToString().ToLower() == userId.ToLower()
                                            && o.OrderStatus == OrderStatus.Processing
                                            && o.IsDeleted == false);

            bool isUserIdGuidable = Guid.TryParse(userId, out Guid userGuid);

            if (!isUserIdGuidable)
            {
                throw new ArgumentException("Invalid user ID format.");
            }

            if (order == null)
            {
                order = new Order
                {
                    CustomerId = userGuid,
                    OrderDate = DateTime.UtcNow,
                    OrderStatus = OrderStatus.Processing,
                    TotalPrice = 0m
                };

                await this.orderRepo.AddAsync(order);
            }

            return order;
        }

        public async Task<OrderDetailViewModel?> GetUserCartAsync(string userId)
        {
            OrderDetailViewModel? orderDetailViewModel = null;

            bool isUserIdGuidable = Guid.TryParse(userId, out Guid userGuid);

            if (!isUserIdGuidable)
            {
                throw new ArgumentException("Invalid user ID format.");
            }

            Order? order = await this.orderRepo
                            .GetAllAttached()
                            .Include(o => o.OrderProducts)
                            .ThenInclude(op => op.Product)
                            .SingleOrDefaultAsync(o => o.CustomerId == userGuid && o.OrderStatus == OrderStatus.Processing);

            if (order != null)
            {
                orderDetailViewModel = new OrderDetailViewModel
                {
                    OrderId = order!.Id.ToString(),
                    Products = order.OrderProducts.Select(op => new OrderProductDetailViewModel
                                                {
                                                    ProductId = op.ProductId.ToString(),
                                                    Title = op.Product.Title,
                                                    //Price = op.Price.ToString("C"),
                                                    Price = op.Price,
                                                    Quantity = op.Quantity,
                                                    ImageUrl = op.Product.ImageUrl ?? $"/noImage.jpg",
                                                })
                                                .ToList(),
                    TotalPrice = order.OrderProducts.Sum(op => op.Price * op.Quantity)
                };
            }

            return orderDetailViewModel;
        }

        public async Task<IEnumerable<OrderDetailViewModel>> GetUserPastOrdersAsync(string userId)
        {
            return await orderRepo
                .GetAllAttached()
                .Where(o => o.CustomerId.ToString().ToLower() == userId.ToLower() 
                   && (o.OrderStatus == OrderStatus.Delivered || o.OrderStatus == OrderStatus.Shipped))
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .Select(order => new OrderDetailViewModel
                {
                    OrderId = order.Id.ToString(),
                    TotalPrice = order.OrderProducts.Sum(op => op.Product.Price * op.Quantity),
                    Products = order.OrderProducts.Select(op => new OrderProductDetailViewModel
                                                {
                                                    ProductId = op.ProductId.ToString(),
                                                    Title = op.Product.Title,
                                                    //Price = op.Product.Price.ToString("C"),
                                                    Price = op.Product.Price,
                                                    Quantity = op.Quantity,
                                                    ImageUrl = op.Product.ImageUrl ?? $"/noImage.jpg",

                                                }).ToList()
                })
                .ToListAsync();
        }

        public async Task<bool> FinishOrderAsync(string userId, PaymentMethod paymentMethod)
        {
            bool isFinished = false;
            bool isUserIdGuidable = Guid.TryParse(userId, out Guid userGuid);

            if (!isUserIdGuidable)
            {
                return isFinished; // Invalid user ID format
            }

            Order? order = await this.orderRepo
                            .GetAllAttached()
                            .Include(o => o.OrderProducts)
                            .SingleOrDefaultAsync(o => o.CustomerId.ToString().ToLower() == userId.ToLower() && o.OrderStatus == OrderStatus.Processing);

            if (order != null || !order.OrderProducts.Any())
            {
                order.PaymentMethod = paymentMethod;
                order.OrderStatus = OrderStatus.Shipped;
                order.TotalPrice = order.OrderProducts.Sum(op => op.Quantity * op.Price);

                isFinished = await this.orderRepo.UpdateAsync(order);
            }

            return isFinished;
        }
    }
}
