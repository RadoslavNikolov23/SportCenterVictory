namespace SCV.Data.Models
{
    using Microsoft.EntityFrameworkCore;

    [Comment("Represents a Crossfit Workout of the Day (WOD)")]
    public class CrossfitWorkoutOfTheDay
    {
        [Comment("Primary key for the workout of the day")]
        public Guid Id { get; set; }

        [Comment("Name of the workout of the day - will contain part of the WorkoutDate")]
        public string Name { get; set; } = null!;

        [Comment("Date when the workout of the day is scheduled")]
        public DateTime WorkoutDate { get; set; }

        [Comment("Plain text description of the workout of the day")]
        public string DescriptionPlain { get; set; } = null!;

        [Comment("HTML formatted description of the workout of the day")]
        public string DescriptionHTML { get; set; } = null!;

    }
}
