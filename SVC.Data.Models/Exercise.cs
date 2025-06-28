namespace SVC.Data.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string MuscleGroup { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
