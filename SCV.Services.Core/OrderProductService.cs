namespace SCV.Services.Core
{
    using Microsoft.EntityFrameworkCore;
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.Services.Core.Contracts;

    public class OrderProductService : IOrderProductService
    {
        private readonly IOrderProductRepository orderProductRepo;
        private readonly IProductRepository productRepo;
        public OrderProductService(IOrderProductRepository orderProductRepo, IProductRepository productRepo)
        {
            this.orderProductRepo = orderProductRepo;
            this.productRepo = productRepo;
        }

        public async Task AddProductToOrderAsync(string orderId, string productId, int quantity)
        {
            bool isOrderIdGuidable = Guid.TryParse(orderId.ToString(), out Guid orderGuidId);
            bool isProductIdGuidable = Guid.TryParse(productId.ToString(), out Guid productGuidId);

            if (!isOrderIdGuidable || !isProductIdGuidable)
            {
                throw new ArgumentException("Invalid ID format.");
            }

            Product? product = await this.productRepo
                            .GetByIdAsync(productGuidId);

            if (product == null)
            {
                throw new ArgumentException($"Product with ID {productId} does not exist.");
            }

            OrderProduct? existingOrderProduct = await this.orderProductRepo
                            .GetAllAttached()
                            .SingleOrDefaultAsync(op => op.OrderId == orderGuidId && op.ProductId == productGuidId);

            if (existingOrderProduct != null)
            {
                existingOrderProduct.Quantity += quantity;

                await this.orderProductRepo.UpdateAsync(existingOrderProduct);
            }
            else
            {
                OrderProduct orderProductNew = new OrderProduct
                {
                    OrderId = orderGuidId,
                    ProductId = productGuidId,
                    Quantity = quantity,
                    Price = product.Price
                };

                await this.orderProductRepo.AddAsync(orderProductNew);
            }
        }

        public async Task RemoveProductFromOrderAsync(Guid orderId, Guid productId)
        {
            OrderProduct? item = await this.orderProductRepo
                .GetAllAttached()
                .SingleOrDefaultAsync(op => op.OrderId == orderId && op.ProductId == productId);

            if (item != null)
            {
                //TODO: For SoftDeletion when added
                //await this.orderProductRepo.DeleteAsync(item);

                await this.orderProductRepo.HardDeleteAsync(item);
            }
        }
    }
}
