namespace SVC.Data.Models
{
    public class CrossfitWorkoutOfTheDay
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime WorkoutDate { get; set; }

        public string DescriptionPlain { get; set; } = null!;

        public string DescriptionHTML { get; set; } = null!;



    }
}
