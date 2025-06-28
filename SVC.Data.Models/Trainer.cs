namespace SVC.Data.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Bio { get; set; } = null!;
        public string Specialty { get; set; } = null!; // Fitness / CrossFit / Powerlifting
        public string ImageUrl { get; set; } = null!;
    }
}
