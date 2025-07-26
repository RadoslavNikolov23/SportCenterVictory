namespace SCV.Data.Repository
{
    using Microsoft.EntityFrameworkCore;
    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;

    public class CrossfitWODRepository : BaseRepository<CrossfitWorkoutOfTheDay, Guid>, ICrossfitWODRepository
    {
        public CrossfitWODRepository(SportCenterDbContext DbContext) : base(DbContext)
        {
        }

        public async Task<CrossfitWorkoutOfTheDay?> GetTodayWOD()
        {

            CrossfitWorkoutOfTheDay? crossfitWOD = null;

            DateTime todayWOD = DateTime.UtcNow.AddHours(3);
            try
            {
                crossfitWOD = await this.DbContext.CrossfitWorkoutOfTheDays
                                        .SingleOrDefaultAsync(cwod => cwod.WorkoutDate == todayWOD);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the todays Workout of the day, the message is {ex.Message}");
            }

            return crossfitWOD;
        }
    }
}
