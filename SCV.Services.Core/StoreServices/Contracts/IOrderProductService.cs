namespace SCV.Services.Core.StoreServices.Contracts
{
    public interface IOrderProductService
    {
        Task AddProductToOrderAsync(string orderId, string productId, int quantity);

        Task RemoveProductFromOrderAsync(Guid orderId, Guid productId);
    }
}
