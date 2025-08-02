namespace SCV.Services.Core.Contracts
{
    using SCV.Data.Models;
    using SCV.GlCommon.Enums;
    using SCV.Web.ViewModels.StoreVM;

    public interface IOrderService
    {
        Task<Order> GetOrCreateDraftOrderAsync(string userId);

        Task<OrderDetailViewModel?> GetUserCartAsync(string userId);

        Task<IEnumerable<OrderDetailViewModel>> GetUserPastOrdersAsync(string userId);

        Task<bool> FinishOrderAsync(string userId, PaymentMethod paymentMethod);

        Task<IEnumerable<OrderDetailViewModel>> GetUsersOrdersForProcessingAsync(string userId);
    }
}
