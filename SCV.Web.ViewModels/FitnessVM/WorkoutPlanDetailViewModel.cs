namespace SCV.Web.ViewModels.FitnessVM
{
    using SCV.GlCommon.Enums;

    public class WorkoutPlanDetailViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public SportType Type { get; set; }

        public string? ImageUrl { get; set; }

        public virtual ICollection<WorkoutPlanExerciseDetailViewModel> WorkoutPlanExercisesVM { get; set; } = new HashSet<WorkoutPlanExerciseDetailViewModel>();
    }
}
