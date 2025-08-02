namespace SCV.Web.ViewModels.Administration.FitnessVM
{
    public class WorkoutPlanSelectListViewModel
    {
        public IEnumerable<WorkoutPlanAdminDetailViewModel> WorkoutPlans { get; set; } = new HashSet<WorkoutPlanAdminDetailViewModel>();
    }
}
