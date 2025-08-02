namespace SCV.Web.ViewModels.Administration.FitnessVM
{
    public class ExerciseDeleteViewModel
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string PrimaryMuscles { get; set; } = null!;

        public string Category { get; set; } = null!;

        public bool IsDeleted { get; set; }
    }
}
