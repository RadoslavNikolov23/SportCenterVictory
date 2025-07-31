namespace SCV.Data.Repository.Contracts
{
    using SCV.Data.Models;

    public interface ITrainerUserRepository : IAsyncRepository<TrainerUser, (Guid, Guid)>, IRepository<TrainerUser, (Guid, Guid)>
    {

        TrainerUser? GetByCompositeKey(string trainerId, string userId);

        Task<TrainerUser?> GetByCompositeKeyAsync(string trainerId, string userId);

        bool Exists(string trainerId, string userId);

        Task<bool> ExistsAsync(string trainerId, string userId);
    }
}
