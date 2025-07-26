namespace SCV.Data.Repository.Contracts
{
    using SCV.Data.Models;

    public interface ICrossfitWODRepository : IAsyncRepository<CrossfitWorkoutOfTheDay, Guid>, IRepository<CrossfitWorkoutOfTheDay, Guid>
    {
        Task<CrossfitWorkoutOfTheDay?> GetTodayWOD();
    }
}
