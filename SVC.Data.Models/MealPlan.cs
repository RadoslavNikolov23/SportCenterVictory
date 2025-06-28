namespace SVC.Data.Models
{
    public class MealPlan
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string DietType { get; set; } = null!;// Keto, Vegan, Muscle Gain, etc.
        public string Description { get; set; } = null!;
        public decimal? Price { get; set; }
    }
}
