namespace SCV.Web.ViewModels.Administration.FitnessVM
{
    public class WorkoutPlanExerciseAttachViewModel
    {
        public string WorkoutPlanId { get; set; } = null!;
        public string? WorkoutPlanTitle { get; set; }

        public ICollection<string> SelectedExerciseIds { get; set; } = new HashSet<string>();
        public ICollection<string> AttachedExerciseIds { get; set; } = new HashSet<string>();

        public IEnumerable<ExerciseAdminDetailViewModel> AllExercises { get; set; } = new HashSet<ExerciseAdminDetailViewModel>();
    }
}
