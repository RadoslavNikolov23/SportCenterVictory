namespace SCV.Web.ViewModels.FitnessVM
{
    //Check if this is necessary view model or not!!!
    public class ExercisesPageViewModel
    {
        public IEnumerable<ExercisesIndexViewModel> Exercises { get; set; } = new List<ExercisesIndexViewModel>();

        //public IEnumerable<ExercisesIndexViewModel> Exercises { get; set; } = Enumerable.Empty<ExercisesIndexViewModel>();


        public bool HasMore { get; set; }
    }
}
