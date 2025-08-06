namespace SCV.Services.Core.StoreServices
{
    using Microsoft.EntityFrameworkCore;

    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.GlCommon.Enums;
    using SCV.Services.Core.StoreServices.Contracts;
    using SCV.Web.ViewModels.Administration.StoreVM.ProductsVM;
    using SCV.Web.ViewModels.StoreVM;

    using static SCV.GlCommon.ApplicationConstants;

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepo;

        public OrderService(IOrderRepository orderRepo)
        {
            this.orderRepo = orderRepo;
        }

        public async Task<Order> GetOrCreateDraftOrderAsync(string userId)
        {
            bool isUserIdGuidable = Guid.TryParse(userId, out Guid userGuid);

            if (!isUserIdGuidable)
            {
                throw new ArgumentException("Invalid user ID format.");
            }

            Order? order = await orderRepo
                    .GetAllAttached()
                    .Include(o => o.OrderProducts)
                    .SingleOrDefaultAsync(o => o.CustomerId.ToString().ToLower() == userId.ToLower()
                                            && o.OrderStatus == OrderStatus.Processing
                                            && o.IsDeleted == false);


            if (order == null)
            {
                order = new Order
                {
                    CustomerId = userGuid,
                    OrderDate = DateTime.UtcNow,
                    OrderStatus = OrderStatus.Processing,
                    TotalPrice = 0m
                };

                await orderRepo.AddAsync(order);
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

            Order? order = await orderRepo
                            .GetAllAttached()
                            .Include(o => o.OrderProducts)
                            .ThenInclude(op => op.Product)
                            .SingleOrDefaultAsync(o => o.CustomerId == userGuid && o.OrderStatus == OrderStatus.Processing);

            if (order != null)
            {
                orderDetailViewModel = new OrderDetailViewModel
                {
                    OrderId = order!.Id.ToString(),
                    OrderDate = order.OrderDate.ToString(DateOnlyFormat),
                    Products = order.OrderProducts.Select(op => new OrderProductDetailViewModel
                                            {
                                                ProductId = op.ProductId.ToString(),
                                                Title = op.Product.Title,
                                                Price = op.Price,
                                                Quantity = op.Quantity,
                                                ImageUrl = op.Product.ImageUrl ?? NoImage,
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
                .Select(o => new OrderDetailViewModel
                {
                    OrderId = o.Id.ToString(),
                    TotalPrice = o.OrderProducts.Sum(op => op.Product.Price * op.Quantity),
                    OrderDate = o.OrderDate.ToString(DateOnlyFormat),
                    Products = o.OrderProducts.Select(op => new OrderProductDetailViewModel
                                            {
                                                ProductId = op.ProductId.ToString(),
                                                Title = op.Product.Title,
                                                Price = op.Product.Price,
                                                Quantity = op.Quantity,
                                                ImageUrl = op.Product.ImageUrl ?? NoImage,

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
                return isFinished;
            }

            Order? order = await orderRepo
                            .GetAllAttached()
                            .Include(o => o.OrderProducts)
                            .SingleOrDefaultAsync(o => o.CustomerId.ToString().ToLower() == userId.ToLower() && o.OrderStatus == OrderStatus.Processing);

            if (order != null || !order!.OrderProducts.Any())
            {
                order.PaymentMethod = paymentMethod;
                order.OrderStatus = OrderStatus.Shipped;
                order.TotalPrice = order.OrderProducts.Sum(op => op.Quantity * op.Price);

                isFinished = await orderRepo.UpdateAsync(order);
            }

            return isFinished;
        }

        public async Task<IEnumerable<OrderApproveAdminViewModel>> GetUsersOrdersForProcessingAsync()
        {
            return await orderRepo
                .GetAllAttached()
                .Where(o => o.OrderStatus == OrderStatus.Processing)
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                 .Include(o => o.Customer)
                .Select(o => new OrderApproveAdminViewModel
                {
                    OrderId = o.Id.ToString(),
                    CustomerFullName = o.Customer.FullName,
                    CustomerEmail = o.Customer.Email!=null? o.Customer.Email : o.Customer.UserName ?? null,
                    TotalPrice = o.OrderProducts.Sum(op => op.Product.Price * op.Quantity),
                    OrderDate = o.OrderDate.ToString(DateOnlyFormat),
                    Products = o.OrderProducts.Select(op => new OrderProductDetailViewModel
                    {
                        ProductId = op.ProductId.ToString(),
                        Title = op.Product.Title,
                        Price = op.Product.Price,
                        Quantity = op.Quantity,
                        ImageUrl = op.Product.ImageUrl ?? NoImage,

                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<bool> ApproveOrderStatusAsync(string orderId, OrderStatus newStatus)
        {
            bool isApproved = false;

            Order? orderToApprove = await orderRepo
                            .GetAllAttached()
                            .SingleOrDefaultAsync(o => o.Id.ToString().ToLower() == orderId.ToLower());

            if (orderToApprove != null)
            {
                if (orderToApprove.OrderStatus == OrderStatus.Cancelled)
                {
                    isApproved = await this.orderRepo
                                        .HardDeleteAsync(orderToApprove);
                }
                else
                {
                    orderToApprove.OrderStatus = newStatus;
                    isApproved = await orderRepo.UpdateAsync(orderToApprove);
                }
            }

            return isApproved;
        }

        public async Task<IEnumerable<OrderAdminDetailViewModel>> GetAllOrdersForAdminAsync()
        {
            return await orderRepo
                .GetAllAttached()
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .Select(o => new OrderAdminDetailViewModel
                {
                    OrderId = o.Id.ToString(),
                    TotalPrice = o.OrderProducts.Sum(op => op.Product.Price * op.Quantity),
                    OrderDate = o.OrderDate.ToString(DateOnlyFormat),
                    UserFullName = o.Customer.FullName,
                    Email = o.Customer.Email ?? o.Customer.UserName!,
                    Products = o.OrderProducts.Select(op => new OrderProductDetailViewModel
                    {
                        ProductId = op.ProductId.ToString(),
                        Title = op.Product.Title,
                        Price = op.Product.Price,
                        Quantity = op.Quantity,
                        ImageUrl = op.Product.ImageUrl ?? NoImage,

                    }).ToList()
                })
                .ToListAsync();
        }
    }
}
