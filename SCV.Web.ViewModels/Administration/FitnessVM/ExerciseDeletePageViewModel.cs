namespace SCV.Web.ViewModels.Administration.FitnessVM
{
    public class ExerciseDeletePageViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public string? SearchTerm { get; set; }

        public IEnumerable<ExerciseDeleteViewModel> Exercises { get; set; } = new HashSet<ExerciseDeleteViewModel>();
    }
}
