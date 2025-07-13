namespace SCV.Web.ViewModels.FitnessVM
{
    public class ExercisesPageViewModel
    {
        public IEnumerable<ExercisesIndexViewModel> Exercises { get; set; } = new List<ExercisesIndexViewModel>();

        //public IEnumerable<ExercisesIndexViewModel> Exercises { get; set; } = Enumerable.Empty<ExercisesIndexViewModel>();


        public bool HasMore { get; set; }
    }
}
