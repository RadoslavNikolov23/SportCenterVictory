namespace SCV.Data.Repository.Contracts
{
    using SCV.Data.Models;

    public interface ICrossfitWODRepository : IAsyncRepository<CrossfitWorkoutOfTheDay, int>, IRepository<CrossfitWorkoutOfTheDay, int>
    {
        Task<CrossfitWorkoutOfTheDay?> GetTodayWOD();
    }
}
