namespace SCV.Data.Repository
{
    using Microsoft.EntityFrameworkCore;

    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;

    public class TrainerUserRepository : BaseRepository<TrainerUser, (Guid, Guid)>, ITrainerUserRepository
    {
        public TrainerUserRepository(SportCenterDbContext DbContext) : base(DbContext)
        {
        }


        public Task<TrainerUser?> GetByCompositeKeyAsync(string trainerId, string userId)
        {
            return this.GetAllAttached()
                        .SingleOrDefaultAsync(tu => tu.ApplicationUserId.ToString().ToLower() == userId.ToLower() &&
                        tu.TrainerId.ToString().ToLower() == trainerId.ToLower());
        }

        public Task<bool> ExistsAsync(string trainerId, string userId)
        {
            return this.GetAllAttached()
                .AnyAsync(tu => tu.ApplicationUserId.ToString().ToLower() == userId.ToLower() &&
                            tu.TrainerId.ToString().ToLower() == trainerId.ToLower());
        }

        public TrainerUser? GetByCompositeKey(string trainerId, string userId)
        {
            return this.GetAllAttached()
                .SingleOrDefault(tu => tu.ApplicationUserId.ToString().ToLower() == userId.ToLower() &&
                        tu.TrainerId.ToString().ToLower() == trainerId.ToLower());
        }

        public bool Exists(string trainerId, string userId)
        {
            return this.GetAllAttached()
                .Any(tu => tu.ApplicationUserId.ToString().ToLower() == userId.ToLower() &&
                            tu.TrainerId.ToString().ToLower() == trainerId.ToLower());
        }

    }
}
